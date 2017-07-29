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

namespace Logistics.LC.Business.DschargeGood
{
    public partial class LC_SHSuccess : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdateIty(new Model.Model.LC_Customer() { State = GlobalBLL.OrderStateEnum.订单完成.EnumToInt()}, OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}