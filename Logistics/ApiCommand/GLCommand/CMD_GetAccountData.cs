using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 获取账号数据
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetAccountData),"获取账号数据")]
    [SuperCommand.Attribute.InputDoc("id","账号ID")]
    public class CMD_GetAccountData : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_User.GetAccountData(web);
            return Show<TCommandState>(vo);
        }
    }
}