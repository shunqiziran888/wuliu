using System;
using CustomExtensions;
using GlobalBLL;

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

        public static (bool, string, object) GetMyCount(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            DateTime AweekDate = web.GetValue<DateTime>("AweekDate");
            DateTime fristtime = DateTime.Now.ToString("yyyy-MM-01 00:00:00").ConvertData<DateTime>();//昨天开始时间
            DateTime lasttime = fristtime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 23:59:59").ConvertData<DateTime>();//昨天结束时间
            return DAL.DAL.LC_Customer.GetMyCount(myuservo, AweekDate, fristtime, lasttime);
        }

        public static (bool, string, object) GetMeetCarList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            return DAL.DAL.LC_Customer.GetMettCarList(myuservo);
        }

        public static (bool, string, object) GetCollectDebtsDetailTop(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            string SHPhone = web.GetValue("SHPhone");
            return DAL.DAL.LC_Customer.GetCollectDebtsDetailTop(myuservo, SHPhone);
        }

        public static (bool, string, object) GetCollectDebtsEdit(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            string OID = web.GetValue("OID");
            return DAL.DAL.LC_Customer.GetCollectDebtsEdit(myuservo, OID);
        }

        public static (bool, string, object) GetCollectDebtsDetail(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            string SHPhone = web.GetValue("SHPhone");
            return DAL.DAL.LC_Customer.GetCollectDebtsDetail(myuservo,SHPhone);
        }

        public static (bool, string, object) GetCollectDebts(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);

            return DAL.DAL.LC_Customer.GetCollectDebts(myuservo);
        }
    }
}
