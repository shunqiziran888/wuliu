using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取我的线路列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetMyLineList),"获取我的线路列表")]
    public class CMD_GetMyLineList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Line.GetMyLineList(web);
            return Show<TCommandState>(vo);
        }
    }
}