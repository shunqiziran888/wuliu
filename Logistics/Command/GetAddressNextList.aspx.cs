using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Command
{
    public partial class GetAddressNextList : PageLoginBase
    {

        public GetAddressNextList() : base(false) { }
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取地区列表
            int id = GetValue<int>("id");
            var list = DAL.DAL.DALBase.GetNextAddressListFromId(id);
            Response.Write(list.ToJson());
            Response.End();
        }
    }
}