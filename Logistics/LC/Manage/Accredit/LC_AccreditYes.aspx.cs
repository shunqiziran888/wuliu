using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Manage.Accredit
{
    public partial class LC_AccreditEdit : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string UID = GetValue("UID");
            Tuple<bool, string> vo = DAL.DAL.LC_User.UpdateYesOrNo(new Model.Model.LC_User() { State = 1 }, UID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
        }
    }
}