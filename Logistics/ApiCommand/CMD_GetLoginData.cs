using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取登录数据
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetLoginData),"获取登录数据")]
    public class CMD_GetLoginData : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = (true, string.Empty, web.GetMyLoginUserVO());
            return Show<TCommandState>(vo);
        }
    }
}