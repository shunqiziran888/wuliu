using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.LC.Manage.Line
{
    public partial class LC_CooperationRoute : PageLoginBase
    {
        public LC_CooperationRoute() : base(false) { }
        protected void Page_Load(object sender, EventArgs e)
        {

            string myLineletter = GetValue("Lineletter");
            if (myLineletter.StrIsNotNull())
            {
                //接收要绑定的物流Uid
                string bindUid = GetValue("binduid");
                if (bindUid.StrIsNull())
                {
                    Alert("绑定UID不能为空!");
                    return;
                }
                string ZNumber = GetValue("ZNumber");
                string pwd = GetValue("Pwd");
                string bindLineletter = GetValue("xl");

                if (myLineletter.StrIsNull())
                {
                    Alert("请选择一个物流运号首字母!");
                    return;
                }
                if(bindLineletter.StrIsNull())
                {
                    Alert("对方物流运号参数有误!");
                    return;
                }
                if (ZNumber.StrIsNull())
                {
                    Alert("账号不能为空!");
                    return;
                }
                if(pwd.StrIsNull())
                {
                    Alert("密码不能为空!");
                    return;
                }
                //Tools.PinYinConverter.GetFirst();
                Tuple<bool,string> vo = BLL.BLL.LC_Line.BindHZ(ZNumber,pwd,bindUid, myLineletter, bindLineletter);
                if(!vo.Item1)
                {
                    Alert(vo.Item2);
                }
                else
                {
                    AlertJump("绑定成功!", "LC/Manage/Line/LC_Line.aspx");

                }
            }


        }
    }
}