using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 获取员工类型列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetPositionList),"获取员工类型列表")]
    public class CMD_GetPositionList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Position.GetPositionList(web);
            return Show<TCommandState>(vo);
        }
    }
}