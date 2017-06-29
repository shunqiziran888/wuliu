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

namespace Logistics.LC.Business.PretendCar
{
    public partial class LC_Success : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            if (OID.StrIsNull())
                return;
            string jqOID = OID.StringToArray().Select(x=>$"'{x}'").ToList().ListToString();
            int VehicleIDs =GetValue<int>("VehicleID");
            decimal dcyf =GetValue<decimal>("dcyf");
            DateTime TruckTime = DateTime.Now;
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdatePC(new Model.Model.LC_Customer() { State = 3, VehicleID = VehicleIDs , largeCar = dcyf,TruckTime=TruckTime}, jqOID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}