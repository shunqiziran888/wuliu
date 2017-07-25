using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.GLCommand
{
    /// <summary>
    /// 车辆绑定
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_VehicleBinding),"车辆绑定")]
    [SuperCommand.Attribute.InputDoc("vehicle_id","车辆ID")]
    [SuperCommand.Attribute.InputDoc("driver_id", "司机ID")]
    public class CMD_VehicleBinding : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_VehicleBinding.Bind(web);
            return Show<TCommandState>(vo);
        }
    }
}