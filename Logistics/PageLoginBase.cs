﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomExtensions;
namespace Logistics
{
    public class PageLoginBase : PageBase
    {
        public bool checklogin = true;
        public PageLoginBase(bool _checklogin = true)
        {
            checklogin = _checklogin;
        }

        protected override void OnLoad(EventArgs e)
        {
            //判断是否登录
            if (checklogin)
            {
                if (!this.CheckLogin())
                {
                    //跳转到登陆页面
                    AlertJump("您还没有登录", "/Login/Login.aspx");
                    Response.End();
                    return;
                }
            }
            base.OnLoad(e);
        }
        /// <summary>
        /// 获取登录人数据
        /// </summary>
        internal GlobalBLL.UserLoginVO GetMyLoginUserVO()
        {
            return new GlobalBLL.UserLoginVO()
            {
                phones = GetSessionValue("phones"),
                username = GetSessionValue("username"),
                account = GetSessionValue("account"),
                accountType = GetSessionValue("accountType").ConvertData<GlobalBLL.AccountTypeEnum>(),
                id = GetSessionValue("id").ConvertData<long>(),
                positionID = GetSessionValue("positionID").ConvertData<int>(),
                state = GetSessionValue("state").ConvertData<int>(),
                uid = GetSessionValue("uid"),
                ProvincesID = GetSessionValue("ProvincesID").ConvertData<int>(),
                AreaID = GetSessionValue("AreaID").ConvertData<int>(),
                CityID = GetSessionValue("CityID").ConvertData<int>(),
            };
        }

        private bool CheckLogin()
        {
            //判断session
            if (GetSessionValue("islogin")?.Equals("true", StringComparison.InvariantCultureIgnoreCase) ?? false)
            {
                return true;
            }
            return false;
        }
        //提示
        internal void Alert(string msg)
        {
           Response.Write($"<script>alert('{msg}');</script>");
        }
        //提示，跳转
        internal void AlertJump(string msg,string href)
        {
            Response.Write($"<script>alert('{msg}');window.location.href ='" +href+"'</script>");
        }
        //跳转
        internal void Jump(string tz)
        {
            Response.Redirect(tz);
        }
    }
}