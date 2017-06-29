using SuperCommand.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Logistics
{
    public class MessageState : SuperCommand.CommandState
    {
        public override int state { get; set; }

        /// <summary>
        /// 显示输出
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string OutPutShow(string key, object data = null, MessageEnum me = MessageEnum.Success)
        {
            if (data == null)
                data = "";
            string mestr = me.ToString();
            MessageState ms = new MessageState()
            {
                key = key
            };
            System.Type t = me.GetType();
            FieldInfo[] filist = t.GetFields();
            foreach (var fi in filist)
            {
                if (fi.Name == mestr)
                {
                    MsgStateAttribute ai = (MsgStateAttribute)System.Attribute.GetCustomAttribute(fi, typeof(MsgStateAttribute), false);
                    ms.SetMsgState(ai.GetMsg());
                    break;
                }
            }
            ms.data = data;
            ms.state = me.ConvertData<int>();
            return MakeJson.ObjectToJson(new
            {
                ms.state,
                ms.key,
                ms.data
            }, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 显示输出
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string OutPutShow(object data, string msg)
        {
            MessageState ms = new MessageState()
            {
                data = data
            };
            ms.SetMsgState(msg);
            ms.state = MessageEnum.OtherError.ConvertData<int>();
            return MakeJson.ObjectToJson(new
            {
                ms.state,
                ms.key,
                ms.data
            }, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 输出文本
        /// </summary>
        /// <param name="msg"></param>

    }
}