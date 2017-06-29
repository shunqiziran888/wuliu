using System;
using Model.Model;
using CustomExtensions;

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
    }
}
