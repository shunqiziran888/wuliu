using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// 统计相关
    /// </summary>
    public class StatisticsSys : BLLBase
    {
        /// <summary>
        /// 获取统计数据
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetOperationStatistics(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您没有权限访问此接口!", null);
            DateTime starttime = web.GetValue<DateTime>("starttime");
            DateTime endtime = web.GetValue<DateTime>("endtime");
            string startuid = web.GetValue("startuid"); //开始的物流UID
            string enduid = web.GetValue("enduid"); //结束的物流UID
            return DAL.DAL.StatisticsSys.GetOperationStatistics(myuservo,starttime,endtime,startuid,enduid);
        }

        /// <summary>
        /// 获取财务统计
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetFinancialStatistics(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "财务统计不能为空!", null);
            DateTime starttime = web.GetValue<DateTime>("starttime");
            DateTime endtime = web.GetValue<DateTime>("endtime");
            string startuid = web.GetValue("startuid"); //开始的物流UID
            string enduid = web.GetValue("enduid"); //结束的物流UID
            return DAL.DAL.StatisticsSys.GetFinancialStatistics(myuservo, starttime, endtime, startuid, enduid);
        }
    }
}
