using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
using System.Configuration;
namespace Logistics.LC.Line
{
    public partial class LC_LineAdd : PageLoginBase
    {
        //二维码地址
        public string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            var xl = GetValue("xl"); //获取线路字母
            if(xl.StrIsNotNull())
            {
                var myuservo = GetMyLoginUserVO();
                //生成二维码
                url = $"{ConfigurationManager.AppSettings.Get("HOST")}/LC/Manage/Line/LC_CooperationRoute.aspx?binduid={myuservo.uid}&xl={xl}";
                url = MakeQRUrl(url);
            }

        }
    }
}