using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 员工授权表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetEmployeeEmpowermentList), "员工授权表")]
    [SuperCommand.Attribute.InputDoc("page","当前页")]
    [SuperCommand.Attribute.InputDoc("num","每页个数")]
    public class CMD_GetEmployeeEmpowermentList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_User.GetEmployeeEmpowermentList(web);
            return Show<TCommandState>(vo);
        }
    }
}