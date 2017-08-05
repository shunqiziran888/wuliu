using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Customer.SignGood
{
    public partial class LC_GiveSuccess : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            string DetailedAddress = GetValue("DetailedAddress");
            decimal DeliveryCost =GetValue<decimal>("DeliveryCost");
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer() { State = 5,CarryGood=2,DetailedAddress=DetailedAddress,DeliveryCost=DeliveryCost }, OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}