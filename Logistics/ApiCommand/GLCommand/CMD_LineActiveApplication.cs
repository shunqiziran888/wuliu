using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 线路主动申请
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_LineActiveApplication),"线路主动申请")]
     [SuperCommand.Attribute.InputDoc("Lineletter", "运号字母")]
     [SuperCommand.Attribute.InputDoc("phone", "电话")]
    public class CMD_LineActiveApplication : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_Line.LineActiveApplication(web);
            return Show<TCommandState>(vo);
        }
    }
}