using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using CustomExtensions;
using GlobalBLL;
using System.Diagnostics;

namespace Logistics.LC.Customer.TrackGood
{
    public partial class LC_IndexTK : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Customer> list2 = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string Phone = myuservo.phones;
            var vo = DAL.DAL.LC_Customer.GetDGSHList(Phone);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list2 = vo.Item3;

            var vo1 = DAL.DAL.LC_Customer.GetDGList(Phone);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            list = vo1.Item3;
        }
    }
}