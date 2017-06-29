using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Line
{
    public partial class LC_LineDetails : PageLoginBase
    {
        //public static List<Model.Model.LC_Line> list;

        public  Model.Model.LC_Line_Other v = new Model.Model.LC_Line_Other();
        protected void Page_Load(object sender, EventArgs e)
        {
            int LID = GetValue<int>("ID");
            var vo = DAL.DAL.LC_Line.GetLineData(LID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            v = vo.Item3;
        }
    }
}