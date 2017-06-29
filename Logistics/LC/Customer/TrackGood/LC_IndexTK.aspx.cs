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
        protected void Page_Load(object sender, EventArgs e)
        {
            string vau = GetValue("vau");
            if(vau=="1")
            {
                var myuservo = GetMyLoginUserVO();
                string Phone = myuservo.phones;
                var vo = DAL.DAL.LC_Customer.GetDGList(Phone);
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
}