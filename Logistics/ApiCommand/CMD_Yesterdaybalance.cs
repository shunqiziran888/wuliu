using SuperCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 昨日余额
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_Yesterdaybalance), "昨日余额")]
    [SuperCommand.Attribute.InputDoc("logisticsID", "本物流")]
    [SuperCommand.Attribute.InputDoc("State", "订单完成(6)")]
    public class CMD_Yesterdaybalance : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.Yesterdaybalance(web);
            return Show<TCommandState>(vo);
        }
    }
}