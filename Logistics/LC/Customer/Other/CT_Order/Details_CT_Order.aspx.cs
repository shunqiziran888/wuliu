using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Customer.Other.CT_Order
{
    public partial class Details_CT_Order : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public decimal GReceivables;  //代收款
        public decimal Freight;  //运费
        public decimal OtherExpenses;  //其他费用
        public int Number;  //件数
        public decimal TotalTF;//提付合计
        public decimal TotalXF;//现付合计
        public decimal TotalKF;//扣付合计
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            var vo = DAL.DAL.LC_Customer.GetGRList(OID);
            GReceivables = GetValue<decimal>("GReceivables");
            Freight = GetValue<decimal>("Freight");
            Number = GetValue<int>("Number");
            OtherExpenses = GetValue<decimal>("OtherExpenses");
            TotalTF = GReceivables + Freight + OtherExpenses;//提付
            TotalXF = GReceivables + OtherExpenses;// 现付
            TotalKF = (GReceivables - Freight) + OtherExpenses;//扣付
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
        }
    }
}