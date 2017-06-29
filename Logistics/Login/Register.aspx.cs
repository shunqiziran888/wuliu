using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.Login
{
    public partial class Register :PageLoginBase
    {
        public Register() : base(false) { }
        public List<Model.Model.w_address_basic_data> shengList = new List<Model.Model.w_address_basic_data>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取地区省列表
            shengList = DAL.DAL.DALBase.GetNextAddressListFromId(1);
            if (IsPostBack)
            {
                try
                {
                    //开始注册
                    Tuple<bool, string> vo = BLL.BLL.LC_User.Add(new Model.Model.LC_User()
                    {
                        UserName = GetValue("UserName"),
                        CreateTime = DateTime.Now,
                        Password = GetValue("Password"),
                        Phone = GetValue("Phone"),
                        UID = Tools.NewGuid.GuidTo16String(),
                        ZNumber = GetValue("Phone"),
                        ZType = Convert.ToInt32(GetValue("ZType")),
                        ProvincesID = GetValue<int>("End1"),
                        CityID = GetValue<int>("End2"),
                        AreaID = GetValue<int>("End"),
                        State = 0
                    });

                    if (vo.Item1)
                    {
                        AlertJump("注册成功...返回登录", "/Login/Login.aspx");
                    }
                    else
                    {
                        Alert(vo.Item2);
                    }
                }catch(Exception)
                {
                    AlertJump("注册账号时失败,请重试!", "/Login/Register.aspx");
                }
            }
        }
    }
}