using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Manage.Vehicle
{
    public partial class LC_VehicleDetails : PageLoginBase
    {
        public List<Model.Model.LC_Vehicle> list = new List<Model.Model.LC_Vehicle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = GetValue<int>("ID");
            var vo = DAL.DAL.LC_Vehicle.GetDetailList(ID);
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