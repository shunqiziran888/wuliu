using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 获取地区下一级联动
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetAddressNextList), "获取地区下一级联动")]
    [SuperCommand.Attribute.InputDoc("id","当前地区的ID")]
    public class CMD_GetAddressNextList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public CMD_GetAddressNextList() : base(false) { }
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            int id = web.GetValue<int>("id");
            if (id <= 0)
                return Show<TCommandState>((false, "ID参数错误!"));
            var list = DAL.DAL.DALBase.GetNextAddressListFromId(id);
            return Show<TCommandState>((true, string.Empty, list));
        }
    }
}