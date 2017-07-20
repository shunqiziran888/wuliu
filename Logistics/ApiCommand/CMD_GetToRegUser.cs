using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取是否注册用户
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetToRegUser),"获取是否注册用户")]
    public class CMD_GetToRegUser : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_User.GetToRegUser(web);
            return Show<TCommandState>(vo);
        }
    }
}