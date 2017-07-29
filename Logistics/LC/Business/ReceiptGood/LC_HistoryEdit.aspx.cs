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
namespace Logistics.LC.Business.ReceiptGood
{
    public partial class LC_HistoryEdit : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            if (OID.StrIsNull())
                return;
            int Number = GetValue<int>("Number");
            decimal Freight = GetValue<decimal>("Freight");
            int finish = GetValue<int>("finish");
            int ZT = GetValue<int>("ZT");
            //更新：历史
            if(ZT!=1 || ZT!=6)
            {
                Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer() { Number = Number, Freight = Freight, finish = finish }, OID, true);
                if (!vo.Item1)
                {
                    //有错误
                    Debug.Print(vo.Item2);
                    return;
                }
                else
                {
                    Jump("/LC/Business/ReceiptGood/LC_HistoryIndex.aspx");
                }
            }
            else
            {
                Alert("此订单不可修改！");
                return;
            }
        }
    }
}