using System;
using Model.Model;
using CustomExtensions;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_User : BLLBase
    {
        public LC_User()
        {}
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User,GlobalBLL.UserLoginVO loginvo, string LogisticsUid="")
        {
            //if (lC_User.UserName.StrIsNull())
            //    return new Tuple<bool, string>(false, "昵称不能为空!");
            return DAL.DAL.LC_User.Add(lC_User, loginvo, LogisticsUid);
        }
        /// <summary>
        /// 验证是否需要注册
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetToRegUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            return DAL.DAL.LC_User.GetToRegUser(myuservo);
        }

        /// <summary>
        /// 添加或者更新账号
        /// </summary>
        /// <param name="web"></param>
        /// <param name="suser"></param>
        /// <param name="rtype">类型</param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(HttpContextBase web,Model.Model.LC_User suser)
        {
            //验证数据是否正确
            if (suser.WX_OpenID.StrIsNull())
                return (false, "OPENID不能为空!",null);
            return DAL.DAL.LC_User.AddOrUpdateUserVO(suser);
        }
    }
}