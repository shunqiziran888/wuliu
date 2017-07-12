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

namespace Logistics.Command
{
    public partial class RegisterUserBinding : PageLoginBase
    {
        public List<Model.Model.LC_User> list = new List<Model.Model.LC_User>();
        public RegisterUserBinding() : base(false) { }
        protected void Page_Load(object sender, EventArgs e)
        {
            string Phone = GetValue("Phone");
            var list = DAL.DAL.DALBase.GetUserBindingsList(Phone);
            Response.Write(list.ToJson());
            Response.End();
        }
    }
}