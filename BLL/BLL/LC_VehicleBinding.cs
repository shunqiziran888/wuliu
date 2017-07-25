using System;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// 物流车辆绑定表
    /// </summary>
    [Serializable]
    public partial class LC_VehicleBinding : BLLBase
    {
        public LC_VehicleBinding()
        {}

        public static (bool, string) Bind(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!");
            long vehicle_id = web.GetValue<long>("vehicle_id");
            //车辆绑定
            if (vehicle_id <= 0)
                return (false, "车辆ID参数错误!");
            long driver_id = web.GetValue<long>("driver_id");
            if (driver_id <= 0)
                return (false, "请选择一个司机!");

            return DAL.DAL.LC_VehicleBinding.Bind(myuservo, vehicle_id, driver_id);
        }
    }
}
