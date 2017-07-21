using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SuperCommand;
using CustomExtensions;
using Logistics.ApiCommand;
using GlobalBLL;

namespace Logistics
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //初始化
            GlobalBLL.HttpContextBase hcb = new GlobalBLL.HttpContextBase(context);
            //获取键值
            if (WebCommandRun.GetInstance._command == null)
                WebCommandRun.GetInstance._command = new SuperCommand.CommandRun<WebCommandVOBase>(this.GetType());

            string cmd = hcb.GetValue("action"); //直接命令

            string subcmd = hcb.GetValue("subcmd"); //子命令
            MessageState cmdstate = null;
            if (cmd.StrIsNotNull())
            {
                //进行初始化
                cmdstate = WebCommandRun.GetInstance._command.Run<MessageState>(new WebCommandVOBase()
                {
                    Cmd = cmd,
                    SubCmd = subcmd,
                    web = hcb
                });
                if (cmdstate == null)
                    return;
            }
            else
            {
                cmdstate = new MessageState()
                {
                    state = MessageEnum.MsgError.EnumToInt(),
                    data = "参数Action错误!",
                    flag = false
                };
            }
            //显示数据
            string msg = MessageState.OutPutShow(cmdstate.key, cmdstate.data, cmdstate.state.ConvertData<MessageEnum>());
            string jsonpCallback = hcb.GetValue("jsonpcallback");
            string JumpUrl = hcb.GetValue("JumpUrl");
            string OutPutMsg = string.Empty;


            if (jsonpCallback.StrIsNull())
            {
                Tools.SaveLog.AddLog("没有获取到:jsonpcallback 内容:" + msg, "jsonpCallback是空的");
                context.Response.Headers.Add("content-type", "application:json;charset=utf8");
                context.Response.Headers.Add("Access-Control-Allow-Origin", context?.Request?.Headers["Origin"] ?? "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, HEAD, POST, PUT, DELETE, TRACE, OPTIONS, PATCH");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Session, X-Requested-With, accept, content-type");
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

                OutPutMsg = msg;
            }
            else
            {
                OutPutMsg = jsonpCallback + "(" + msg + ");";
            }
            if (JumpUrl.StrIsNotNull())
            {
                context.Response.Redirect(JumpUrl + "?data=" + System.Web.HttpUtility.UrlEncode(OutPutMsg));
            }
            else
            {
                context.Response.Write(OutPutMsg);
            }
            Tools.SaveLog.AddLog(msg, "OutPutMsg");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}