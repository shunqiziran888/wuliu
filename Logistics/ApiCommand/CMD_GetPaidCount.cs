using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.PaymentCommand
{
    /// <summary>
    /// 上缴统计
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetPaidCount),"上缴统计")]
    [SuperCommand.Attribute.InputDoc("state", "筛选状态( 0未处理（不可用）,1已回收(可用）)")]
    [SuperCommand.Attribute.InputDoc("page", "当前页")]
    [SuperCommand.Attribute.InputDoc("num", "每页个数")]
    [SuperCommand.Attribute.InputDoc("HKDetail", "放款列表时使用(传入have字符串)")]
    public class CMD_GetPaidCount : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.GetPaidCount(web);
            return Show<TCommandState>(vo);
        }
    }
}