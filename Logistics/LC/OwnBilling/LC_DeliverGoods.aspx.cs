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

namespace Logistics.LC.OwnBilling
{
    public partial class LC_DeliverGoods : PageLoginBase
    {
        public List<Model.Model.w_address_basic_data> shengList = new List<Model.Model.w_address_basic_data>();
        public List<Model.Model.LC_Line> LineList = new List<Model.Model.LC_Line>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            shengList = DAL.DAL.DALBase.GetNextAddressListFromId(1);
            //路线结束地ID
            var vo = DAL.DAL.LC_Line.GetXLList(myuservo.uid);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            LineList = vo.Item3;
        }
    }
}