using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Customer.Contact
{
    public partial class LC_IndexCt : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertJump("功能暂未开放!", "/LC/Index/LC_IndexKH.aspx");
        }
    }
}