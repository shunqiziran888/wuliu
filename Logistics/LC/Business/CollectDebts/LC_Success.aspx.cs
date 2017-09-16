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
    public partial class LC_Success : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            decimal? SSyf = GetValue<decimal>("SSyf");//实收运费
            decimal? SSdsk = GetValue<decimal>("SSdsk");//实收代收款
           /* decimal? SStf = GetValue<decimal>("SStf");*///实收提付运费--暂未修改
            decimal? SShj = GetValue<decimal>("SShj");//实收合计
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.Update(new Model.Model.LC_Customer()
            {
                State = GlobalBLL.OrderStateEnum.订单完成.EnumToInt(),
                Freight = SSyf > 0 ? SSyf : null,
                GReceivables = SSdsk > 0 ? SSdsk : null,
                Total = SShj > 0 ? SShj : null
            }, OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}