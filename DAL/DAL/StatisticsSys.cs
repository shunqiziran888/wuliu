using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBLL;
using CustomExtensions;
namespace DAL.DAL
{
    public class StatisticsSys : DALBase
    {
        /// <summary>
        /// 获取运营统计
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        public static (bool, string, object) GetOperationStatistics(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            GlobalBLL.VO.OperationStatisticsVO osvo = new GlobalBLL.VO.OperationStatisticsVO()
            {
                HDTJ_JieDanShu = 获取接单数(myuservo, starttime, endtime),
                HDTJ_YunShuDanShu = 获取运输订单(myuservo, starttime, endtime, startuid, enduid),
                HDTJ_KuCunDanShu = 获取库存单数(myuservo, starttime, endtime, startuid, enduid),
                HDTJ_JieWanHuoDan = 获取接完货单(myuservo, starttime, endtime, startuid, enduid),


                JieJianNumber = 获取接件数(myuservo, starttime, endtime, startuid, enduid),
                YunShuZongJianShu = 获取运输总件数(myuservo, starttime, endtime, startuid, enduid),
                KuCunJianShu = 获取库存件数(myuservo, starttime, endtime, startuid, enduid),
                JieWanJianShu = 获取接完件数(myuservo, starttime, endtime, startuid, enduid),

                JieCheCheShu = 获取接车车数(myuservo, starttime, endtime, startuid, enduid),
                YunShuZongShu = 获取运输总数(myuservo, starttime, endtime, startuid, enduid),

                FaHuoKeHu = 获取发货客户数(myuservo, starttime, endtime, startuid, enduid),
                SuoHuoKeHu = 获取收货客户数(myuservo, starttime, endtime, startuid, enduid),

            };
            osvo.HuiCheTongJi = osvo.JieCheCheShu + osvo.YunShuZongShu; //汇总车次

            return (true, string.Empty, osvo);
        }

        /// <summary>
        /// 获取财务统计
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        public static (bool, string, object) GetFinancialStatistics(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            GlobalBLL.VO.FinancialStatisticsVO fsvo = new GlobalBLL.VO.FinancialStatisticsVO()
            {
                ShangJiaoHuiZong = 获取上缴汇总(myuservo, starttime, endtime, startuid, enduid),
                WeiShangJiaoHuiZong = 获取未上缴汇总(myuservo, starttime, endtime, startuid, enduid),
                HuiShouHuiZong = 获取回收汇总(myuservo, starttime, endtime, startuid, enduid),
                WeiHuiShouHuiZong = 未回收汇总(myuservo, starttime, endtime, startuid, enduid), //更具总订单-已经回收订单，来计算的总数

                YiJieSuanYunFei = 已结算运费(myuservo, starttime, endtime, startuid, enduid),
                WeiJieSuanYunFei = 未结算运费(myuservo, starttime, endtime, startuid, enduid),
                DaCheYunFei = 大车运费(myuservo,starttime,endtime,startuid,enduid),
            };
            return (true, string.Empty, fsvo);
        }

        private static long 大车运费(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取回收汇总
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "sum(largeCar)" }, $"State<>@State  {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid), //与我相关
                new System.Data.SqlClient.SqlParameter("@State",GlobalBLL.OrderStateEnum.已装车运输中.EnumToInt())
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 未结算运费(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取回收汇总
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "sum(Freight)" }, $"State<>@State  {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid), //与我相关
                new System.Data.SqlClient.SqlParameter("@State",GlobalBLL.OrderStateEnum.订单完成.EnumToInt())
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.GetFristData<long>(0);
        }

