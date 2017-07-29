using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.GoodsReceipt
{
    public partial class LC_Success : PageLoginBase
    {
        public string OrderID = null;
        public string OIDDetaila = null;
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            OrderID = GetValue("OrderID");
            OIDDetaila = GetValue("OIDDetaila");//详情-OID
            decimal yf = Convert.ToDecimal(GetValue("yf"));//快速收货-运费
            int ShNumber = GetValue<int>("ssnumber");//详情-实收件数
            decimal FreightDetail = GetValue<int>("FreightDetail");
            decimal OtherExpenses = GetValue<int>("OtherExpenses");//详情-其他费用
            int End = GetValue<int>("End");//目的地
            int finish = GetValue<int>("finish");//中转地
            int Ends = GetValue<int>("Ends");//详情收货目的地
            string BindLogisticsUid = GetValue("BindLogisticsUid"); //终点的绑定UID
            DateTime ConsigneeTimes = DateTime.Now;
            if(ShNumber==0 || FreightDetail==0)
            {
                Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer() { State = 2, ConsigneeTime = ConsigneeTimes, Freight = yf, begins = myuservo.AreaID, finish = finish,
                     beginUID = myuservo.uid,
                     finishUID = BindLogisticsUid
                }, OrderID, true);
                if (!vo.Item1)
                {
                    //有错误
                    Debug.Print(vo.Item2);
                    return;
                }
                //var volist = DAL.DAL.LC_Customer.GetGRList(OrderID);
                //if (!volist.Item1)
                //{
                //    //有错误
                //    Debug.Print(volist.Item2);
                //    return;
                //}
                //list = volist.Item3;
            }
           else
            {
                Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer() { State = 2, ConsigneeTime = ConsigneeTimes, Freight = FreightDetail, begins = myuservo.AreaID, finish = Ends,Number= ShNumber, OtherExpenses= OtherExpenses ,
                    beginUID = myuservo.uid,
                    finishUID = BindLogisticsUid
                }, OIDDetaila, true);
                if (!vo.Item1)
                {
                    //有错误
                    Debug.Print(vo.Item2);
                    return;
                }
            }
        }
    }
}