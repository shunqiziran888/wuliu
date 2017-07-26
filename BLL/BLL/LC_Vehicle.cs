using System;
using Model.Model;
using CustomExtensions;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Vehicle : BLLBase
    {
        public LC_Vehicle()
        { }
        public static Tuple<bool, string> Add(Model.Model.LC_Vehicle LC_Vehicle)
        {
            if (LC_Vehicle.VehicleNo.StrIsNull())
                return new Tuple<bool, string>(false, "请填写车牌号！");
            if (LC_Vehicle.Driver.StrIsNull())
                return new Tuple<bool, string>(false, "请填写司机！");
            return DAL.DAL.LC_Vehicle.Add(LC_Vehicle);
        }

        /// <summary>
        /// 根据ID获取车辆数据
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetVehicleDataFromID(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            long id = web.GetValue<long>("id"); //车辆ID
            if (id <= 0)
                return (false, "ID参数错误!", null);
            return DAL.DAL.LC_Vehicle.GetVehicleDataFromID(myuservo,id);
        }

        public static (bool, string, object) GetMyVehicleList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的账号没有权限访问此接口!", null);
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            if (page <= 0)
                page = 1;
            if (num <= 0)
                num = 1000;
            return DAL.DAL.LC_Vehicle.GetMyVehicleList(myuservo, page, num);
        }

        /// <summary>
        /// 添加车辆
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) AddVehicle(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            switch(myuservo.accountType)
            {
                case AccountTypeEnum.物流账号:
                case AccountTypeEnum.物流公司员工账号:
                    Model.Model.LC_Vehicle lcv = new Model.Model.LC_Vehicle()
                    {
                        Carshape = web.GetValue<float>("Carshape"),
                        CreateTime = DateTime.Now,
                        Driver = web.GetValue("Driver"),
                        VehicleNo = web.GetValue("VehicleNo"),
                        Phone = web.GetValue("Phone"),
                        State = 1
                    };
                    if (lcv.VehicleNo.StrIsNull())
                        return (false, "车号不能为空!");
                    if (lcv.Carshape <= 0)
                        return (false, "车辆长度不能为空!");
                    if (lcv.Driver.StrIsNull())
                        return (false, "司机姓名不能为空!");
                    if (lcv.Driver.StrIsNull())
                        return (false, "司机电话不能为空!");

                    return DAL.DAL.LC_Vehicle.AddVehicle(myuservo,lcv);
                default:
                    return (false, "您没有权限访问此接口!");
            }
        }
    }
}
