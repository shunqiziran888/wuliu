using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;

namespace Logistics.LC.Manage.Vehicle
{
    public partial class LC_VehicleAdd : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string UID = myuservo.uid;
            try
            {
                if (IsPostBack)
                {
                    Tuple<bool, string> vo = BLL.BLL.LC_Vehicle.Add(new Model.Model.LC_Vehicle()
                    {
                        VehicleNo = GetValue("VehicleNo"),
                        Driver = GetValue("Driver"),
                        CreateTime = DateTime.Now,
                        UID = UID
                    });
                    if (vo.Item1)
                    {
                        AlertJump("添加成功", "/LC/Manage/Vehicle/LC_Vehicle.aspx");
                    }
                    else
                    {
                        Alert(vo.Item2);
                    }
                }
            }
            catch (Exception)
            {
                Alert("添加失败请重试");
            }
        }
    }
}