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
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            OrderID = GetValue("OrderID");
            decimal yf = Convert.ToDecimal(GetValue("yf"));
            int finish = GetValue<int>("finish");//目的地
            DateTime ConsigneeTimes = DateTime.Now;
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer() {State =2 ,ConsigneeTime= ConsigneeTimes,Freight=yf ,begins=myuservo.AreaID,finish=finish} ,OrderID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}