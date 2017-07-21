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
        /// ע���û�
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User,GlobalBLL.UserLoginVO loginvo, string LogisticsUid="")
        {
            //if (lC_User.UserName.StrIsNull())
            //    return new Tuple<bool, string>(false, "�ǳƲ���Ϊ��!");
            return DAL.DAL.LC_User.Add(lC_User, loginvo, LogisticsUid);
        }
        /// <summary>
        /// ��֤�Ƿ���Ҫע��
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetToRegUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            return DAL.DAL.LC_User.GetToRegUser(myuservo);
        }

        /// <summary>
        /// ��ӻ��߸����˺�
        /// </summary>
        /// <param name="web"></param>
        /// <param name="suser"></param>
        /// <param name="rtype">����</param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(HttpContextBase web,Model.Model.LC_User suser)
        {
            //��֤�����Ƿ���ȷ
            if (suser.WX_OpenID.StrIsNull())
                return (false, "OPENID����Ϊ��!",null);
            return DAL.DAL.LC_User.AddOrUpdateUserVO(suser);
        }
    }
}