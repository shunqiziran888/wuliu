using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 账号绑定
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_BindUser),"账号绑定")]
    [SuperCommand.Attribute.InputDoc("logistics", "物流公司ID (物流子公司注册需要上传,普通用户绑定需要上传)")]
    [SuperCommand.Attribute.InputDoc("NickName", "昵称必须上传")]
    [SuperCommand.Attribute.InputDoc("phone", "电话号必须上传")]
    [SuperCommand.Attribute.InputDoc("sheng", "省（物流公司注册与普通成员注册需要上传）")]
    [SuperCommand.Attribute.InputDoc("shi", "市（物流公司注册与普通成员注册需要上传）")]
    [SuperCommand.Attribute.InputDoc("qu", "区（物流公司注册与普通成员注册需要上传）")]
    [SuperCommand.Attribute.InputDoc("bindvehicleid","司机绑定的车辆ID，只有公司账号的驾驶员才有效")]
    public class CMD_BindUser : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            (bool, string) vo = BLL.BLL.LC_User.BindUser(web);
            return Show<TCommandState>(vo);
        }
    }
}