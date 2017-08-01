using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand.PaymentCommand
{
    /// <summary>
    /// 获取货款记录
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_GetPaymentRecording),"获取货款记录")]
    [SuperCommand.Attribute.InputDoc("state", "筛选状态( 0未处理（不可用）,1已回收(可用）)")]
    [SuperCommand.Attribute.InputDoc("starttime","开始时间")]
    [SuperCommand.Attribute.InputDoc("endtime","结束时间")]
    [SuperCommand.Attribute.InputDoc("startuid","开始的物流公司UID")]
    [SuperCommand.Attribute.InputDoc("enduid", "结束的物流公司UID")]
    [SuperCommand.Attribute.InputDoc("page","当前页")]
    [SuperCommand.Attribute.InputDoc("num","每页个数")]
    [SuperCommand.Attribute.InputDoc("orderlist", "订单列表")]
    [SuperCommand.Attribute.InputDoc("HKDetail", "放款列表时使用(传入have字符串)")]
    
    public class CMD_GetPaymentRecording : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string, object) vo = BLL.BLL.LC_Payment.GetPaymentRecording(web);
            return Show<TCommandState>(vo);
        }
    }
}