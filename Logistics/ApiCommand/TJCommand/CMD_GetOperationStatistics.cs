using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.TJCommand
{
    /// <summary>
    /// 获取运营统计
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetOperationStatistics),"获取运营统计")]
     [SuperCommand.Attribute.InputDoc("starttime", "开始时间")]
     [SuperCommand.Attribute.InputDoc("endtime", "结束时间")]
     [SuperCommand.Attribute.InputDoc("startuid", "开始的物流UID")]
     [SuperCommand.Attribute.InputDoc("enduid", "结束的物流UID")]
    public class CMD_GetOperationStatistics : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.StatisticsSys.GetOperationStatistics(web);
            return Show<TCommandState>(vo);
        }
    }
}