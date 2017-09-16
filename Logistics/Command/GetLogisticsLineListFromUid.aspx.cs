using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Command
{
    public partial class GetLogisticsLineListFromUid : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = GetValue("uid");

            Tuple<bool, string, List<Model.Model.LC_Line>> list = DAL.DAL.LC_Line.GetLineListFromUid(uid);
            Response.Write(new Tuple<bool, string, object>(list.Item1, list.Item2, list.Item3.Select((x) =>
            {
                return new
                {
                    x.End,
                    EndName = DAL.DAL.DALBase.GetAddressFromID(x.End.ConvertData<int>()).Item2?.Name ?? string.Empty,
                    x.LineID,
                    x.DFPhone,
                    x.MyPhone,
                    x.Start,
                    x.UID,
                    ShengName = DAL.DAL.DALBase.GetAllAddressNames(x.End.ConvertData<int>()).sheng,
                    QuName = DAL.DAL.DALBase.GetAllAddressNames(x.End.ConvertData<int>()).shi
                };
            })).ToJson());
            Response.End();
        }
    }
}