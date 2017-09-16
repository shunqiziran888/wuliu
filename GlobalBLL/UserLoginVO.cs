using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL
{
    /// <summary>
    /// 用户登录的VO
    /// </summary>
    public class UserLoginVO
    {
        /// <summary>
        /// 是否已经登录过
        /// </summary>
        public bool IsLogin { get; set; } = false;
        public long id { get; set; }

        public string uid { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phones { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public int positionID { get; set; }
        /// <summary>
        /// 帐号类型
        /// </summary>
        public AccountTypeEnum accountType { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public int ProvincesID { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public int CityID { get; set; }
        /// <summary>
        /// 区ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        public string OpenID { get; set; }
        public string HeadPic { get; set; }
        public int Sex { get; set; }
        /// <summary>
        /// 省（微信）
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市（微信）
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区（微信）
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 物流名称
        /// </summary>
        public string LogisticsName { get; set; }
    }
}
