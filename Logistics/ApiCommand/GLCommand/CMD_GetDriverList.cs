using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 获取驾驶员列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetDriverList),"获取驾驶员列表")]
    public class CMD_GetDriverList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_User.GetDriverList(web);
            return Show<TCommandState>(vo);
        }
    }
}