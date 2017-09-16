using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;
namespace Logistics.ApiCommand
{
    /// <summary>
    /// 接车列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetMeetCarList), "接车列表")]
    [SuperCommand.Attribute.InputDoc("finish", "本物流地区")]
    [SuperCommand.Attribute.InputDoc("State", "已装车运输中(3)")]
    public class CMD_GetMeetCarList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Customer.GetMeetCarList(web);
            return Show<TCommandState>(vo);
        }
    }
}