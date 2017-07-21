using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 退出系统
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_OutSystem),"退出系统")]
    public class CMD_OutSystem : WebCommandBase, ICommandBase<WebCommandVOBase>
    {
        public CMD_OutSystem():base(false){ }

        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            web.SessionClear();
            return Show<TCommandState>((true, string.Empty));
        }
    }
}