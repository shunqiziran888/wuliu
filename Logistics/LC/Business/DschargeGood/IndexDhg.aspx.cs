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
    public partial class IndexDhg : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Customer> DFHList = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Line> LineList = new List<Model.Model.LC_Line>();
        public decimal tifu = 0;
        public decimal xianfu = 0;
        public decimal koufu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            //放货-客户提货信息
            var vo = DAL.DAL.LC_Customer.GetFHandZZList(UID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
            //物流
            var vo1 = DAL.DAL.LC_Line.GetLCEndList(UID);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            LineList = vo1.Item3;
            //放货-待放货库存
            var vo2 = DAL.DAL.LC_Customer.GetDFHList(UID);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            DFHList = vo2.Item3;
            //提付
            var vo3 = DAL.DAL.LC_Customer.GettifuDHG(UID);
            if (!vo3.Item1)
            {
                //有错误
                Debug.Print(vo3.Item2);
                return;
            }
            tifu = vo3.Item3;
            //现付
            var vo4 = DAL.DAL.LC_Customer.GetxianfuDHG(UID);
            if (!vo4.Item1)
            {
                //有错误
                Debug.Print(vo4.Item2);
                return;
            }
            xianfu = vo4.Item3;
            //扣付
            var vo5 = DAL.DAL.LC_Customer.GetkoufuDHG(UID);
            if (!vo5.Item1)
            {
                //有错误
                Debug.Print(vo5.Item2);
                return;
            }
            koufu = vo5.Item3;
        }

    }
}