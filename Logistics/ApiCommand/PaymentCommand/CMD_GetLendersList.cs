using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.PaymentCommand
{
    /// <summary>
    /// 获取放款记录列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetLendersList),"获取放款记录列表")]
    [SuperCommand.Attribute.InputDoc("page","当前页")]
    [SuperCommand.Attribute.InputDoc("num","每页个数")]
    public class CMD_GetLendersList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.GetLendersList(web);
            return Show<TCommandState>(vo);
        }
    }
}