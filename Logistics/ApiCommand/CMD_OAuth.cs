using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperCommand;
using SuperCommand.Attribute;
using CustomExtensions;
using Tools;
using Newtonsoft.Json.Linq;
using GlobalBLL;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 微信登录授权
    /// </summary>
    [Doc(typeof(CMD_OAuth), "微信登录授权")]
    [InputDoc("code", "微信端返回的CODE")]
    [InputDoc("aid", "代理商ID")]
    [InputDoc("source", "入口必须传入一个m")]
    public class CMD_OAuth : WebCommandBase, SuperCommand.ICommandBase<WebCommandVOBase>
    {
        public CMD_OAuth() : base(false) { }
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            string code = web.GetValue("code");
            string userSource = web.GetValue("source");
            int acctype = web.GetValue<int>("acctype"); //账号类型
            int region = web.GetValue<int>("region"); //职位

            if (code.StrIsNull())
                return Show<TCommandState>("CODE是空的，微信认证失败!");

            #region 获取公众号APPID与密钥

            string AppId = System.Configuration.ConfigurationManager.AppSettings["AppID"];
            string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
            #endregion

            //通过code换取网页授权access_token
            var htmlvo = GetHtml.GetHtmlFromUrl("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + AppId + "&secret=" + AppSecret + "&code=" + code + "&grant_type=authorization_code", string.Empty, null, null);
            if (!htmlvo.Item1)
                return Show<TCommandState>("请求微信AccessToken验证时出现了通讯故障!");
            var jsonvo = MakeJson.JsonToLinqObject(htmlvo.Item2);
            //获取account_key
            string access_token = jsonvo.TryGetValue<string>("access_token");
            string openid = jsonvo.TryGetValue<string>("openid");
            string scope = jsonvo.TryGetValue<string>("scope");
            if (access_token.StrIsNull())
                return Show<TCommandState>("AccessToken微信授权失败");


            string scope_str = scope.ToLower();
            Tuple<bool, string> userhtmlvo = null;
            //判断授权类型
            switch (scope_str)
            {
                case "snsapi_userinfo":
                    //获取用户信息
                    userhtmlvo = GetHtml.GetHtmlFromUrl("https://api.weixin.qq.com/sns/userinfo?access_token=" + access_token + "&openid=" + openid + "&lang=zh_CN", string.Empty, null, null);
                    break;

                case "snsapi_base":
                    userhtmlvo = new Tuple<bool, string>(true, string.Empty);
                    break;
                default:
                    return Show<TCommandState>("居然返回了一个我从来都不清楚的scope:" + scope_str);
            }

            //判断获取详情数据是否成功
            if (!userhtmlvo.Item1)
                return Show<TCommandState>("获取用户详细数据时出现了错误!");


            JObject userjsonvo = null;
            string my_openid = string.Empty;
            string unionid = string.Empty;
            Model.Model.LC_User suser = null;

            switch (scope_str)
            {
                case "snsapi_userinfo":
                    //解析数据
                    userjsonvo = Tools.MakeJson.JsonToLinqObject(userhtmlvo.Item2);
                    my_openid = userjsonvo.TryGetValue<string>("openid");
                    unionid = userjsonvo.TryGetValue("unionid", string.Empty);

                    suser = new Model.Model.LC_User()
                    {
                        WX_NickName = userjsonvo.TryGetValue<string>("nickname"),
                        WX_Sex = userjsonvo.TryGetValue<int>("sex"),
                        WX_OpenID = my_openid,
                        WX_Province = userjsonvo.TryGetValue<string>("province"),
                        WX_City = userjsonvo.TryGetValue<string>("city"),
                        WX_Country = userjsonvo.TryGetValue<string>("country"),
                        WX_HeadPic = userjsonvo.TryGetValue<string>("headimgurl"),
                        ZType = acctype,
                        PositionID = region
                    };
                    //更新或添加账号
                    (bool, string, Model.Model.LC_User suser) AddOrUpdateVO = BLL.BLL.LC_User.AddOrUpdateUserVO(web, suser);
                    if (!AddOrUpdateVO.Item1)
                        return Show<TCommandState>(AddOrUpdateVO.Item2);
                    suser = AddOrUpdateVO.suser;
                    break;
                case "snsapi_base":
                    my_openid = openid;
                    //获取个人数据
                    (bool, string, Model.Model.LC_User) suser_vo = DAL.DAL.LC_User.GetUserDataFromOpenID(my_openid);
                    if (!suser_vo.Item1)
                    {
                        return Show<TCommandState>(new
                        {
                            status = -10
                        });
                    }
                    else
                    {
                        suser = suser_vo.Item3;
                    }
                    break;
            }
            SetLogin(suser);

            return Show<TCommandState>(new
            {
                status = 1,
                Open_ID = suser.WX_OpenID,
                Nick_Name = suser.WX_NickName,
                Head_Img_Url = suser.WX_HeadPic,
                ZType = suser.ZType.ConvertData<int>() //账号类型
            });
        }
    }
}