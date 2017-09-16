using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 我的-统计
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetMyCount), " 我的-统计")]
    [SuperCommand.Attribute.InputDoc("logisticsID", "本物流")]
    [SuperCommand.Attribute.InputDoc("State", "订单完成(6)")]
    public class CMD_GetMyCount : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Customer.GetMyCount(web);
            return Show<TCommandState>(vo);
        }
    }
}