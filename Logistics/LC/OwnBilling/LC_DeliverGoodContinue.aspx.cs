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

namespace Logistics.LC.OwnBilling
{
    public partial class LC_DeliverGoodContinue : PageLoginBase
    {
        public string Consignor;
        public string FHPhone;
        public string GoodName;
        public int Number;
        public decimal GReceivables;
        public string Consignee;
        public string SHPhone;
        public int End;
        public int finish;
        public string BindLogisticsUid;
        protected void Page_Load(object sender, EventArgs e)
        {
             Consignor = GetValue("Consignor");
             FHPhone = GetValue("FHPhone");
             GoodName = GetValue("GoodName");
             Number = GetValue<int>("Number");
             GReceivables = GetValue<decimal>("GReceivables");
             Consignee = GetValue("Consignee");
             SHPhone = GetValue("SHPhone");
             End = GetValue<int>("End");
             finish = GetValue<int>("finish");
             BindLogisticsUid = GetValue("BindLogisticsUid");
        }
    }
}