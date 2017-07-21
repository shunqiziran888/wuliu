using CustomExtensions;
using SuperCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.ApiCommand
{
    /// <summary>
    /// 微信签名
    /// </summary>
    [SuperCommand.Attribute.Doc(typeof(CMD_JSSignature), "微信签名")]
    public class CMD_JSSignature : WebCommandBase, ICommandBase<WebCommandVOBase>
    {
        public CMD_JSSignature() : base(false) { }
        public TCommandState ExeCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            string appid = web.GetValue("appid");
            //string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
            //获取APPID
            if (appid.StrIsNull())
                appid = System.Configuration.ConfigurationManager.AppSettings["AppID"];

            string url = web.GetValue("url");
            if (url.StrIsNull())
                return Show<TCommandState>("访问的地址不能为空!");
            var AccToKen = Global.GetAccessToKen();
            if (AccToKen.flag)
            {
                var ghfu = Tools.GetHtml.GetHtmlFromUrl("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccToKen.ACCTOKEN.AccessToken + "&type=jsapi", string.Empty, null, null);
                Tools.SaveLog.AddLog("JSSignature.cs===OpenURL:" + " 结束时间:" + AccToKen.ACCTOKEN.overTime + " https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + AccToKen.ACCTOKEN.AccessToken + "&type=jsapi");
                if (ghfu.Item1)
                {
                    var jsonobj = Tools.MakeJson.JsonToLinqObject(ghfu.Item2);
                    int errcode = jsonobj.TryGetValue<int>("errcode");
                    if (errcode == 0)
                    {
                        string ticket = jsonobj.TryGetValue<string>("ticket");
                        int expires_in = jsonobj.TryGetValue<int>("expires_in");

                        //签名算法
                        string signature = string.Empty;
                        int timestamp = Tools.MakeTime.ConvertDateTimeInt(DateTime.Now);
                        string noncestr = "afiuewjflsdaougewaeoufivnyaojlgoasfdas";
                        GetSignature(ticket, noncestr, timestamp, url, out signature);
                        return Show<TCommandState>(new
                        {
                            noncestr,
                            timestamp,
                            ticket,
                            expires_in,
                            signature
                        });
                    }
                    else
                    {
                        //清空
                        Global.RemoveAdvertiserUser();
                        Tools.SaveLog.AddLog(ghfu.Item2);
                        return Show<TCommandState>();
                    }
                }
            }
            return Show<TCommandState>("还没做完!");
        }
        private void GetSignature(string ticket, string noncestr, int timestamp, string url, out string signature)
        {
            signature = Tools.MakeEncryption.Sha1("jsapi_ticket=" + ticket + "&noncestr=" + noncestr + "&timestamp=" + timestamp + "&url=" + url);
        }
    }
}