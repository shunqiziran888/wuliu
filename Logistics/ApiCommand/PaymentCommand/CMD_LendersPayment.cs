using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.PaymentCommand
{
    /// <summary>
    /// 货款放款
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_LendersPayment),"货款放款")]
    [SuperCommand.Attribute.InputDoc("orderdata", "所有订单数据")]
    public class CMD_LendersPayment : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.LendersPayment(web);
            return Show<TCommandState>(vo);
        }
    }
}