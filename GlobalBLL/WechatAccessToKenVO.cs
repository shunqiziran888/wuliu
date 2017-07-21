using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalBLL
{
    /// <summary>
    /// 微信的安全AccessTokenVO
    /// </summary>
    public class WechatAccessToKenVO
    {
        /// <summary>
        /// 获取的AccessToken
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 公共账号的APPID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// 公众号密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 公众号账号的原始ID
        /// </summary>
        public string OriginalID { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime overTime { get; set; }
    }
}
