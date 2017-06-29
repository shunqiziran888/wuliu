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
        public int CityID { get; set; }
        public int AreaID { get; set; }

    }
}
