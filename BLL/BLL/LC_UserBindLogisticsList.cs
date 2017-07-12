using System;
using Model.Model;
using CustomExtensions;
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
    }
}
