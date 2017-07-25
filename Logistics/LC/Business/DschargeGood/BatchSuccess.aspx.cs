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

namespace Logistics.LC.Business.DschargeGood
{
    public partial class BatchSuccess :  PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = GetValue("OID");
            string jqOID = OID.StringToArray().Select(x => $"'{x}'").ToList().ListToString();
            if (OID.StrIsNull())
                return;
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdatePC(new Model.Model.LC_Customer() { State = 8}, jqOID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}