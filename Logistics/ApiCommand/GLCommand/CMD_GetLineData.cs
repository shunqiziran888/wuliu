using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 获取线路数据
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetLineData),"获取线路数据")]
    [SuperCommand.Attribute.InputDoc("id","传入的线路ID")]
    public class CMD_GetLineData : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Line.GetLineData(web);
            return Show<TCommandState>(vo);
        }
    }
}