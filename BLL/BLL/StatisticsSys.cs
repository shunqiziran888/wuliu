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

        }
    }
}
