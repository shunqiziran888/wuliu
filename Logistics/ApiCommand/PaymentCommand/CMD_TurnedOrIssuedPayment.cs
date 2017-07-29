using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.PaymentCommand
{
    /// <summary>
    /// 上缴货款或放款
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_TurnedOrIssuedPayment),"上缴货款或放款")]
    [SuperCommand.Attribute.InputDoc("orderlist", "要操作的数据列表(是JSON格式)")]
    [SuperCommand.Attribute.InputDoc("model", "1为上缴,2为回收")]
    public class CMD_TurnedOrIssuedPayment : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_Payment.TurnedOrRecoveryPayment(web);
            return Show<TCommandState>(vo);
        }
    }
}