using CustomExtensions;
using GlobalBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Logistics
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// 微信AccessToKen字典
        /// </summary>
        private static WechatAccessToKenVO AccessToKenVO = null;
        protected void Application_Start(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        try
                        {
                            TimeRun();
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            Tools.SaveLog.AddLog(ex.Message, "公用线程错误");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Tools.SaveLog.AddLog(ex.Message, "公用线程错误");
                }
            });
        }

        private void TimeRun()
        {
            GetAccessToken();
        }

        private void GetAccessToken()
        {
            if (AccessToKenVO == null || (AccessToKenVO?.AccessToken?.StrIsNull() ?? true) || AccessToKenVO?.overTime <= DateTime.Now)
            {
                string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"];
                string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
                string OriginalID = System.Configuration.ConfigurationManager.AppSettings["OriginalID"];
                if (AccessToKenVO == null)
                {
                    AccessToKenVO = new WechatAccessToKenVO()
                    {
                        AppID = AppID,
                        AccessToken = string.Empty,
                        AppSecret = AppSecret,
                        OriginalID = OriginalID,
                    };
                }

                Tuple<bool, string> vo = Tools.GetHtml.GetHtmlFromUrl(@"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppID + "&secret=" + AppSecret, string.Empty, null, null);
                if (vo.Item1)
                {
                    if (vo.Item2.StrIsNotNull())
                    {
                        var jsonObj = Tools.MakeJson.JsonToLinqObject(vo.Item2);
                        string AccessToken = jsonObj.TryGetValue<string>("access_token");
                        if (AccessToken.StrIsNotNull())
                        {
                            Tools.SaveLog.AddLog("获取:" + AppID + " 的ACCESSTOKEN成功(" + AccessToken + ")", "获取ACCESSTOKEN");
                            AccessToKenVO.AccessToken = AccessToken;
                            //获取数据
                            AccessToKenVO.overTime = DateTime.Now + new TimeSpan(0, 0, jsonObj.TryGetValue<int>("expires_in") - 10); //减去10秒
                        }
                        else
                        {
                            Tools.SaveLog.AddLog("(获取AccessToken出现了错误)内容为:" + vo.Item2, "获取ACCESSTOKEN");
                        }
                    }
                }
                else
                {
                    Tools.SaveLog.AddLog("拉取服务号AccessToken时出现了错误!", "获取ACCESSTOKEN");
                }
            }
        }

        internal static void RemoveAdvertiserUser()
        {
            AccessToKenVO = null;
        }

        /// <summary>
        /// 获取微信权限
        /// </summary>
        /// <returns></returns>
        public static (bool flag, WechatAccessToKenVO ACCTOKEN) GetAccessToKen()
        {
            if (AccessToKenVO == null)
                return (false, null);
            return (true, AccessToKenVO);
        }
    }
}