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
    public partial class LC_TransferEdit : PageLoginBase
    {
        public List<Model.Model.LC_User> list = new List<Model.Model.LC_User>();
        public List<Model.Model.LC_Line_Other> list2 = new List<Model.Model.LC_Line_Other>();
        public string OID;
        protected void Page_Load(object sender, EventArgs e)
        {
            OID = GetValue("OID");
            var vo1 = DAL.DAL.LC_User.GetLCList();
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            list = vo1.Item3;

            var vo2 = DAL.DAL.LC_Line.GetLineList(-1);
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