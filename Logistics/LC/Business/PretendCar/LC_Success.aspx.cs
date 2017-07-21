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
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public int VehicleIDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            if (OID.StrIsNull())
                return;
            string jqOID = OID.StringToArray().Select(x=>$"'{x}'").ToList().ListToString();
            VehicleIDs =GetValue<int>("VehicleID");
            decimal dcyf =GetValue<decimal>("dcyf");
            DateTime TruckTime = DateTime.Now;
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdatePC(new Model.Model.LC_Customer() { State = 3, VehicleID = VehicleIDs , largeCar = dcyf,TruckTime=TruckTime}, jqOID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            //成功：显示运费、车牌号
            var vo2 = DAL.DAL.LC_Customer.GetZCSuccessList(VehicleIDs);
            if (!vo2.Item1)
            {
                //有错误
                Debug.Print(vo2.Item2);
                return;
            }
            list = vo2.Item3;
        }
    }
}