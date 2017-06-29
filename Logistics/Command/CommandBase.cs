using SuperCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.Command
{
    public class CommandBase
    {
        [ThreadStatic]
        public static HttpContextBase web = null;
        [ThreadStatic]
        public static LogCommandVO _command = null;

        private bool CheckLogin = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_CheckLogin">验证登陆为true</param>
        public CommandBase(bool _CheckLogin = true)
        {
            this.CheckLogin = _CheckLogin;
        }

        public Tuple<bool, string> InitCommand<TCommandState>(LogCommandVO command) where TCommandState : CommandState, new()
        {
            _command = command;
            web = command.web;
            ////验证登陆
            //if (CheckLogin)
            //{
            //    //获取我登陆的数据
            //    var myuservo = web.GetMyLoginUserVO();
            //    if (!myuservo.IsLogin)
            //        return new Tuple<bool, string>(false, "您还没有登陆!");
            //    return new Tuple<bool, string>(true, string.Empty);
            //}
            return new Tuple<bool, string>(true, string.Empty);
        }


        internal TCommandState Show<TCommandState>(Tuple<bool, string> vo) where TCommandState : CommandState, new()
        {
            return vo.Item1 ? Show<TCommandState>() : Show<TCommandState>(vo.Item2);
        }

        public TCommandState Show<TCommandState>(Tuple<bool, string, object> vo) where TCommandState : CommandState, new()
        {
            if (vo.Item1)
            {
                return Show<TCommandState>(vo.Item3);
            }
            else
            {
                return Show<TCommandState>(vo.Item2);
            }
        }

        /// <summary>
        /// 根据默认key输出一个内容
        /// </summary>
        /// <param name="data"></param>
        public TCommandState Show<TCommandState>(object data) where TCommandState : CommandState, new()
        {
            return Show<TCommandState>(_command.Cmd, data, MessageEnum.Success);
        }

        /// <summary>
        /// 输出一个错误
        /// </summary>
        /// <param name="alertMsg"></param>
        public TCommandState Show<TCommandState>(string alertMsg) where TCommandState : CommandState, new()
        {
            return Show<TCommandState>(_command.Cmd, alertMsg, MessageEnum.MsgError, false);
        }
        /// <summary>
        ///输出成功
        /// </summary>
        /// <typeparam name="TCommandState"></typeparam>
        /// <returns></returns>
        internal TCommandState Show<TCommandState>() where TCommandState : CommandState, new()
        {
            return Show<TCommandState>(_command.Cmd, "success", MessageEnum.Success, true);
        }

        internal TCommandState Show<TCommandState>(string key, object data, MessageEnum state, bool flag = true) where TCommandState : CommandState, new()
        {
            TCommandState cs = new TCommandState()
            {
                data = data,
                flag = flag,
                key = key,
                state = state.ConvertData<int>()
            };
            return cs;
        }
    }
}