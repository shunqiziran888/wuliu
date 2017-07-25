using System;
using GlobalBLL;
using CustomExtensions;
namespace DAL.DAL
{
    /// <summary>
    /// 物流车辆绑定表
    /// </summary>
    [Serializable]
    public partial class LC_VehicleBinding : DALBase
    {
        public LC_VehicleBinding()
        {}

        /// <summary>
        /// 车辆绑定
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="vehicle_id"></param>
        /// <param name="driver_id"></param>
        /// <returns></returns>
        public static (bool, string) Bind(UserLoginVO myuservo, long vehicle_id, long driver_id)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //获取司机数据
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "id=@id", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@id",driver_id)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "没有获取到任何司机数据!");
                var lcu_vo = ids.GetVOList<Model.Model.LC_User>()[0];
                if (lcu_vo.PositionID.ConvertData<GlobalBLL.PositionEnum>() != PositionEnum.驾驶员)
                    return (false, "绑定错误,您只能绑定驾驶员账号");
                if (lcu_vo.State != 1)
                    return (false, "此司机账号还没有通过授权,无法进行绑定!");

                //查看此车是否已经绑定过此用户
                sql = makesql.MakeCount(nameof(Model.Model.LC_VehicleBinding), "VehicleID=@VehicleID and DriverUID=@DriverUID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@DriverUID",lcu_vo.UID),
                    new System.Data.SqlClient.SqlParameter("@VehicleID",vehicle_id)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "此车已经绑定过当前司机了,无法重复绑定!");

                //开始绑定
                sql = makesql.MakeInsertSQL(new Model.Model.LC_VehicleBinding()
                {
                    BindingTime = DateTime.Now,
                    DriverUID = lcu_vo.UID,
                    VehicleID = vehicle_id
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "绑定失败请重试!");
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }
    }
}
