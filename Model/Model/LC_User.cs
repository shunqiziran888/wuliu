using System;
namespace Model.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_User : ModelBase
    {
        public LC_User()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 用户ID
        /// </summary>
        private string _UID;
        /// <summary>
        /// 用户名称
        /// </summary>
        private string _UserName;
        /// <summary>
        /// 职位ID
        /// </summary>
        private int? _PositionID;
        /// <summary>
        /// 电话
        /// </summary>
        private string _Phone;
        /// <summary>
        /// 注册时间
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 账号
        /// </summary>
        private string _ZNumber;
        /// <summary>
        /// 密码
        /// </summary>
        private string _Password;
        /// <summary>
        /// 账号类型
        /// </summary>
        private int? _ZType;
        /// <summary>
        /// 状态
        /// </summary>
        private int? _State;
        /// <summary>
        /// 
        /// </summary>
        private string _LogisticsName;
        /// <summary>
        /// 省份
        /// </summary>
        private int? _ProvincesID;
        /// <summary>
        /// 城市
        /// </summary>
        private int? _CityID;
        /// <summary>
        /// 地区
        /// </summary>
        private int? _AreaID;
        /// <summary>
        /// 
        /// </summary>
        private string _LCID;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID
        {
            set { _UID = value;}
            get { return _UID; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _UserName = value;}
            get { return _UserName; }
        }
        /// <summary>
        /// 职位ID
        /// </summary>
        public int? PositionID
        {
            set { _PositionID = value;}
            get { return _PositionID; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _Phone = value;}
            get { return _Phone; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value;}
            get { return _CreateTime; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string ZNumber
        {
            set { _ZNumber = value;}
            get { return _ZNumber; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _Password = value;}
            get { return _Password; }
        }
        /// <summary>
        /// 账号类型
        /// </summary>
        public int? ZType
        {
            set { _ZType = value;}
            get { return _ZType; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogisticsName
        {
            set { _LogisticsName = value;}
            get { return _LogisticsName; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public int? ProvincesID
        {
            set { _ProvincesID = value;}
            get { return _ProvincesID; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public int? CityID
        {
            set { _CityID = value;}
            get { return _CityID; }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public int? AreaID
        {
            set { _AreaID = value;}
            get { return _AreaID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LCID
        {
            set { _LCID = value;}
            get { return _LCID; }
        }
    }
}
