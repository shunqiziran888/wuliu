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

namespace Logistics.LC.Business.ReceiptGood
{

    public partial class LC_HistoryIndex : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_Line> list2 = new List<Model.Model.LC_Line>();
        public List<Model.Model.LC_Line> LineWhereList = new List<Model.Model.LC_Line>();
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
            //条件查询：路线
            var vo2 = DAL.DAL.LC_Line.GetLineListFromUid(myuservo1.uid);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            LineWhereList = vo2.Item3;
            //条件查询：路线
            string End = GetValue("End");
            if (End != null)
            {
                var vo3 = DAL.DAL.LC_Customer.GetCityOrderList(UID, myuservo1.uid, End);
                if (!vo3.Item1)
                {
                    //有错误
                    Debug.Print(vo3.Item2);
                    return;
                }
                list = vo3.Item3;
            }
            //条件查询：日期
            string StartTime = GetValue("StartTime");
            string EndTime = GetValue("EndTime");
            if(StartTime!=null && EndTime!=null)
            {
                var vo4 = DAL.DAL.LC_Customer.GetDateOrderList(UID, StartTime, EndTime);
                if (!vo4.Item1)
                {
                    //有错误
                    Debug.Print(vo4.Item2);
                    return;
                }
                list = vo4.Item3;
            }
        }
    }
}