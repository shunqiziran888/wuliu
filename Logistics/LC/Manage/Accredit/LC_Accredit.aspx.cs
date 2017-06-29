using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Manage.Accredit
{
    public partial class LC_Accredit : PageLoginBase
    {
        public List<Model.Model.LC_User> list = new List<Model.Model.LC_User>();
        public List<Model.Model.LC_User> list2 = new List<Model.Model.LC_User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            if (myuservo.accountType != GlobalBLL.AccountTypeEnum.物流账号)
            {
                AlertJump("您没有权限访问此功能", "/LC/Index/LC_IndexGL.aspx");
                return;
            }
            var vo = DAL.DAL.LC_User.GetSQList();
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            var vo2 = DAL.DAL.LC_User.GetSQAllList();
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            list2 = vo2.Item3;
        }
    }
}