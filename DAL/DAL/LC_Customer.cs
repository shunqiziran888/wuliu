using System;
using System.Collections.Generic;
using Model.Model;
using SuperDataBase;
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
            sql = makesql.MakeInsertSQL(LC_Customer);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "添加失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }

        /// <summary>
        /// 更新物流接车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cH"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdateMC(long id, int cH,string UID)
        {
            var box = db.CreateTranSandbox<Tuple<bool,string>>((db) =>
            {
                var uservo =  GetUserVoFromId(id, db);
                if (!uservo.Item1)
                    return new Tuple<bool, string>(false, uservo.Item2);

                #region 更新订单已经到达终点的订单
                sql = makesql.MakeUpdateSQL(new Model.Model.LC_Customer()
                {
                    State = 4,
                    logisticsID = UID
                }, "Destination=finish and VehicleID=@VehicleID and State=3", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH)
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
                }, "Destination<>finish and VehicleID=@VehicleID and State=3", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                #endregion

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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=1 and logisticsID='" + UID+"'");
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
        /// <returns></returns>
        public static Tuple<bool, string> Update(Model.Model.LC_Customer LC_Customer,string OrderID)
        {
            sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID='"+OrderID+"'");
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "修改失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
        /// <summary>
        /// 装车：列表查询
        /// </summary>
        /// <param name="Initially"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCmdList(string UID,int sta,int end)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=2 and logisticsID='" + UID+ "' and begins=" + sta+ " and finish=" + end+"");
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
            sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID in (" + OrderID + ")");
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "修改失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }

        /// <summary>
        /// 接车：查询列表
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="AreaID">当前物流所在地区ID</param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetMCList(string UID,int AreaID)
        {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=3 and finish=@finish",new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@finish",AreaID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
                if (ids.ReadIsOk())
                    return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 发货历史列表
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGList(string Phone)
        {
            //两表查询
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='"+Phone+"'");
            ids = db.Read(sql);
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
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGSHList(string Phone)
        {
            //两表查询
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "'");
            ids = db.Read(sql);
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
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetSGList(string Phone,string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and OrderID='"+OID+"'");
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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=4 and SHPhone='"+Phone+"'");
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
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID",new System.Data.SqlClient.SqlParameter[] {
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
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetGDList(int CH)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "VehicleID=@VehicleID and State=@State", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",CH),
                new System.Data.SqlClient.SqlParameter("@State","3")
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// 放货-待送货单列表
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetFHList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=5 and logisticsID='" + UID+"'");
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
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetZZList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=7 and logisticsID='" + UID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());
        }
    }
}