        /// <summary>
        /// 已结算运费
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        private static long 已结算运费(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取回收汇总
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History),new string[] { "sum(Freight)" }, $"State=@State  {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid), //与我相关
                new System.Data.SqlClient.SqlParameter("@State",GlobalBLL.OrderStateEnum.订单完成.EnumToInt())
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 未回收汇总(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and a.LastOperationTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and b.beginUID=@beginUID and b.finishUID=@finishUID";

            //获取与我相关的全部订单
            sql = new SuperDataBase.Vo.SqlVO($@"SELECT
	                count(OrderNumber)
                FROM
	                {nameof(Model.Model.LC_Payment_History)} a,
	                {nameof(Model.Model.LC_Customer)} b
                WHERE
	                a.OrderNumber = b.OrderID AND
                b.finishUID = {myuservo.uid} {where}
                group by OrderNumber");
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            long allnum = ids.Count();
            long yssnum = 获取回收汇总(myuservo, starttime, endtime, startuid, enduid);

            return allnum-yssnum;
        }

        private static long 获取回收汇总(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and {0}.LastOperationTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and {1}.beginUID=@beginUID and {1}.finishUID=@finishUID";

            //获取回收汇总
            sql = makesql.MakeCount(new Type[] { typeof(Model.Model.LC_Payment_History), typeof(Model.Model.LC_Customer) }, "{0}.OrderNumber={1}.OrderID and {0}.LastOperatorsUID=@LastOperatorsUID and {0}.LocationLogisticsUID=LastOperatorsUID and {0}.LastState <> 1" + where, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@LastOperatorsUID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.Count();
        }

        private static long 获取未上缴汇总(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and {0}.LastOperationTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and {1}.beginUID=@beginUID and {1}.finishUID=@finishUID";

            //获取未上缴汇总
            sql = makesql.MakeCount(new Type[] { typeof(Model.Model.LC_Payment_History), typeof(Model.Model.LC_Customer) }, "{0}.OrderNumber={1}.OrderID and {0}.LastOperatorsUID=@LastOperatorsUID and {0}.LocationLogisticsUID=LastOperatorsUID and {0}.LastState<>2" + where, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@LastOperatorsUID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.Count();
        }

        private static long 获取上缴汇总(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and {0}.LastOperationTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and {1}.beginUID=@beginUID and {1}.finishUID=@finishUID";

            //获取上缴汇总
            sql = makesql.MakeCount(new Type[] { typeof(Model.Model.LC_Payment_History), typeof(Model.Model.LC_Customer) }, "{0}.OrderNumber={1}.OrderID and {0}.LastOperatorsUID=@LastOperatorsUID and {0}.LocationLogisticsUID<>LastOperatorsUID and {0}.LastState<>2" + where, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@LastOperatorsUID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            return ids.Count();
        }

        #region 财务统计

        #endregion

        #region 运营统计
        private static long 获取收货客户数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(FHPhone)" }, $"State=@State and logisticsID=@logisticsID {where}  group by FHPhone", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.客户取货.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取发货客户数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(FHPhone)" }, $"State=@State and logisticsID=@logisticsID {where}  group by FHPhone", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.已发货.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取运输总数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";

            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(VehicleID)" }, $"State=@State and logisticsID=@logisticsID {where}  group by VehicleID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.已装车运输中.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        /// <summary>
        /// 获取接车车数
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        private static long 获取接车车数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";


            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(VehicleID)" }, $"State in({OrderStateEnum.已到收货地可提货.EnumToInt()},{OrderStateEnum.货物已中转.EnumToInt()}) and logisticsID=@logisticsID {where}  group by VehicleID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取接完件数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "sum(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.订单完成.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取运输总件数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "sum(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.已装车运输中.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        /// <summary>
        /// 获取接件数
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        private static long 获取接件数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "sum(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.物流已收货.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取接完货单(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.订单完成.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        /// <summary>
        /// 获取库存件数
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        private static long 获取库存件数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(Number)" }, $"State in({OrderStateEnum.已到收货地可提货.EnumToInt()},{OrderStateEnum.货物已中转.EnumToInt()}) and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取库存单数(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.已装车运输中.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        private static long 获取运输订单(UserLoginVO myuservo, DateTime starttime, DateTime endtime, string startuid, string enduid)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            if (startuid.StrIsNotNull() && enduid.StrIsNotNull())
                where += " and beginUID=@beginUID and finishUID=@finishUID";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",OrderStateEnum.已装车运输中.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@beginUID",startuid),
                new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
            });

            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }

        /// <summary>
        /// 获取接单数
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="startuid"></param>
        /// <param name="enduid"></param>
        /// <returns></returns>
        private static long 获取接单数(UserLoginVO myuservo, DateTime starttime, DateTime endtime)
        {
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
                where += " and HistoryTime between @starttime and @endtime";
            //获取接单数
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_History), new string[] { "count(Number)" }, $"State=@State and logisticsID=@logisticsID {where}", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State",GlobalBLL.OrderStateEnum.物流已收货.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return 0;
            if (!ids.ReadIsOk())
                return 0;
            return ids.GetFristData<long>(0);
        }
#endregion
    }
}
