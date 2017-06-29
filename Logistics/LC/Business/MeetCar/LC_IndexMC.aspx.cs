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
using Model.Model;

namespace Logistics.LC.Business.MeetCar
{
    public partial class LC_IndexMC : PageLoginBase
    {

        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            var vo = DAL.DAL.LC_Customer.GetMCList(UID,myuservo.AreaID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3.Distinct(new DistinctCustome()).ToList();
        }
        //去重:车号
        public class DistinctCustome : IEqualityComparer<Model.Model.LC_Customer>
        {
            public bool Equals(LC_Customer x, LC_Customer y)
            {
                return (x.VehicleID==y.VehicleID);
            }

            public int GetHashCode(LC_Customer obj)
            {
                return 0;
            }
        }
    }
    
}