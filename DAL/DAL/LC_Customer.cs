using System;
using System.Collections.Generic;
using Model.Model;
using SuperDataBase;
using CustomExtensions;
using System.Data;
using System.Linq;
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
                AddToHistory(LC_Customer,db);
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
        private static (bool,string) AddToHistory(Model.Model.LC_Customer lcc,SuperDataBase.Model.DBSandbox db)
        {
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

        /// <summary>
        /// 把订单列表添加到历史
        /// </summary>
        /// <param name="orderNumberList"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(List<string> orderNumberList, SuperDataBase.Model.DBSandbox db)
        {
            return AddToHistory(orderNumberList.Select(x=>$"'{x}'").ToList().ListToString(), db);
        }

        /// <summary>
        /// 添加历史记录
        /// </summary>
        /// <param name="VehicleID">车辆ID</param>
        /// <param name="nowUid">当前物流公司UID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(int VehicleID,string nowUid, SuperDataBase.Model.DBSandbox db)
        {
            //获取所有订单数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"VehicleID=@VehicleID and finishUID=@finishUID",new System.Data.SqlClient.SqlParameter[] {
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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"OrderID={orderNumberStr}");
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

                 var ath = AddToHistory(cH,UID,db);
                 if (!ath.Item1)
                     return new Tuple<bool, string>(false,ath.Item2);

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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=1 and logisticsID='" + UID + "'");
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
                if (updateGoodNum)
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
                    //添加一个货款数据
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_Payment()
                    {
                        CreateTime = DateTime.Now,
                        LastOperationTime = DateTime.Now,
                        LastState = 1,
                        LocationLogisticsUID = lcc.beginUID,
                        StartLogisticsUID = lcc.logisticsID,
                        OrderNumber = lcc.OrderID,
                        PaymentAllAmount = lcc.Freight + lcc.GReceivables + lcc.OtherExpenses,
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
                    return new Tuple<bool,string>(false, addh.Item2);
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
                    return new Tuple<bool,string>(false, ath.Item2);
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
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + Phone + "'");
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
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "'");
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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=4 and SHPhone='" + Phone + "'");
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
                new System.Data.SqlClient.SqlParameter("@OrderID",OID)
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
        /// 提付
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Gettifu(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer),new string[] { "sum(Freight)" }, "freightMode=1 and logisticsID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 现付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getxianfu(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and logisticsID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
        /// <summary>
        /// 扣付
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getkoufu(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and logisticsID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "没有任何数据!", 0);
        }
    }
}
