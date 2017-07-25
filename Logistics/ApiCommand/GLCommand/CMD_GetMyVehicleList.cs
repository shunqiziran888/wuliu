using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 获取车辆列表
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetMyVehicleList),"获取我的车辆列表")]
    [SuperCommand.Attribute.InputDoc("page","当前页")]
    [SuperCommand.Attribute.InputDoc("num","每页个数")]
    public class CMD_GetMyVehicleList : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Vehicle.GetMyVehicleList(web);
            return Show<TCommandState>(vo);
        }
    }
}