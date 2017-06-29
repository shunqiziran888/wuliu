using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logistics.LC.Customer.DeliverGood
{
    public partial class CT_Success : PageLoginBase
    {
       public string OID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            OID = GetValue("OID");
        }
    }
}