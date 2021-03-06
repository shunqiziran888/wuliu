﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;
namespace Logistics.ApiCommand
{
    /// <summary>
    /// 收欠款
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetCollectDebts), "收欠款")]
    [SuperCommand.Attribute.InputDoc("page", "当前页")]
    [SuperCommand.Attribute.InputDoc("num", "每页个数")]
    public class CMD_GetCollectDebts : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Customer.GetCollectDebts(web);
            return Show<TCommandState>(vo);
        }
    }
}