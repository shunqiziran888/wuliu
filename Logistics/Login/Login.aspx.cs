using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;
using CustomExtensions;

namespace Logistics.Login
{
    public partial class Login : PageLoginBase
    {
        //public List<string> vv = new List<string>();
        //public string kk { get; set; }

        public Login() : base(false) { }
        protected void Page_Load(object sender, EventArgs e)
        {
                if (IsPostBack)
                {
                    string name = GetValue("ZNumber");
                    string pwd = GetValue("Password");

                    Tuple<bool, string, Model.Model.LC_User> vo = DAL.DAL.LC_User.Login(name, pwd);
                if (!vo.Item1)
                {
                    ReturnPager("手机号或密码错误！");
                    return;
                }
                    SetSession("islogin", "true");
                    SetSession("account", vo.Item3.ZNumber);
                    SetSession("accountType", vo.Item3.ZType);
                    SetSession("id", vo.Item3.ID);
                    SetSession("positionID", vo.Item3.PositionID);
                    SetSession("state", vo.Item3.State);
                    SetSession("uid", vo.Item3.UID);
                    SetSession("username", vo.Item3.UserName);
                    SetSession("phones", vo.Item3.Phone);
                    SetSession("ProvincesID", vo.Item3.ProvincesID);
                    SetSession("CityID", vo.Item3.CityID);
                    SetSession("AreaID", vo.Item3.AreaID);

                    int actype = Convert.ToInt32(vo.Item3.ZType);
                    //物流总公司
                    if (actype == 1)
                    {
                        Jump("/LC/Index/LC_Index.aspx");
                    }
                    //物流公司员工
                    else if (actype == 4)
                    {
                        Jump("/LC/Index/LC_Index.aspx");
                    }
                    //客户
                    else if (actype == 3)
                    {
                        Jump("/LC/Index/LC_IndexKH.aspx");
                    }
                }
        }
    }
}