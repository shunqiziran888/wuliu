using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;
namespace Logistics.ApiCommand
{
    /// <summary>
    /// 日结账
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_PaymentDay), "日结账")]
    [SuperCommand.Attribute.InputDoc("logisticsID", "本物流")]
    [SuperCommand.Attribute.InputDoc("State", "订单完成(6)")]
    public class CMD_PaymentDay : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.GetPaymentDay(web);
            return Show<TCommandState>(vo);
        }
    }
}