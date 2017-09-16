using System;
using GlobalBLL;
using System.Linq;
using CustomExtensions;
using SuperDataBase;
using System.Collections.Generic;
using SuperDataBase.Vo;
using SuperDataBase.InterFace;

namespace DAL.DAL
{
    /// <summary>
    /// 货款表
    /// </summary>
    [Serializable]
    public partial class LC_Payment : DALBase
    {
        public LC_Payment()
        { }

        /// <summary>
        /// 获取货款记录
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="state">最后的状态 0未处理（不可用）,1已回收(可用）,2(已放款)</param>
        /// <param name="starttime">筛选开始时间</param>
        /// <param name="endtime">筛选结束时间</param>
        /// <param name="startuid">物流起始地</param>
        /// <param name="enduid">物流结束地</param>
        /// <param name="page">当前页</param>
        /// <param name="num">每页个数</param>
        /// <param name="orderlist">订单列表</param>
        /// <returns></returns>
        public static (bool, string, object) GetPaymentRecording(UserLoginVO myuservo, int state, DateTime starttime, DateTime endtime, string startuid, string enduid, int page, int num, string orderlist, string HKDetail)
        {
            var tlist = new Type[] {
                typeof(Model.Model.LC_Payment),
                typeof(Model.Model.LC_Customer),
            };
            string where = string.Empty;
            if (!starttime.IsNull() && !endtime.IsNull())
            {
                where = " and {0}.LastOperationTime between @starttime and @endtime";
            }
            else
            {
                starttime = DateTime.Now;
                endtime = DateTime.Now;
            }
            if(startuid.StrIsNotNull() && enduid.StrIsNotNull())
            {
                where += " and {1}.logisticsID=@logisticsID and {1}.finishUID=@finishUID";
            }
            if (orderlist.StrIsNotNull())
            {
                where += " and {1}.OrderID in(" + orderlist.StringToArray().Select(x => $"'{x}'").ToList().ListToString() + ")";
            }


            if (HKDetail != "have")
            {
                if (state != 0)
                    where += " and {0}.StartLogisticsUID<>{0}.LocationLogisticsUID";

                //默认查询
                sql = makesql.MakeSelectArrSql(tlist, "{0}.OrderNumber={1}.OrderID and {0}.LocationLogisticsUID=@LocationLogisticsUID and {0}.LastState=@state" + where, new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@state",state),
                    new System.Data.SqlClient.SqlParameter("@starttime",starttime),
                    new System.Data.SqlClient.SqlParameter("@endtime",endtime),
                    new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid),
                    new System.Data.SqlClient.SqlParameter("@logisticsID",startuid),
                    new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
                });
            }
           else if(HKDetail=="have")
            {
                    sql = makesql.MakeSelectArrSql(tlist, "{0}.OrderNumber={1}.OrderID and {0}.StartLogisticsUID={0}.LocationLogisticsUID and {0}.LocationLogisticsUID=@LocationLogisticsUID and {0}.LastState=@state" + where, new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@state",state),
                    new System.Data.SqlClient.SqlParameter("@starttime",starttime),
                    new System.Data.SqlClient.SqlParameter("@endtime",endtime),
                    new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid),
                     new System.Data.SqlClient.SqlParameter("@logisticsID",startuid),
                    new System.Data.SqlClient.SqlParameter("@finishUID",enduid)
                    });
            }
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList(tlist).Select((x) =>
            {
                var lcp = x.GetDicVO<Model.Model.LC_Payment>();
                var lcc = x.GetDicVO<Model.Model.LC_Customer>();
                return new
                {
                    lcp,
                    lcc,
                    freightModeName = lcc.freightMode.ConvertData<GlobalBLL.YFFSEnum>().EnumToName(),
                    DestinationName=DAL.DALBase.GetAddressFromID(lcc.Destination.ConvertData<int>()).Item2.Name
                };
            }));
        }

        public static (bool, string, object) Yesterdaybalance(UserLoginVO myuservo, DateTime fristtime, DateTime lasttime, DateTime fristToday, DateTime lastToday)
        {
            //昨日收款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(Total) as 'Yesterdaybalance' from LC_Customer where State=6 and DischargeTime BETWEEN '"+ fristtime + "' and '"+ lasttime + "' and logisticsID='"+myuservo.uid+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal Yesterdaybalance = ids.dt.Rows[0]["Yesterdaybalance"].ConvertData<decimal>();
            //昨日放款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(PaymentAllAmount) as 'Loan' from LC_Payment_History where CreateTime between '"+ fristtime + "' and '"+ lasttime + "' and LastState=2");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal Loan = ids.dt.Rows[0]["Loan"].ConvertData<decimal>();
            //昨日上缴款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(PaymentAllAmount) as 'Paid' from LC_Payment_History where CreateTime between '"+fristtime+"' and '"+lasttime+"' and LastState=0");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal Paid = ids.dt.Rows[0]["Paid"].ConvertData<decimal>();
            //今天收款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(Total) as 'CollectionToday' from LC_Customer where State=6 and DischargeTime BETWEEN '"+fristToday+"' and '"+lastToday+"' and logisticsID='"+myuservo.uid+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal CollectionToday = ids.dt.Rows[0]["CollectionToday"].ConvertData<decimal>();
            //今天支付
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(Total) as 'PaymentToday' from LC_Customer where State=6 and DischargeTime BETWEEN '"+fristToday+"' and '"+lastToday+"' and logisticsID='"+myuservo.uid+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal PaymentToday = ids.dt.Rows[0]["PaymentToday"].ConvertData<decimal>();

            //今天回收代收款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(PaymentAllAmount) as 'RecoveryFund' from LC_Payment_History where CreateTime between '"+fristToday+"' and '"+lastToday+"'and LastState=1");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal RecoveryFund = ids.dt.Rows[0]["RecoveryFund"].ConvertData<decimal>();

            //昨天支付
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(Total) as 'PaymentYesterday' from LC_Customer where State=6 and DischargeTime BETWEEN '" + fristtime + "' and '" + lasttime + "' and logisticsID='" + myuservo.uid + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal PaymentYesterday = ids.dt.Rows[0]["PaymentYesterday"].ConvertData<decimal>();

            //昨天回收代收款
            sql = new SuperDataBase.Vo.SqlVO(@"select Sum(PaymentAllAmount) as 'YesterdayRecoveryFund' from LC_Payment_History where CreateTime between '" + fristtime + "' and '" + lasttime + "'and LastState=1");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            decimal YesterdayRecoveryFund = ids.dt.Rows[0]["YesterdayRecoveryFund"].ConvertData<decimal>();

            return (true, string.Empty, new {
                Yesterdaybalance, //昨天收款
                Loan,//昨天付款
                Paid,//上缴款
                CollectionToday,//今天收款
                PaymentToday,//放货款
                PaymentYesterday,//昨天放货款
                RecoveryFund,//回收款
                YesterdayRecoveryFund,//昨天回收款
                Yesterdaymoney = Yesterdaybalance-(Loan+ Paid),//昨日余额
                PayToday= PaymentToday+ RecoveryFund,//今天支付
                PaymentYesterdays= PaymentYesterday+ YesterdayRecoveryFund,//昨天支付
            });

        }


        //日结账列表
        public static (bool, string, object) GetPaymentDay(UserLoginVO myuservo, DateTime starttime, DateTime endtime)
        {
            var tlist = new Type[] {
                typeof(Model.Model.LC_Customer),
                typeof(Model.Model.LC_History),
            };
            string where = string.Empty;
            where = " and {1}.HistoryTime between @starttime and @endtime";
            string dqstarttime = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            string dqsendtime= DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            if (starttime.IsNull() && endtime.IsNull())
            {
                sql = makesql.MakeSelectArrSql(tlist, "{0}.OrderID={1}.OrderID and {1}.logisticsID=@logisticsID and {1}.State=@State" + where, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID", myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@State","6"),
                new System.Data.SqlClient.SqlParameter("@starttime",dqstarttime),
                new System.Data.SqlClient.SqlParameter("@endtime",dqsendtime)
            });
            }
            else
            {
                sql = makesql.MakeSelectArrSql(tlist, "{0}.OrderID={1}.OrderID and {1}.logisticsID=@logisticsID and {1}.State=@State" + where, new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID", myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@State","6"),
                new System.Data.SqlClient.SqlParameter("@starttime",starttime),
                new System.Data.SqlClient.SqlParameter("@endtime",endtime)
                  });
            }
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList(tlist).Select(x =>
            {
                var lcc = x.GetDicVO<Model.Model.LC_Customer>();
                var lch = x.GetDicVO<Model.Model.LC_History>();
                return new
                {
                    lcc,
                    lch,
                    freightModeName = lcc.freightMode.ConvertData<GlobalBLL.YFFSEnum>().EnumToName()
                };
            }).ToList());
        }

        public static (bool, string, object) GetPaidCount(UserLoginVO myuservo, int state, int page, int num)
        {
            var tlist = new Type[] {
                typeof(Model.Model.LC_Payment),
                typeof(Model.Model.LC_Customer),
            };
            sql = makesql.MakeSelectFieldSql(tlist, new string[] { " SUM(LC_Customer.Freight) as Freight", "SUM(LC_Customer.GReceivables) as GReceivables" }, "{0}.OrderNumber={1}.OrderID and {0}.LocationLogisticsUID=@LocationLogisticsUID and {0}.LastState=@state", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@state",state),
                    new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid),
                });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });

            return (true, string.Empty, new
            {
                Freight = ids.dt.Rows[0]["Freight"].ConvertData<decimal>(),
                GReceivables = ids.dt.Rows[0]["GReceivables"].ConvertData<decimal>()
            });
        }

        /// <summary>
        /// 放款
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="orderList"></param>
        /// <returns></returns>
        public static (bool, string, object) LendersPayment(UserLoginVO myuservo, List<string> orderList)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                string ordernumberstr = orderList.Select(x => $"'{x}'").ToList().ListToString();
                //检测这些订单我是否可以操作
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Payment), $"OrderNumber in ({ordernumberstr}) and StartLogisticsUID=@StartLogisticsUID and LocationLogisticsUID=@LocationLogisticsUID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid),
                    new System.Data.SqlClient.SqlParameter("@StartLogisticsUID",myuservo.uid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg, null);
                if (ids.num != orderList.Count)
                    return (false, "当前订单号中存在无法操作的数据!", null);

                List<Model.Model.LC_Payment> pm_list = ids.GetVOList<Model.Model.LC_Payment>();

                //更新这些数据为正常
                sql = makesql.MakeUpdateSQL(new Model.Model.LC_Payment()
                {
                    LastState = 2,
                    LastOperationTime = DateTime.Now,
                    LastOperatorsUID = myuservo.uid
                }, $"OrderNumber in ({ordernumberstr})");
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg, null);
                if (!ids.ExecOk())
                    return (false, "更新状态失败!", null);

                //更新到历史表
                var atp =  AddToPaymentHistory(ordernumberstr, db);
                if (!atp.Item1)
                    return (false, ids.errormsg, null);
                db.Commit(); //提交事务
                return (true, string.Empty, pm_list.Sum(x=>x.PaymentAllAmount));
            });
            return box;
        }

        /// <summary>
        /// 获取放货数据
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="page"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static (bool, string, object) GetLendersList(UserLoginVO myuservo, int page, int num)
        {
            //获取订单列表
            sql = new SuperDataBase.Vo.SqlVO($@"SELECT
                        a.OrderNumber,
                        b.Phone
                    FROM
                        {nameof(Model.Model.LC_Payment)} a,
                        {nameof(Model.Model.LC_User)} b,
                        {nameof(Model.Model.LC_Customer)} c
                    WHERE
                        a.OrderNumber = c.OrderID
                    AND b.Phone = c.FHPhone
                    AND a.LastState = '1'
                    AND a.StartLogisticsUID = a.LocationLogisticsUID
                    AND a.LocationLogisticsUID = '{myuservo.uid}'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (true, "啥都没有", new object[] { });

            List<(string ordernumber,string phone)> orderList = new List<(string ordernumber, string phone)>();
            for(var i=0;i<ids.dt.Rows.Count;i++)
            {
                var row = ids.dt.Rows[i];
                orderList.Add((row[0].ConvertData(), row[1].ConvertData()));
            }


            sql = new SuperDataBase.Vo.SqlVO($@"
            SELECT
                d.FHPhone,
                max(d.Consignee) as 'Consignee',
                max(d.Consignor) as 'Consignor',
                max(d.DischargeTime) as DischargeTime,
                COUNT(d.OrderID) as 'num',
                SUM(
                    d.GReceivables + d.Freight + d.OtherExpenses
                ) AS 'allamount'
            FROM
                {nameof(Model.Model.LC_Customer)} d
            WHERE
                OrderID IN({orderList.Select(x=>$"'{x.ordernumber}'").ToList().ListToString()})
            GROUP BY
                d.FHPhone,d.DischargeTime;");

            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, string.Empty, new object[] { });
            List<object> obj_list = new List<object>();
            for (var i = 0; i < ids.dt.Rows.Count; i++)
            {
                var v = ids.dt.Rows[i];
                obj_list.Add(new
                {
                    FHPhone = v["FHPhone"],
                    Consignee=v["Consignee"],
                    Consignor=v["Consignor"],
                    num = v["num"],
                    allamount = v["allamount"],
                    OrderList = orderList.Where(x=>x.phone.Equals(v["FHPhone"].ConvertData(), StringComparison.OrdinalIgnoreCase)).Select(y=>y.ordernumber).ToList(),
                    DischargeTime=v["DischargeTime"]
                });
            }
            return (true, string.Empty, obj_list);
        }

        /// <summary>
        /// 上缴货款或放款
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="orderlist"></param>
        /// <param name="model">1为上缴,2回收</param>
        /// <returns></returns>
        public static (bool, string) TurnedOrRecoveryPayment(UserLoginVO myuservo, List<string> orderlist,int model)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //检测所有订单号是否我可以操作
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Payment), $"OrderNumber in ({orderlist.Where(y => y.StrIsNotNull()).Select(x=>$"'{x}'").ToList().ListToString()}) and LocationLogisticsUID=@LocationLogisticsUID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.num != orderlist.Count)
                    return (false, "订单中存在您无法操作的数据!");

                //先判断这些订单是否都是需要上缴的订单(需要上缴则走上缴流程，不需要上缴则走放款流程)
                switch (model)
                {
                    case 1: //上缴
                        var tup = TurnedPayment(myuservo, ids.GetVOList<Model.Model.LC_Payment>(), db);
                        if (!tup.Item1)
                            return (false, tup.Item2);
                        break;
                    case 2: //回收货款
                        var rp = RecoveryPayment(myuservo, ids.GetVOList<Model.Model.LC_Payment>(), db);
                        if (!rp.Item1)
                            return (false, rp.Item2);
                        break;
                    default:
                        return (false, "状态不正确无法进行操作!");
                }

                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 回收货款
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="paymentlist"></param>
        /// <returns></returns>
        private static (bool,string) RecoveryPayment(UserLoginVO myuservo, List<Model.Model.LC_Payment> paymentlist, SuperDataBase.Model.DBSandbox db)
        {
            string orderNumberStr = paymentlist.Select(x => $"'{x.OrderNumber}'").ToList().ListToString();
            //检测是否有不是可回收货款的数据
            var f = paymentlist.Where(x => x.LastState!=0).ToList();
            if (f.Count > 0)
                return (false, "当前操作存在不可回收的货款项，操作失败!");
            //执行回收操作
            sql = makesql.MakeUpdateSQL(new Model.Model.LC_Payment() {
                LastState=1,
                LastOperatorsUID = myuservo.uid
            }, $"OrderNumber in ({orderNumberStr})");
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, "修改回收数据失败!");
            if (!ids.ExecOk())
                return (false, "回收失败,请重试!");

            //添加历史记录
            var atp = AddToPaymentHistory(orderNumberStr, db);
            if (!atp.Item1)
                return (false, atp.Item2);

            return (true, string.Empty);
        }

        /// <summary>
        /// 上缴流程
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="orderlist"></param>

        private static (bool, string) TurnedPayment(UserLoginVO myuservo, List<Model.Model.LC_Payment> paymentlist, SuperDataBase.Model.DBSandbox db)
        {
            //检测是否有不是上缴货款的数据
            var f = paymentlist.Where(x => x.StartLogisticsUID.Equals(x.LocationLogisticsUID, StringComparison.OrdinalIgnoreCase)).ToList();
            if (f.Count > 0)
                return (false, "当前操作存在非上缴货款项，操作失败!");
            
            //更新到上缴人
            sql = new SuperDataBase.Vo.SqlVO($@"update a set LocationLogisticsIndex=(select top 1 ID from {nameof(Model.Model.LC_History)} where state in ({GlobalBLL.OrderStateEnum.已发货.EnumToInt()},{OrderStateEnum.已到收货地可提货.EnumToInt()}) and logisticsID=b.beginUID order by id asc) LocationLogisticsUID=b.beginUID , a.LastOperationTime=@LastOperationTime,a.LastOperatorsUID='{myuservo.uid}',a.LastState=0 FROM {nameof(Model.Model.LC_Payment)} a,{nameof(Model.Model.LC_History)} b 
                                                                        where a.OrderNumber in ({paymentlist.Select(x => $"'{x.OrderNumber}'").ToList().ListToString()}) 
                                                                        and a.OrderNumber=b.OrderID 
                                                                        and b.State = {GlobalBLL.OrderStateEnum.订单完成.EnumToInt()}
                                                                        and LocationLogisticsUID=@LocationLogisticsUID;", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@LocationLogisticsUID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@LastOperationTime",DateTime.Now),
                //new System.Data.SqlClient.SqlParameter("@PaidTime",DateTime.Now)
            });
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ExecOk())
                return (false, "更新邀请人失败!");

            var atp = AddToPaymentHistory(paymentlist.Select(x => $"'{x.OrderNumber}'").ToList().ListToString(), db);
            if (!atp.Item1)
                return (false, atp.Item2);

            return (true, string.Empty);
        }

        /// <summary>
        /// 添加到放款历史
        /// </summary>
        /// <param name="orderNumberStr"></param>
        /// <returns></returns>
        private static (bool,string) AddToPaymentHistory(string orderNumberStr,SuperDataBase.Model.DBSandbox db)
        {
            string F_LC_Payment = SuperDataBase.Model.TableFieldCache.GetFieldList(typeof(Model.Model.LC_Payment)).Select(x => x.Name).Where((y) => {
                if (!y.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return false;
            }).ToList().ListToString();

            sql = new SuperDataBase.Vo.SqlVO($"INSERT INTO {nameof(Model.Model.LC_Payment_History)} ({F_LC_Payment}) SELECT {F_LC_Payment} FROM {nameof(Model.Model.LC_Payment)} where OrderNumber in ({orderNumberStr})");
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ExecOk())
                return (false, "更新上缴历史失败!");
            return (true, string.Empty);
        }
    }
}
