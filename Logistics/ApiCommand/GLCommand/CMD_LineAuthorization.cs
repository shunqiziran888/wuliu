using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 线路授权
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_LineAuthorization),"线路授权")]
    [SuperCommand.Attribute.InputDoc("id","线路ID")]
    [SuperCommand.Attribute.InputDoc("state","线路状态 0未授权,1已授权")]
    public class CMD_LineAuthorization : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_Line.LineAuthorization(web);
            return Show<TCommandState>(vo);
        }
    }
}