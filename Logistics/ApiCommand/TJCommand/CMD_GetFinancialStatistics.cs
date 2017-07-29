using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.TJCommand
{
    [SuperCommand.Attribute.Doc(typeof(CMD_GetFinancialStatistics),"财务统计")]
    public class CMD_GetFinancialStatistics : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            throw new NotImplementedException();
        }
    }
}