using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions;
namespace GlobalBLL
{
    public class HttpContextBase : SuperCommand.HttpContextBase
    {
        public HttpContextBase(System.Web.HttpContext _hc) : base(_hc)
        {

        }

        /// <summary>
        /// 获取我的loginvo
        /// </summary>
        public new UserLoginVO GetMyLoginUserVO()
        {
            return new UserLoginVO()
            {
                id = GetLoginValue<long>(LoginEnum.id),
                uid = GetLoginValue(LoginEnum.uid),
                NickName = GetLoginValue(LoginEnum.NickName),
                OpenID = GetLoginValue(LoginEnum.OpenID),
                HeadPic = GetLoginValue(LoginEnum.HeadPic),
                Sex = GetLoginValue<int>(LoginEnum.Sex),
                IsLogin = GetLoginValue<bool>(LoginEnum.IsLogin),
                accountType = GetLoginValue<AccountTypeEnum>(LoginEnum.accountType),
                account = GetLoginValue(LoginEnum.account),
                AreaID = GetLoginValue<int>(LoginEnum.AreaID),
                City = GetLoginValue(LoginEnum.City),
                CityID = GetLoginValue<int>(LoginEnum.CityID),
                Country = GetLoginValue(LoginEnum.Country),
                phones = GetLoginValue(LoginEnum.phones),
                positionID = GetLoginValue<int>(LoginEnum.positionID),
                Province = GetLoginValue(LoginEnum.Province),
                ProvincesID = GetLoginValue<int>(LoginEnum.ProvincesID),
                state = GetLoginValue<int>(LoginEnum.state),
                username = GetLoginValue(LoginEnum.username)
            };
        }

        /// <summary>
        /// 获取登陆的数据
        /// </summary>
        /// <param name="loginEnum"></param>
        /// <returns></returns>
        private T GetLoginValue<T>(LoginEnum loginEnum)
        {
            return GetSessionValue(loginEnum.EnumToName()).ConvertData<T>();
        }
        /// <summary>
        /// 获取登陆的数据
        /// </summary>
        /// <param name="loginEnum"></param>
        /// <returns></returns>
        private string GetLoginValue(LoginEnum loginEnum)
        {
            return GetSessionValue(loginEnum.EnumToName());
        }
    }
}
