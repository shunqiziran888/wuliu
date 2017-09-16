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
        public string OID;
        public DateTime DdTime;
        public string GoodName;
        public int Number;
        public int freightMode;
        public string Consignee;
        public string Consignor;
        public int Destination;
        public decimal OtherExpenses;
        public decimal GReceivables;
        public int CarryGood;
        public int ReceiptGood;
        public string SHPhone;
        public string FHPhone;
        protected void Page_Load(object sender, EventArgs e)
        {
            OID = GetValue("OID");
            DdTime = GetValue<DateTime>("DdTime");
            GoodName = GetValue("GoodName");
            Number = GetValue<int>("Number");
            freightMode = GetValue<int>("freightMode");
            Consignee = GetValue("Consignee");
            Consignor = GetValue("Consignor");
            Destination = GetValue<int>("Destination");
            OtherExpenses = GetValue<decimal>("OtherExpenses");
            GReceivables = GetValue<decimal>("GReceivables");
            CarryGood = GetValue<int>("CarryGood");
            ReceiptGood = GetValue<int>("ReceiptGood");
            SHPhone = GetValue("SHPhone");
            FHPhone = GetValue("FHPhone");
            OtherExpenses = GetValue<decimal>("OtherExpenses");
        }
    }
}