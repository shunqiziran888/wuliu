using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取我的登录数据
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetMyLoginData), "获取我的登录数据")]
    public class CMD_GetMyLoginData : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            var myusrvo = web.GetMyLoginUserVO();
            return Show<TCommandState>(myusrvo);
        }
    }
}