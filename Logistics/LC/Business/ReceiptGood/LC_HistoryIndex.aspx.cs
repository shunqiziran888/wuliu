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
   
    public partial class LC_HistoryIndex : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Line> list2 = new List<Model.Model.LC_Line>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            var vo = DAL.DAL.LC_Customer.GetHistoyList(UID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            //物流
            var myuservo1 = GetMyLoginUserVO();
            var vo1 = DAL.DAL.LC_Line.GetLCEndList(myuservo1.uid);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            list2 = vo1.Item3;
        }
    }
}