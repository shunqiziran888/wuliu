using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL.VO
{
    /// <summary>
    /// 货款统计
    /// </summary>
    public class FinancialStatisticsVO
    {
        #region 货款统计
        /// <summary>
        /// 上缴汇总
        /// </summary>
        public long ShangJiaoHuiZong { get; set; } = 0;

        /// <summary>
        /// 未上缴汇总
        /// </summary>
        public long WeiShangJiaoHuiZong { get; set; } = 0;

        /// <summary>
        /// 回收汇总
        /// </summary>
        public long HuiShouHuiZong { get; set; } = 0;

        /// <summary>
        /// 未回收汇总
        /// </summary>
        public long WeiHuiShouHuiZong { get; set; } = 0;
        #endregion

        #region 运费统计
        /// <summary>
        /// 已结算运费
        /// </summary>
        public long YiJieSuanYunFei { get; set; } = 0;
        /// <summary>
        /// 未结算运费
        /// </summary>
        public long WeiJieSuanYunFei { get; set; } = 0;
        /// <summary>
        /// 大车运费
        /// </summary>
        public long DaCheYunFei { get; set; } = 0;

        /// <summary>
        /// 运费余额
        /// </summary>
        public long YunFeiYuE { get; set; } = 0;
        #endregion

        #region 放款统计
        /// <summary>
        /// 
        /// </summary>
        public long FangKuanZongShu { get; set; } = 0;
        /// <summary>
        /// 已放款总数
        /// </summary>
        public long YiFangKuanZongShu { get; set; } = 0;
        /// <summary>
        /// 未放款总数
        /// </summary>
        public long WeiFangKuanZongShu { get; set; } = 0;

        /// <summary>
        /// 贷款余额
        /// </summary>
        public long DaiKuanYuE { get; set; } = 0;
        #endregion

        #region 客户统计
        /// <summary>
        /// 代收客户【发货订单里存在代收就是代收用户】
        /// </summary>
        public long DaiShouKeHu { get; set; } = 0;
        /// <summary>
        ///  未代收客户【订单中未出现代收就不是代收用户】
        /// </summary>
        public long WeiDaiShouKeHu { get; set; } = 0;
        #endregion

    }
}
