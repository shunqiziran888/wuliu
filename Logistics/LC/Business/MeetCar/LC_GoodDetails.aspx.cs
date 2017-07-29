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
        public decimal tifu = 0;
        public decimal xianfu = 0;
        public decimal koufu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int CH = GetValue<int>("CH"); //车号
            CFD = GetValue<int>("CFD"); //出发地
            MDD = GetValue<int>("MDD"); //目的地
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            var vo = DAL.DAL.LC_Customer.GetGDList(CH,MDD);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            //提付
            var vo1 = DAL.DAL.LC_Customer.GettifuMeetCar(UID);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            tifu = vo1.Item3;
            //现付
            var vo2 = DAL.DAL.LC_Customer.GetxianfuMeetCar(UID);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            xianfu = vo2.Item3;
            //扣付
            var vo3 = DAL.DAL.LC_Customer.GetkoufuMeetCar(UID);
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