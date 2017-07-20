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
    public partial class LC_TransferEdit : PageLoginBase
    {
        public List<Model.Model.LC_User> list = new List<Model.Model.LC_User>();
        public List<Model.Model.LC_Line> list3 = new List<Model.Model.LC_Line>();
        public List<Model.Model.LC_Line_Other> list2 = new List<Model.Model.LC_Line_Other>();
        public string OID;
        public int Destination;
        protected void Page_Load(object sender, EventArgs e)
        {
            OID = GetValue("OID");
            Destination = GetValue<int>("Destination");
            var vo1 = DAL.DAL.LC_User.GetLCList();
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            list = vo1.Item3;

            var myuservo1 = GetMyLoginUserVO();
            //物流
            var vo = DAL.DAL.LC_Line.GetLCEndList(myuservo1.uid);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list3 = vo.Item3;
        }
    }
}