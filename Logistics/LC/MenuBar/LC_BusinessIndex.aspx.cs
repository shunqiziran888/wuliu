using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;
using System.Data;

namespace Logistics.LC.MenuBar
{
    public partial class LC_BusinessIndex : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Customer> FHlist = new List<Model.Model.LC_Customer>();
        public DataTable PretendCarCountList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            var vo = DAL.DAL.LC_Customer.GetCusList(UID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            //装车小红点
            var vo1 = DAL.DAL.LC_Customer.GetPretendCarCount(UID);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            PretendCarCountList = vo1.Item3;
            //放货小红点
            var vo2 = DAL.DAL.LC_Customer.GetFHandZZList(UID);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            FHlist = vo2.Item3;
        }
    }
}