using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.PretendCar
{
    public partial class LC_Commodity : PageLoginBase
    {
        public string StartCityName = null;
        public string EndCityName = null;
        public int sta;
        public int end;
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            sta =GetValue<int>("Initially");
            end =GetValue<int>("Destination");
            StartCityName = GetValue("StartCityName");
            EndCityName = GetValue("EndCityName");


            var vo = DAL.DAL.LC_Customer.GetCmdList(UID,sta,end);
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