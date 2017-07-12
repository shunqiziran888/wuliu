using System;
using Model.Model;
using CustomExtensions;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// 绑定物流表
    /// </summary>
    [Serializable]
    public partial class LC_UserBindLogisticsList : BLLBase
    {
        public LC_UserBindLogisticsList()
        {}
        public static Tuple<bool, string> UserAdd(Model.Model.LC_UserBindLogisticsList LC_UserBindLogisticsLis)
        {
            return DAL.DAL.LC_UserBindLogisticsList.UserAdd(LC_UserBindLogisticsLis);
        }
        /// <summary>
        /// 根据电话添加物流
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="phone">电话号码</param>
        /// <returns></returns>

        public static Tuple<bool, string> UserAddFromPhone(UserLoginVO myuservo,string phone)
        {
            if (myuservo.accountType != AccountTypeEnum.普通用户账号)
                return new Tuple<bool, string>(false, "您的账号权限无法添加物流!");
            return DAL.DAL.LC_UserBindLogisticsList.UserAddFromPhone(myuservo, phone);
        }
    }
}
