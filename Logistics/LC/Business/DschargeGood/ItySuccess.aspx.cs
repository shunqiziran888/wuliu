using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.DschargeGood
{
    public partial class ItySuccess : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdateIty(new Model.Model.LC_Customer() { State = 8 }, OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}