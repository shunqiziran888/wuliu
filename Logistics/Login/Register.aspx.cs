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
        public List<GlobalBLL.Position> ZwList = new List<GlobalBLL.Position>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取地区省列表
            shengList = DAL.DAL.DALBase.GetNextAddressListFromId(1);
            if (IsPostBack)
            {
                try
                {
                    var loginvo = GetMyLoginUserVO();

                    var uservo = new Model.Model.LC_User()
                    {
                        LogisticsName = GetValue("LogisticsName"),//公司名称
                        UserName = GetValue("UserName"),//用户昵称
                        PositionID = GetValue<int>("PositionID"), //职位
                        CreateTime = DateTime.Now,//注册时间
                        Password = GetValue("Password"),//密码
                        Phone = GetValue("Phone"),//手机号
                        UID = Tools.NewGuid.GuidTo16String(),//生成ID
                        ZNumber = GetValue("Phone"),//帐号
                        ZType = GetValue<int>("ZType"),//帐号类型
                        ProvincesID = GetValue<int>("End1"),//省份
                        CityID = GetValue<int>("End2"),//城市
                        AreaID = GetValue<int>("End"),//区县
                        State = GetValue<int>("State"),//状态
                        LCID = GetValue("LCID")//上级物流ID
                    };
                    //string LogisticsUid = GetValue("LogisticsUid");
                    string LogisticsUid = "6cfe97409cd87419";
                    //开始注册
                    Tuple<bool, string> vo = BLL.BLL.LC_User.Add(uservo, loginvo, LogisticsUid);

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