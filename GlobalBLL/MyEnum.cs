using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL
{
    /// <summary>
    /// 账号类型
    /// </summary>
    public enum AccountTypeEnum
    {
        普通用户账号 = 3,
        物流账号 = 1,
        平台账号 = 2
    }

    public enum YFFSEnum
    {
        提付 = 1,
        现付 = 2,
        扣付 = 3
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStateEnum
    {
        已发货=1,
        已收货=2,
        已装车=3,
        已到货=4,
        客户取货=5,
        订单完成=6,
        已中转=7
    }
    public enum THFSEnum
    {
        客户自提=1,
        送货上门=2
    }
    public enum SHFSENum
    {
        我方去送 = 1,
        物流来提 = 2
    }
}
