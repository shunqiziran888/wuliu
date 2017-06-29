using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Command
{
    public partial class GetLineListFromLogisticsId :PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string logid = GetValue("logid");
            var list = DAL.DAL.LC_Line.GetXLList(logid);
            Response.Write(new Tuple<bool,string,object>(list.Item1,list.Item2,list.Item3.Select((x)=> {
                return new
                {
                    x.ID,
                    x.Start,
                    x.End,
                    StartName = GlobalBLL.GlobalAddress.GetAddressFromID(x.Start.ConvertData<int>())?.Item2?.Name,
                    EndName = GlobalBLL.GlobalAddress.GetAddressFromID(x.End.ConvertData<int>())?.Item2?.Name
                };
            })).ToJson());
            Response.End();
        }
    }
}