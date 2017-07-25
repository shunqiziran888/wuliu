using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 添加车辆
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_AddVehicle),"添加车辆(司机与物流公司都可以使用)")]
    [SuperCommand.Attribute.InputDoc("VehicleNo", "车号")]
    [SuperCommand.Attribute.InputDoc("Driver", "司机名字")]
    [SuperCommand.Attribute.InputDoc("Carshape", "车长")]
    [SuperCommand.Attribute.InputDoc("Phone", "电话")]
    public class CMD_AddVehicle : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_Vehicle.AddVehicle(web);
            return Show<TCommandState>(vo);
        }
    }
}