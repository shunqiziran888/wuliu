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
        public int sta;
        public int end;
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public decimal tifu =0;
        public decimal xianfu = 0;
        public decimal koufu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            sta =GetValue<int>("Initially");
            end =GetValue<int>("Destination");
            var vo = DAL.DAL.LC_Customer.GetCmdList(UID,sta,end);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            //提付
            var vo1 = DAL.DAL.LC_Customer.Gettifu(UID,sta,end);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            tifu = vo1.Item3;
            //现付
            var vo2 = DAL.DAL.LC_Customer.Getxianfu(UID, sta, end);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            xianfu = vo2.Item3;
            //扣付
            var vo3 = DAL.DAL.LC_Customer.Getkoufu(UID, sta, end);
            if (!vo3.Item1)
            {
                //有错误
                Debug.Print(vo3.Item2);
                return;
            }
            koufu = vo3.Item3;
        }
    }
}