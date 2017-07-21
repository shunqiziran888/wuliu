﻿using CustomExtensions;
using GlobalBLL;
using SuperCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.ApiCommand
{
    public class WebCommandBase
    {
        [ThreadStatic]
        private static WebCommandVOBase _command = null;
        [ThreadStatic]
        public static GlobalBLL.HttpContextBase web = null;
        private bool CheckLogin = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_CheckLogin">验证登陆为true</param>
        public WebCommandBase(bool _CheckLogin = true)
        {
            this.CheckLogin = _CheckLogin;
        }

        public (bool state, string msg) InitCommand<TCommandState>(WebCommandVOBase command) where TCommandState : CommandState, new()
        {
            _command = command;
            web = _command.web;
            //验证登陆
            if (CheckLogin)
            {
                //获取我登陆的数据
                var myuservo = web.GetMyLoginUserVO();
                if (!myuservo.IsLogin)
                    return (false, "您还没有登陆!");
                return (true, string.Empty);
            }
            return (true, string.Empty);
        }

        internal TCommandState Show<TCommandState>((bool state, string msg) vo) where TCommandState : CommandState, new()
        {
            return vo.state ? Show<TCommandState>() : Show<TCommandState>(vo.msg);
        }

        public TCommandState Show<TCommandState>((bool state, string msg, object obj) vo) where TCommandState : CommandState, new()
        {
            if (vo.state)
            {
                return Show<TCommandState>(vo.obj);
            }
            else
            {
                return Show<TCommandState>(vo.msg);
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