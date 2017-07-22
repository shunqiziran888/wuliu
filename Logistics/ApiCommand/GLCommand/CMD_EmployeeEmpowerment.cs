using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 员工授权
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_EmployeeEmpowerment),"员工授权")]
    [SuperCommand.Attribute.InputDoc("id","授权收据ID")]
    [SuperCommand.Attribute.InputDoc("state", "审核中 = 0,正常 = 1,冻结 = 2,封号 = 3")]
    public class CMD_EmployeeEmpowerment : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_User.EmployeeEmpowerment(web);
            return Show<TCommandState>(vo);
        }
    }
}