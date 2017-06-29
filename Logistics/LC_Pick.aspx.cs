using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics
{
    public partial class LC_Pick : PageLoginBase
    {
        public LC_Pick() : base(false) { }
        public static List<Model.Model.LC_User> lists=new List<Model.Model.LC_User>();
        protected void Page_Load(object sender, EventArgs e)
        {
           lists = DAL.DAL.LC_User.GetUserList().Item3;
        }
    }
}