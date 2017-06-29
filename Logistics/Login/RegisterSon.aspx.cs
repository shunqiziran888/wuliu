using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Login
{
    public partial class RegisterSon : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    //开始注册
                    Tuple<bool, string> vo = BLL.BLL.LC_User.Add(new Model.Model.LC_User()
                    {
                        UserName = GetValue("UserName"),
                        CreateTime = DateTime.Now,
                        Password = GetValue("Password"),
                        Phone = GetValue("Phone"),
                        PositionID = GetValue<int>("PositionID"),
                        UID = Tools.NewGuid.GuidTo16String(),
                        ZNumber = GetValue("Phone"),
                        ZType = 2,
                        State = 0
                    });

                    if (vo.Item1)
                    {
                        AlertJump("注册成功...返回登录", "/Login/Login.aspx");
                    }
                    else
                    {
                        Alert(vo.Item2);
                    }
                }
                catch (Exception)
                {
                    AlertJump("注册账号时失败,请重试!", "/Login/Register.aspx");
                }
            }
        }
    }
}