using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.ReceiptGood
{
    public partial class LC_ReceivablesDetails : PageLoginBase
    {
        public string OIDDetaila;
        public int ssnumber;
        public decimal FreightDetail;
        public decimal OtherExpenses;
        public int Ends;
        public string BindLogisticsUid;
        public decimal GReceivables;
        protected void Page_Load(object sender, EventArgs e)
        {
            OIDDetaila = GetValue("OIDDetaila");
            ssnumber = GetValue<int>("ssnumber");
            FreightDetail = GetValue<decimal>("FreightDetail");
            OtherExpenses = GetValue<decimal>("OtherExpenses");
            Ends = GetValue<int>("Ends");
            GReceivables = GetValue<decimal>("GReceivables");
            BindLogisticsUid = GetValue("BindLogisticsUid");
        }
    }
}