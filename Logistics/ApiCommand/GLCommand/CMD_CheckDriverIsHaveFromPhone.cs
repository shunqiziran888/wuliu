using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 根据电话检测车辆是否存在
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_CheckDriverIsHaveFromPhone),"根据电话检测车辆是否存在")]
    [SuperCommand.Attribute.InputDoc("phone","电话号码")]
    public class CMD_CheckDriverIsHaveFromPhone : WebCommandBase, ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_User.CheckDriverIsHaveFromPhone(web);
            return Show<TCommandState>(vo);
        }
    }
}