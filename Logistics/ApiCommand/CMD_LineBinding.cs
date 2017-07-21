using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 线路绑定
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_LineBinding),"线路绑定")]
    [SuperCommand.Attribute.InputDoc("logistics","要绑定的物流ID")]
    [SuperCommand.Attribute.InputDoc("lineletter", "货号首字母")]
    public class CMD_LineBinding : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_Line.LineBinding(web);
            return Show<TCommandState>(vo);
        }
    }
}