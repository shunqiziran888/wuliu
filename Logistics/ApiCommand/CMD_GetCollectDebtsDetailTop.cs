﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;
namespace Logistics.ApiCommand
{
    /// <summary>
    /// 收欠款详情上面部分
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetCollectDebtsDetailTop), "收欠款详情上面部分")]
    [SuperCommand.Attribute.InputDoc("page", "当前页")]
    [SuperCommand.Attribute.InputDoc("num", "每页个数")]
    [SuperCommand.Attribute.InputDoc("SHPhone", "收货人手机号")]
    public class CMD_GetCollectDebtsDetailTop : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Customer.GetCollectDebtsDetailTop(web);
            return Show<TCommandState>(vo);
        }
    }
}