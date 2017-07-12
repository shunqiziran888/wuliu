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
            //if (Request.RequestType.Equals("post", StringComparison.OrdinalIgnoreCase))
            if(IsPostBack)
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
                    string LogisticsUid = GetValue("LogisticsUid");//物流ID
                    string FalseValue = GetValue("FalseValue");//判断绑定
                    string ZNumber = GetValue("Phone");//帐号
                    string Pwd = GetValue("Password");//密码
                    //string LogisticsUid = "6cfe97409cd87419";
                    string yonghu = GetValue("yonghu");
                    string UIDS = GetValue("UIDS");
                    if (yonghu== "yhbd" && Pwd=="")
                    {
                        Tuple<bool, string> vo = BLL.BLL.LC_UserBindLogisticsList.UserAdd(new Model.Model.LC_UserBindLogisticsList()
                        {
                            Uid = GetValue("UIDS"),
                            LogisticsUid = LogisticsUid,
                            CreateTime = DateTime.Now
                        });
                        if (vo.Item1)
                        {
                            AlertJump("绑定成功", "/Login/Login.aspx");
                            return;
                        }
                        else
                        {
                            Alert(vo.Item2);
                            return;
                        }
                    }
                    //开始注册
                    if (FalseValue=="10" )
                    {
                        Tuple<bool, string> vo = BLL.BLL.LC_User.Add(uservo, loginvo, LogisticsUid);
                        if (!vo.Item1)
                        {
                            Alert(vo.Item2);
                        }
                        else
                        {
                            int Citys = GetValue<int>("End2");//城市
                            string Zm = Tools.PinYinConverter.GetFirst(DAL.DAL.DALBase.GetAddressFromID(Citys)?.Item2?.Name);//首字母
                            string Zmvalue = Zm.Substring(0, 1);
                            Tuple<bool, string> vo1 = BLL.BLL.LC_Line.BindHZ(ZNumber, Pwd, LogisticsUid, Zmvalue, Zmvalue);
                            if (!vo1.Item1)
                            {
                                Alert(vo1.Item2);
                            }
                            AlertJump("注册成功...返回登录", "/Login/Login.aspx");
                        }
                    }
                    else if(FalseValue!="10")
                    {
                        Tuple<bool, string> vo = BLL.BLL.LC_User.Add(uservo, loginvo, LogisticsUid);
                        if (!vo.Item1)
                        {
                            Alert(vo.Item2);
                        }
                        else
                        {
                            AlertJump("注册成功...返回登录", "/Login/Login.aspx");
                        }
                    }
                }
                catch(Exception)
                {
                    ReturnPager("注册失败,请重试!");
                }
            }
        }
    }
}