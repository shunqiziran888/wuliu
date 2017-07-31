using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL.VO
{
    /// <summary>
    /// 运营统计
    /// </summary>
    public class OperationStatisticsVO
    {
#region 货单统计
        /// <summary>
        /// 接单数
        /// </summary>
        public long HDTJ_JieDanShu { get; set; } = 0;
        
        /// <summary>
        /// 运输单数
        /// </summary>
        public long HDTJ_YunShuDanShu { get; set; } = 0;
        
        /// <summary>
        /// 库存单数
        /// </summary>
        public long HDTJ_KuCunDanShu { get; set; } = 0;

        /// <summary>
        /// 接完货单
        /// </summary>
        public long HDTJ_JieWanHuoDan { get; set; } = 0;

        #endregion
        #region 件数统计
        /// <summary>
        /// 接单数
        /// </summary>
        public long JieJianNumber { get; set; } = 0;

        /// <summary>
        /// 运输总件数
        /// </summary>
        public long YunShuZongJianShu { get; set; } = 0;

        /// <summary>
        /// 库存件数
        /// </summary>
        public long KuCunJianShu { get; set; } = 0;

        /// <summary>
        /// 接完件数
        /// </summary>
        public long JieWanJianShu { get; set; } = 0;

        #endregion

        #region 车次统计
        /// <summary>
        /// 接车车数
        /// </summary>
        public long JieCheCheShu { get; set; } = 0;
        /// <summary>
        /// 运输总数
        /// </summary>
        public long YunShuZongShu { get; set; } = 0;

        /// <summary>
        /// 汇总车次(已经接车和发车的)
        /// </summary>
        public long HuiCheTongJi { get; set; } = 0;
        #endregion

        #region 客户统计
        /// <summary>
        /// 发货客户
        /// </summary>
        public long FaHuoKeHu { get; set; } = 0;
        /// <summary>
        /// 收货客户
        /// </summary>
        public long SuoHuoKeHu { get; set; } = 0;
        #endregion
    }
}
