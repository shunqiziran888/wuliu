using System;
using System.Collections.Generic;
using Model.Model;
using CustomExtensions;
using GlobalBLL;
using SuperDataBase.InterFace;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Vehicle : DALBase
    {
        public LC_Vehicle()
        { }
        public static Tuple<bool, string, List<Model.Model.LC_Vehicle>> GetVehList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle),"UID='"+UID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Vehicle>());
            return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, "没有任何数据!", new List<Model.Model.LC_Vehicle>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Vehicle>> GetDetailList(int ID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle), "ID='"+ID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Vehicle>());
            return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, "没有任何数据!", new List<Model.Model.LC_Vehicle>());
        }

        /// <summary>
        /// 根据ID获取车辆数据
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static (bool, string, object) GetVehicleDataFromID(UserLoginVO myuservo, long id)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle), "ID=@ID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@ID",id)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (false, "没有获取到任何数据!", null);
            Model.Model.LC_Vehicle lcv = ids.GetVOList<Model.Model.LC_Vehicle>()[0];
            if (!lcv.UID.Equals(myuservo.uid, StringComparison.OrdinalIgnoreCase))
                return (false, "此车辆不在您的管辖范围内，无法进行查阅!", null);

            List<Dictionary<string, I_ModelBase>> lcc_list = new List<Dictionary<string, I_ModelBase>>();
            //获取数据
            sql = makesql.MakeSelectArrSql(new Type[] { typeof(Model.Model.LC_VehicleBinding),typeof(Model.Model.LC_User) }, "{0}.DriverUID={1}.UID and {0}.VehicleID=@VehicleID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",id)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (ids.ReadIsOk())
            {
                lcc_list = ids.GetVOList(new Type[] { typeof(Model.Model.LC_VehicleBinding), typeof(Model.Model.LC_User) });
            }

            return (true, string.Empty, new
            {
                lcv,
                lcc_list
            });
        }

        public static (bool, string, object) GetMyVehicleList(UserLoginVO myuservo, int page, int num)
        {
            fysql = makesql.MakeSelectFY(typeof(Model.Model.LC_Vehicle), "UID=@UID", "id asc", page, num, "id", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@UID",myuservo.uid)
            });
            ids = db.Read(fysql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new
                {
                    allcount = fysql.count,
                    data = new object[] { }
                });
            return (true, string.Empty, new
            {
                allcount = fysql.count,
                data = ids.GetVOList<Model.Model.LC_Vehicle>()
            });
        }

        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="lcv"></param>
        /// <returns></returns>
        public static (bool, string) AddVehicle(UserLoginVO myuservo, Model.Model.LC_Vehicle lcv)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                Model.Model.LC_User wl_yg_uservo = null;
                string logistics_uid = myuservo.uid;
                switch (myuservo.accountType)
                {
                    case AccountTypeEnum.物流公司员工账号:
                        //获取当前员工账号数据
                        var myuser = GetUserVoFromUID(myuservo.uid);
                        if (!myuser.Item1)
                            return (false, myuser.Item2);
                        if (myuser.Item3.PositionID != 1)
                            return (false, "当前账号不是驾驶员,无法访问此接口!");
                        logistics_uid = myuser.Item3.LCID;
                        wl_yg_uservo = myuser.Item3;
                        break;
                }
                lcv.UID = logistics_uid;
                //查看车号是否存在
                sql = makesql.MakeCount(nameof(Model.Model.LC_Vehicle), "VehicleNo=@VehicleNo and UID=@UID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleNo",lcv.VehicleNo),
                    new System.Data.SqlClient.SqlParameter("@UID",logistics_uid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "已经存在相同车号车辆,无法进行添加!");
                //插入数据库
                sql = makesql.MakeInsertSQL(lcv);
                ids = db.Exec(sql,true);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "添加车辆失败!");

                long index = ids.index_id;

                if(myuservo.accountType== AccountTypeEnum.物流公司员工账号)
                {
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_VehicleBinding()
                    {
                        BindingTime = DateTime.Now,
                        DriverUID = logistics_uid,
                        VehicleID = index
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if (!ids.ExecOk())
                        return (false, "绑定司机失败!");
                }

                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        public static Tuple<bool, string> Add(Model.Model.LC_Vehicle LC_Vehicle)
        {
            sql = makesql.MakeInsertSQL(LC_Vehicle);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "添加失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }

        public static Dictionary<int, Model.Model.LC_Vehicle> GetAllCar()
        {
            Dictionary<int, Model.Model.LC_Vehicle> vlist = new Dictionary<int, Model.Model.LC_Vehicle>();
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle));
            ids = db.Read(sql);
            foreach (var x in ids.GetVOList<Model.Model.LC_Vehicle>())
            {
                vlist.Add(x.ID.ConvertData<int>(), x);
            }
            return vlist;
        }
    }
}
