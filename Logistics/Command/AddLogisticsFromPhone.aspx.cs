using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Command
{
    /// <summary>
    /// 根据电话添加物流
    /// </summary>
    public partial class AddLogisticsFromPhone : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            Tuple<bool, string> vo = new Tuple<bool, string>(false, "绑定失败!");
            string phone = GetValue("phone");
            if(phone.StrIsNotNull() && phone.Length==11)
            {
                vo = BLL.BLL.LC_UserBindLogisticsList.UserAddFromPhone(myuservo,phone);
            }
            else
            {
                vo = new Tuple<bool, string>(false, "电话号码格式不正确!");
            }
            Response.Write(vo.ToJson());
            Response.End();
        }
    }
}