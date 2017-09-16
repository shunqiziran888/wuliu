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
    public partial class LC_TgDetails : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        //public decimal GReceivables;  //代收款
        //public decimal Freight;  //运费
        //public decimal OtherExpenses;  //其他费用
        //public decimal TotalTF = 0;//提付合计
        //public decimal TotalXF = 0;//现付合计
        //public decimal TotalKF = 0;//扣付合计
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            var myuservo = GetMyLoginUserVO();
            //GReceivables = GetValue<decimal>("GReceivables");
            //Freight = GetValue<decimal>("Freight");
            //OtherExpenses = GetValue<decimal>("OtherExpenses");
            //
            //string Phone = myuservo.phones;
            //decimal TotalTFold = GReceivables + Freight + OtherExpenses;//提付
            //TotalTF = Math.Round(TotalTFold, 2);
            //decimal TotalXFold = GReceivables + OtherExpenses;// 现付
            //TotalXF = Math.Round(TotalXFold, 2);
            //decimal TotalKFold = (GReceivables - Freight) + OtherExpenses;//扣付
            //TotalKF = Math.Round(TotalKFold, 2);
            var vo = DAL.DAL.LC_Customer.GetSGList(myuservo.phones,OID);
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