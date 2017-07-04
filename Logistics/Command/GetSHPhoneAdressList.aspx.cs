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
    public partial class GetSHPhoneAdressList : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ShrPhone = GetValue("phone");
            var list = DAL.DAL.DALBase.GetPhoneAdressList(ShrPhone);
            Response.Write(list.ToJson());
            Response.End();
        }
    }
}