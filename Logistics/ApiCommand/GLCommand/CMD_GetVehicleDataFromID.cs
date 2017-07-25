using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 根据ID获取车辆数据
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetVehicleDataFromID),"获取根据车辆数据")]
    public class CMD_GetVehicleDataFromID : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Vehicle.GetVehicleDataFromID(web);
            return Show<TCommandState>(vo);
        }
    }
}