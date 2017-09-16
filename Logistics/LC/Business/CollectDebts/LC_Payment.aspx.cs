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

namespace Logistics.LC.Business.CollectDebts
{
    public partial class LC_Payment : PageLoginBase
    {
        public string OID;
        public decimal? SSyf;
        public decimal? SSdsk;
        public decimal? SStf;
        public decimal? SShj;
        public decimal? TotalAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            OID = GetValue("OID");
            SSyf = GetValue<decimal>("SSyf");//实收运费
            SSdsk = GetValue<decimal>("SSdsk");//实收代收款
            SStf = GetValue<decimal>("SStf");//实收提付运费--暂未修改
            SShj = GetValue<decimal>("SShj");//实收合计
            TotalAmount = GetValue<decimal>("TotalAmount");//应收合计
        }
    }
}