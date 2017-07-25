using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.DschargeGood
{
    public partial class FHEdit : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string UID = GetValue("OID");
            var myuservo = GetMyLoginUserVO();
            string logisticsID = myuservo.uid;
            //放货-客户提货信息-放货操作
            var vo = DAL.DAL.LC_Customer.GetFHEditList(UID, logisticsID);
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