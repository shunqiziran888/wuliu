using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.LC.Line
{
    public partial class LC_LineAdd : PageLoginBase
    {
        public string uid;
        public string uname;
        public List<Model.Model.w_address_basic_data> shengList = new List<Model.Model.w_address_basic_data>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //获取地区省列表
                shengList = DAL.DAL.DALBase.GetNextAddressListFromId(1);

                if (IsPostBack)
                {
                    var myuservo = GetMyLoginUserVO();
                    Tuple<bool, string> vo = BLL.BLL.LC_Line.Add(new Model.Model.LC_Line()
                    {
                        LineID = Tools.NewGuid.GuidTo16String(),
                        Start = myuservo.AreaID,
                        End = GetValue<int>("End"),
                        Phone = GetValue("Phone"),
                        UserID = myuservo.id.ConvertData<int>(),
                        DateTime = DateTime.Now,
                        UID = myuservo.uid
                    });
                    if (vo.Item1)
                    {
                        AlertJump("添加成功", "/LC/Manage/Line/LC_Line.aspx");
                    }
                    else
                    {
                        Alert(vo.Item2);
                    }
                }
            }catch(Exception)
            {
                Alert("添加失败请重试");
            }

            uid = GetValue("uID");
            uname = GetValue("uname");
        }
    }
}