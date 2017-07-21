using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.MeetCar
{
    public partial class LC_Success : PageLoginBase
    {
        public int CH;
        protected void Page_Load(object sender, EventArgs e)
        {
            CH = GetValue<int>("CH");
            if(CH<=0)
            {
                Alert("车号不能为空!");
                return;
            }
            int End = GetValue<int>("End");
            if(End<=0)
            {
                Alert("目的地不能为空!");
                return;
            }
            var myuservo = GetMyLoginUserVO();
            if (myuservo.accountType == GlobalBLL.AccountTypeEnum.物流账号 || myuservo.accountType==GlobalBLL.AccountTypeEnum.平台账号)
            {
              
                Tuple<bool, string> vo = DAL.DAL.LC_Customer.UpdateMC(myuservo.id, CH,myuservo.uid, End);
                if (!vo.Item1)
                {
                    //有错误
                    Debug.Print(vo.Item2);
                    return;
                }
            }
           else
            {
                AlertJump("您没有权限访问此功能", "/Login/Login.aspx");
                return;
            }
        }
    }
}