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
namespace Logistics.LC.Business.MeetCar
{
    public partial class LC_GoodDetails : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public int CFD;
        public int MDD;
        protected void Page_Load(object sender, EventArgs e)
        {
            int CH = GetValue<int>("CH"); //车号
            CFD = GetValue<int>("CFD"); //出发地
            MDD = GetValue<int>("MDD"); //目的地
            var vo = DAL.DAL.LC_Customer.GetGDList(CH,MDD);
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