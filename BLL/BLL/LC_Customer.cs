using System;
using CustomExtensions;
namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Customer : BLLBase
    {
        public LC_Customer()
        {}

        public static Tuple<bool, string> Add(Model.Model.LC_Customer LC_Customer)
        {
            if (LC_Customer.Consignee.StrIsNull())
                return new Tuple<bool, string>(false, "请填写收货人");
            if (LC_Customer.logisticsID.Equals(0))
                return new Tuple<bool, string>(false, "请选择物流！");
            if (LC_Customer.SHPhone.StrIsNull())
                return new Tuple<bool, string>(false, "请填写收获人电话！");
            if (LC_Customer.Destination.Equals(0))
                return new Tuple<bool, string>(false,"请选择目的地！");
            if (LC_Customer.freightMode.Equals(0))
                return new Tuple<bool, string>(false,"请选择付费方式！");
            if (LC_Customer.GoodName.StrIsNull())
                return new Tuple<bool, string>(false,"请填写货物名称！");
            if (LC_Customer.Number.Equals(0))
                return new Tuple<bool, string>(false,"请填写件数！");
            if (LC_Customer.GReceivables.Equals(0))
                return new Tuple<bool, string>(false,"请填写代收款");
            if (LC_Customer.CarryGood.Equals(0))
                return new Tuple<bool, string>(false,"请选择提货方式");
            if (LC_Customer.ReceiptGood.Equals(0))
                return new Tuple<bool, string>(false, "请选择收货方式！");
            return DAL.DAL.LC_Customer.Add(LC_Customer);
        }
    }
}
