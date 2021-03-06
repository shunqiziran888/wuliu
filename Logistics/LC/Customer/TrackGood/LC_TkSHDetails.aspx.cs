﻿using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Customer.TrackGood
{
    public partial class LC_TkSHDetails : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public decimal GReceivables;  //代收款
        public decimal Freight;  //运费
        public decimal OtherExpenses;  //其他费用
        public int Number;  //件数
        public decimal TotalTF = 0;//提付合计
        public decimal TotalXF = 0;//现付合计
        public decimal TotalKF = 0;//扣付合计
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            GReceivables = GetValue<decimal>("GReceivables");
            Freight = GetValue<decimal>("Freight");
            Number = GetValue<int>("Number");
            OtherExpenses = GetValue<decimal>("OtherExpenses");
            TotalTF = GReceivables + Freight + OtherExpenses;//提付
            TotalXF = GReceivables + OtherExpenses;// 现付
            TotalKF = (GReceivables - Freight) + OtherExpenses;//扣付
            var vo = DAL.DAL.LC_Customer.GetGRList(OID);
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