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

namespace Logistics.LC_Index
{
    public partial class LC_Index : PageLoginBase
    {
        public int ZType;
        public string UID;
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();                                                                                                                                 
            ZType = myuservo.accountType.EnumToInt();
            UID = myuservo.uid;
        }
    }
}