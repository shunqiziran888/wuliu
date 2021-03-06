using System;
using GlobalBLL;
using System.Linq;
using CustomExtensions;
using SuperDataBase;
using System.Collections.Generic;
using System.Data;
using SuperDataBase.Vo;
using SuperDataBase.InterFace;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Customer : DALBase
    {
        public LC_Customer()
        { }
        /// <summary>
        /// 客户发货：添加
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_Customer LC_Customer)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeInsertSQL(LC_Customer);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "添加失败请重试!");
                AddToHistory(LC_Customer, db);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 数据添加到历史记录
        /// </summary>
        /// <param name="lcc"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(Model.Model.LC_Customer lcc, SuperDataBase.Model.DBSandbox db)
        {
            sql = makesql.MakeCount(nameof(Model.Model.LC_History), "OrderID=@OrderID and state=@state", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@state",lcc.State),
                new System.Data.SqlClient.SqlParameter("@OrderID",lcc.OrderID)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (ids.Count() > 0)
            {
                return (true, "已经存在了相同的状态");
            }

            sql = makesql.MakeInsertSQL(new Model.Model.LC_History()
            {
                begins = lcc.begins,
                beginUID = lcc.beginUID,
                CarryGood = lcc.CarryGood,
                Consignee = lcc.Consignee,
                ConsigneeTime = lcc.ConsigneeTime,
                Consignor = lcc.Consignor,
                ConsignorID = lcc.ConsignorID,
                DdTime = lcc.DdTime,
                Destination = lcc.Destination,
                DischargeTime = lcc.DischargeTime,
                DriverID = lcc.DriverID,
                FHPhone = lcc.FHPhone,
                finish = lcc.finish,
                finishUID = lcc.finishUID,
                Freight = lcc.Freight,
                FreightCollect = lcc.FreightCollect,
                freightMode = lcc.freightMode,
                GoodName = lcc.GoodName,
                GoodNo = lcc.GoodNo,
                GReceivables = lcc.GReceivables,
                HistoryTime = DateTime.Now,
                Initially = lcc.Initially,
                largeCar = lcc.largeCar,
                logisticsID = lcc.logisticsID,
                MeetCarTime = lcc.MeetCarTime,
                Number = lcc.Number,
                OrderID = lcc.OrderID,
                OtherExpenses = lcc.OtherExpenses,
                ReceiptGood = lcc.ReceiptGood,
                SHPhone = lcc.SHPhone,
                State = lcc.State,
                Total = lcc.Total,
                TruckTime = lcc.TruckTime,
                VehicleID = lcc.VehicleID
            });
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ExecOk())
                return (false, "添加历史失败!");
            return (true, string.Empty);
        }

        public static (bool, string, object) GetMyCount(UserLoginVO myuservo,DateTime DischargeTime,DateTime fristtime,DateTime lasttime)
        {
            //今天结余
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as TotalCount from LC_Customer where logisticsID='"+myuservo.uid+ "'and DischargeTime>='" + DischargeTime.AddDays(1).ToString("yyyy-MM-dd") + "' and DischargeTime<'" + DischargeTime.AddDays(2).ToString("yyyy-MM-dd") + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            var r = ids.dt.Rows[0];
            //昨日收款
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as YesterdayTotalCount from LC_Customer where logisticsID='"+myuservo.uid+"' and DischargeTime>='"+ DischargeTime.ToString("yyyy-MM-dd") + "' and DischargeTime<'"+DischargeTime.AddDays(1).ToString("yyyy-MM-dd")+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            var zuotian = ids.dt.Rows[0];
            //本月支出
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as ThismonthCount  from LC_Customer where logisticsID='" + myuservo.uid+"'  and DischargeTime>='"+fristtime+"'  and DischargeTime<'"+lasttime+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            var Thismonth = ids.dt.Rows[0];


            return (true, string.Empty, new {
                TotalCount = r["TotalCount"].ConvertData<long>(),
                YesterdayTotalCount = zuotian["YesterdayTotalCount"].ConvertData<long>(),
                ThismonthCount= Thismonth["ThismonthCount"].ConvertData<long>()
            });
        }

        public static (bool, string, object) GetCollectDebtsDetailTop(UserLoginVO myuservo, string sHPhone)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"select SHPhone,Consignee,Count(SHPhone) as SHPhone,Sum(Freight) as Freight,Sum(GReceivables) as GReceivables,
                            (select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime asc) as 'StartTime',(select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime desc) as 'EndTime'
                            from LC_Customer a
                            where State=9 and logisticsID='" + myuservo.uid + "' and SHPhone='" + sHPhone + "' group by SHPhone,Consignee,logisticsID");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.dt);
        }

        public static (bool, string, object) GetCollectDebtsEdit(UserLoginVO myuservo, string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and OrderID=@OrderID and State=@State", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@OrderID",OID),
                new System.Data.SqlClient.SqlParameter("@State","9")
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        }

        public static (bool, string, object) GetCollectDebtsDetail(UserLoginVO myuservo, string SHPhone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and SHPhone=@SHPhone and State=@State", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@SHPhone",SHPhone),
                new System.Data.SqlClient.SqlParameter("@State","9")
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        }

        public static (bool, string, object) GetCollectDebts(UserLoginVO myuservo)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"
                        select SHPhone,Consignee,Count(SHPhone) as SHPhone,Sum(Freight) as Freight,Sum(GReceivables) as GReceivables,
                        (select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime asc) as 'StartTime',(select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime desc) as 'EndTime'
                        from LC_Customer a
                        where State=9 and logisticsID='" + myuservo.uid + "' group by SHPhone,Consignee,logisticsID");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.dt);
        }

        /// <summary>
        /// 把订单列表添加到历史
        /// </summary>
        /// <param name="orderNumberList"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(List<string> orderNumberList, SuperDataBase.Model.DBSandbox db)
        {
            return AddToHistory(orderNumberList.Select(x => $"'{x}'").ToList().ListToString(), db);
        }

        /// <summary>
        /// 添加历史记录
        /// </summary>
        /// <param name="VehicleID">车辆ID</param>
        /// <param name="nowUid">当前物流公司UID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(int VehicleID, string nowUid, SuperDataBase.Model.DBSandbox db)
        {
            //获取所有订单数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"VehicleID=@VehicleID and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",VehicleID),
                new System.Data.SqlClient.SqlParameter("@finishUID",nowUid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ReadIsOk())
                return (false, "获取数据失败!");
            foreach (var p in ids.GetVOList<Model.Model.LC_Customer>())
            {
                var vv = AddToHistory(p, db);
                if (!vv.Item1)
                    return (false, vv.Item2);
            }
            return (true, string.Empty);
        }



        /// <summary>
        /// 把订单列表添加到历史
        /// </summary>
        /// <param name="orderNumberStr"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(string orderNumberStr, SuperDataBase.Model.DBSandbox db)
        {
            //获取所有订单数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"OrderID in({orderNumberStr})");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ReadIsOk())
                return (false, "获取数据失败!");
            foreach (var p in ids.GetVOList<Model.Model.LC_Customer>())
            {
                var vv = AddToHistory(p, db);
                if (!vv.Item1)
                    return (false, vv.Item2);
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// 更新物流接车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cH"></param>
        /// <param name="End">目的地</param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdateMC(long id, int cH, string UID, int End)
        {
            var box = db.CreateTranSandbox<Tuple<bool, string>>((db) =>
             {
                 var uservo = GetUserVoFromId(id, db);
                 if (!uservo.Item1)
                     return new Tuple<bool, string>(false, uservo.Item2);

                 #region 更新订单已经到达终点的订单
                 sql = makesql.MakeUpdateSQL(new Model.Model.LC_Customer()
                 {
                     State = 4,
                     logisticsID = UID,
                     MeetCarTime = DateTime.Now
                 }, "Destination=finish and VehicleID=@VehicleID and State=3 and finish=@finish and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH),
                    new System.Data.SqlClient.SqlParameter("@finish",End),
                    new System.Data.SqlClient.SqlParameter("@finishUID",UID)
                 });
                 ids = db.Exec(sql);
                 if (!ids.flag)
                     return new Tuple<bool, string>(false, ids.errormsg);
                 #endregion

                 #region 更新订单当前未到终点的订单
                 sql = makesql.MakeUpdateSQL(new Model.Model.LC_Customer()
                 {
                     State = 7,
                     logisticsID = UID
                 }, "Destination<>finish and VehicleID=@VehicleID and State=3 and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH),
                    new System.Data.SqlClient.SqlParameter("@finish",End)
                 });
                 ids = db.Exec(sql);
                 if (!ids.flag)
                     return new Tuple<bool, string>(false, ids.errormsg);
                 #endregion

                 var ath = AddToHistory(cH, UID, db);
                 if (!ath.Item1)
                     return new Tuple<bool, string>(false, ath.Item2);

                 db.Commit();
                 return new Tuple<bool, string>(true, string.Empty);
             });
            return box;
        }

        /// <summary>
        ///收货：列表查询
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCusList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=1 and logisticsID='" + UID + "'",new System.Data.SqlClient.SqlParameter[] {
            }, "DdTime desc");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 更新：传ID
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <param name="updateGoodNum">是否更新货号</param>
        /// <returns></returns>
        public static Tuple<bool, string> Update(Model.Model.LC_Customer LC_Customer, string OrderID, bool updateGoodNum = false)
        {
            Model.Model.LC_Customer lcc = null;
            var box = db.CreateTranSandbox((db) =>
            {
                //获取此订单数据
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",OrderID)
                    });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "没有找到任何订单数据！");
                lcc = ids.GetVOList<Model.Model.LC_Customer>()[0];
                if (updateGoodNum)
                {

                    lcc.finish = LC_Customer.finish;
                    lcc.begins = LC_Customer.begins;
                    if (lcc.GoodNo.StrIsNull())
                    {
                        var vo = GetGoodNo(ref lcc);
                        if (vo.Item1)
                            LC_Customer.GoodNo = vo.Item2;
                    }
                }

                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@OrderID",OrderID)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "修改失败请重试!");

                if (LC_Customer.State.ConvertData<GlobalBLL.OrderStateEnum>() == GlobalBLL.OrderStateEnum.订单完成)
                {

                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_History), $"OrderID=@OrderID and State={GlobalBLL.OrderStateEnum.已发货.EnumToInt()}", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",lcc.OrderID)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);

                    if (!ids.ReadIsOk())
                        return new Tuple<bool, string>(false, "订单数据不能为空!");

                    var fastordervo = ids.GetVOList<Model.Model.LC_History>()[0];

                    //添加一个货款数据
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_Payment()
                    {
                        CreateTime = DateTime.Now,
                        LastOperationTime = DateTime.Now,
                        LastState = 1,
                        LocationLogisticsUID = lcc.logisticsID,
                        StartLogisticsUID = fastordervo.logisticsID,
                        OrderNumber = lcc.OrderID,
                        PaymentAllAmount = lcc.Freight + lcc.GReceivables + lcc.OtherExpenses,
                        LocationLogisticsIndex = GetLogisticsIndex(lcc.logisticsID).index
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "创建货款数据失败!");

                    //创建货款历史数据
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_Payment_History()
                    {
                        CreateTime = DateTime.Now,
                        LastOperationTime = DateTime.Now,
                        LocationLogisticsUID = lcc.beginUID,
                        StartLogisticsUID = lcc.logisticsID,
                        OrderNumber = lcc.OrderID,
                        PaymentAllAmount = lcc.Freight + lcc.GReceivables + lcc.OtherExpenses,
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "添加货款历史失败!");

                }

                var addh = AddToHistory(new string[] { OrderID }.ToList(), db);
                if (!addh.Item1)
                    return new Tuple<bool, string>(false, addh.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }
        /// <summary>
        /// 装车：列表查询
        /// </summary>
        /// <param name="Initially"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCmdList(string UID, int sta, int end)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=2 and logisticsID='" + UID + "' and begins=" + sta + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 装车：多个ID更新
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdatePC(Model.Model.LC_Customer LC_Customer, string OrderID)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID in (" + OrderID + ")");
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "修改失败请重试!");

                var ath = AddToHistory(OrderID, db);
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 接车：查询列表
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="AreaID">当前物流所在地区ID</param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable> GetMCList(string UID, int AreaID)
        {
            sql = new SuperDataBase.Vo.SqlVO("select finish,SUM(Freight) as 'Freight',VehicleID from LC_Customer where State=3 group by finish,VehicleID;");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(false, ids.errormsg, null, null);
            var mydt = ids.dt;

            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=3 and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@finish",AreaID)
                });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(false, ids.errormsg, null, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>(), mydt);
            return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(true, "没有任何数据!", new List<Model.Model.LC_Customer>(), null);
        }
        /// <summary>
        /// 发货历史列表
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGList(string Phone, string SHPhone)
        {
            //两表查询
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            if (SHPhone != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + Phone + "' and SHPhone='" + SHPhone + "'");
                ids = db.Read(sql);
            }
            else if (SHPhone == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + Phone + "'",new System.Data.SqlClient.SqlParameter[] {
                }, "DdTime desc");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 货物追踪-收货
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGSHList(string Phone, string FHPhone)
        {
            //两表查询
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            if (FHPhone != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and FHPhone='" + FHPhone + "'");
                ids = db.Read(sql);
            }
            else if (FHPhone == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and State!=10", new System.Data.SqlClient.SqlParameter[] {
                }, "DdTime desc");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 货物签收-详情列表
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetSGList(string Phone, string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and OrderID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());

        }

        /// <summary>
        /// 货物签收
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetQSList(string Phone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(State=4 or State=8) and SHPhone='" + Phone + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());

        }
        /// <summary>
        /// 查询-ID
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetGRList(string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@OrderID",OID),
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 接车
        /// </summary>
        /// <param name="CH"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetGDList(int CH, int MDD)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "VehicleID=@VehicleID and State=@State and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",CH),
                new System.Data.SqlClient.SqlParameter("@State","3"),
                new System.Data.SqlClient.SqlParameter("@finish",MDD)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 放货-客户提货信息
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetFHandZZList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(State=5 Or State=7) and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        ///放货-待转货单列表
        /// </summary>
        /// <returns></returns>
        //public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetZZList(string UID)
        //{
        //    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=7 and logisticsID='" + UID+"'");
        //    ids = db.Read(sql);
        //    if (!ids.flag)
        //        return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
        //    if (ids.ReadIsOk())
        //        return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        //    return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        //}
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetOrderList(string FSPhone, string OrderNo)
        {
            if (OrderNo != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(FHPhone='" + FSPhone + "' Or SHPhone='" + FSPhone + "') and OrderID='" + OrderNo + "'");
                ids = db.Read(sql);
            }
            else if (OrderNo == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + FSPhone + "' Or SHPhone='" + FSPhone + "'");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetZCSuccessList(int VehicleNo)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "VehicleID='" + VehicleNo + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 放货-客户提货信息-放货详情
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetFHEditList(string UID, string logisticsID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=5 and logisticsID='" + logisticsID + "' and OrderID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 放货-客户提货信息-未放货库存
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetWFHEditList(string UID, string logisticsID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=8 and logisticsID='" + logisticsID + "' and OrderID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 放货-盘点列表
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetInventoryList(string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=4 and logisticsID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDFHList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "logisticsID='" + UID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 盘点成功
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdateIty(Model.Model.LC_Customer LC_Customer, string OrderID)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID in (" + OrderID + ")");
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "修改失败请重试!");

                var ath = AddToHistory(OrderID, db);
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 收货-历史记录
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetHistoyList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=2 and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 装车-提付
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Gettifu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 装车-现付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getxianfu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 装车-扣付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getkoufu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 接车-提付
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GettifuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 接车-现付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetxianfuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 接车-扣付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetkoufuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }

        /// <summary>
        /// 未放货库存-提付
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GettifuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 未放货库存-现付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetxianfuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 未放货库存-扣付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetkoufuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }

        /// <summary>
        /// 获取收货第一单的时间
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetSHFristTime(string OID, int begins, int finish)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and begins=@begins and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@begins",begins),
                new System.Data.SqlClient.SqlParameter("@finish",finish),
                new System.Data.SqlClient.SqlParameter("@logisticsID",OID)
            }, "ConsigneeTime asc", 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 条件查询：路线
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCityOrderList(string UID, string start, string end)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "logisticsID=@logisticsID and beginUID=@beginUID and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",UID),
                new System.Data.SqlClient.SqlParameter("@beginUID",start),
                new System.Data.SqlClient.SqlParameter("@finishUID",end)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 条件查询：日期
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDateOrderList(string UID, string StartTime, string EndTime)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "ConsigneeTime between '" + StartTime + "' and '" + EndTime + "' and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// New:接车列表
        /// </summary>
        /// <param name="myuservo"></param>
        /// <returns></returns>
        public static (bool, string, object) GetMettCarList(UserLoginVO myuservo)
        {
            new SqlVO(@"select Initially,finish,Count(Freight) as [Count],SUM(Freight) as Freight,SUM(GReceivables) as GReceivables,VehicleID,Sum(largeCar) as largeCar,sum(Number) as number,DriverID,TruckTime from LC_Customer where State=3 and finish=" + myuservo.AreaID + " group by Initially,finish,VehicleID,DriverID,TruckTime").Bind(out SqlVO sql);
            db.Read(sql).Bind(out IDataState ids);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, new
            {
                StartSheng = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).sheng,//开始-省z
                StartShi = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).shi,//开始-市
                StartQu = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).qu,//开始-区
                EndSheng = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).sheng,//结束-省
                EndShi = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).shi,//结束-市
                EndQu = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).qu,//结束-区
                DrivePhone = DALBase.GetDriverPhone(ids.dt.Rows[0]["DriverID"].ConvertData<int>()).Item2.Phone, //司机电话
                VehicleNo = DALBase.GetCarFromID(ids.dt.Rows[0]["VehicleID"].ConvertData<int>()).Item2.VehicleNo, //车牌号
                Count = ids.dt.Rows[0]["Count"],
                GReceivables = ids.dt.Rows[0]["GReceivables"],
                largeCar = ids.dt.Rows[0]["largeCar"],
                number = ids.dt.Rows[0]["number"],
                Freight = ids.dt.Rows[0]["Freight"],
                VehicleID = ids.dt.Rows[0]["VehicleID"],//传值-车号id
                Initially = ids.dt.Rows[0]["Initially"],//传值-出发地
                finish = ids.dt.Rows[0]["finish"],//传值-目的地
                TruckTime=ids.dt.Rows[0]["TruckTime"]
            });
        }
        public static Tuple<bool, string, DataTable> GetPretendCarCount(string UID)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"select begins,finish from LC_Customer where State =@State and begins is not null and finish is not null and logisticsID =@logisticsID group by begins, finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State","2"),
                new System.Data.SqlClient.SqlParameter("@logisticsID",UID)
            });
            ids = db.Read(sql);

            if (!ids.flag)
                return new Tuple<bool, string, DataTable>(false, ids.errormsg, null);
            return new Tuple<bool, string, DataTable>(true, string.Empty, ids.dt);
        }
        /// <summary>
        /// 自主开单
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <returns></returns>
        public static Tuple<bool, string> AutonomyBilling(Model.Model.LC_Customer LC_Customer, UserLoginVO myuservo, bool updateGoodNum = false)
        {
            Model.Model.LC_Customer lcc = null;
            string uid = Tools.NewGuid.GuidTo16String();
            var box = db.CreateTranSandbox<Tuple<bool, string>>((db) =>
            {
                //检查是否创建物流子用户
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZNumber=@ZNumber", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@ZNumber",myuservo.uid)
                },string.Empty,1);
                ids = db.Read(sql);
                if (ids.num == 0)
                {
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_User()
                    {
                        UID = uid,
                        Phone = myuservo.phones,
                        ZNumber = myuservo.uid,
                        ProvincesID = myuservo.ProvincesID,
                        CityID = myuservo.CityID,
                        AreaID = myuservo.AreaID,
                        UserName = myuservo.LogisticsName,
                        ZType=1
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "添加失败请重试!");
                }
                else
                {
                    //读取这个绑定关系的人的数据
                    var _uservo = ids.GetVOList<Model.Model.LC_User>()[0];
                    uid = _uservo.UID;
                }

                LC_Customer.ConsignorID = uid;

                //添加订单
                sql = makesql.MakeInsertSQL(LC_Customer);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "发货失败,请重试!");

                LC_Customer.State = GlobalBLL.OrderStateEnum.已发货.EnumToInt();
                var ath =   AddToHistory(LC_Customer, db); //
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);

                LC_Customer.State = GlobalBLL.OrderStateEnum.物流已收货.EnumToInt();
                ath =  AddToHistory(LC_Customer, db); //
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);

                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            //获取此订单数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",LC_Customer.OrderID)
                    });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string>(false, "没有找到任何订单数据！");
            lcc = ids.GetVOList<Model.Model.LC_Customer>()[0];
            if (updateGoodNum)
            {

                lcc.finish = LC_Customer.finish;
                lcc.begins = LC_Customer.begins;
                if (lcc.GoodNo.StrIsNull())
                {
                    var vo = GetGoodNo(ref lcc);
                    if (vo.Item1)
                        LC_Customer.GoodNo = vo.Item2;
                }
            }
            sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@OrderID",LC_Customer.OrderID)
                });
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "修改失败请重试!");
            return box;
        }
    }
}
