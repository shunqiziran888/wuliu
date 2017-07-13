using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.ReceiptGood
{
    public partial class LC_RgDetails : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Line> list2 = new List<Model.Model.LC_Line>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            var vo = DAL.DAL.LC_Customer.GetGRList(OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;

            var vo2 = DAL.DAL.LC_Line.GetXLList(UID);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            list2 = vo2.Item3;
        }
    }
}