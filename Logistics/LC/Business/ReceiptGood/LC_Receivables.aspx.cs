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
    public partial class LC_Receivables : PageLoginBase
    {
        public decimal yf;
        public int  finish;
        public string BindLogisticsUid;
        public string OID;

        protected void Page_Load(object sender, EventArgs e)
        {
            yf = GetValue<decimal>("yf");
            finish = GetValue<int>("finish");
            BindLogisticsUid = GetValue("BindLogisticsUid");
            OID = GetValue("OrderID");

        }
    }
}