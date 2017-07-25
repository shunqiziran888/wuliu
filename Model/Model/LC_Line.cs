using System;
namespace Model.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Line : ModelBase
    {
        public LC_Line()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 线路ID
        /// </summary>
        private string _LineID;
        /// <summary>
        /// 线路起始地
        /// </summary>
        private int? _Start;
        /// <summary>
        /// 线路结束地
        /// </summary>
        private int? _End;
        /// <summary>
        /// （我方）负责人联系电话
        /// </summary>
        private string _MyPhone;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 物流公司UID
        /// </summary>
        private string _UID;
        /// <summary>
        /// 线路首字母
        /// </summary>
        private string _Lineletter;
        /// <summary>
        /// 绑定的物流UID
        /// </summary>
        private string _BindLogisticsUid;
        /// <summary>
        /// (我方)负责人姓名
        /// </summary>
        private string _MyResponsibleName;
        /// <summary>
        /// 0 未授权,1已授权,2已删除
        /// </summary>
        private int? _State;
        /// <summary>
        /// 申请人（主动申请需要对方授权的用户）
        /// </summary>
        private string _ApplicantUID;
        /// <summary>
        /// (对方)电话
        /// </summary>
        private string _DFPhone;
        /// <summary>
        /// (对方)负责人名称
        /// </summary>
        private string _DFResponsibleName;
        /// <summary>
        /// 开通时间
        /// </summary>
        private DateTime? _OpenTime;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 线路ID
        /// </summary>
        public string LineID
        {
            set { _LineID = value;}
            get { return _LineID; }
        }
        /// <summary>
        /// 线路起始地
        /// </summary>
        public int? Start
        {
            set { _Start = value;}
            get { return _Start; }
        }
        /// <summary>
        /// 线路结束地
        /// </summary>
        public int? End
        {
            set { _End = value;}
            get { return _End; }
        }
        /// <summary>
        /// （我方）负责人联系电话
        /// </summary>
        public string MyPhone
        {
            set { _MyPhone = value;}
            get { return _MyPhone; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value;}
            get { return _CreateTime; }
        }
        /// <summary>
        /// 物流公司UID
        /// </summary>
        public string UID
        {
            set { _UID = value;}
            get { return _UID; }
        }
        /// <summary>
        /// 线路首字母
        /// </summary>
        public string Lineletter
        {
            set { _Lineletter = value;}
            get { return _Lineletter; }
        }
        /// <summary>
        /// 绑定的物流UID
        /// </summary>
        public string BindLogisticsUid
        {
            set { _BindLogisticsUid = value;}
            get { return _BindLogisticsUid; }
        }
        /// <summary>
        /// (我方)负责人姓名
        /// </summary>
        public string MyResponsibleName
        {
            set { _MyResponsibleName = value;}
            get { return _MyResponsibleName; }
        }
        /// <summary>
        /// 0 未授权,1已授权,2已删除
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
        /// <summary>
        /// 申请人（主动申请需要对方授权的用户）
        /// </summary>
        public string ApplicantUID
        {
            set { _ApplicantUID = value;}
            get { return _ApplicantUID; }
        }
        /// <summary>
        /// (对方)电话
        /// </summary>
        public string DFPhone
        {
            set { _DFPhone = value;}
            get { return _DFPhone; }
        }
        /// <summary>
        /// (对方)负责人名称
        /// </summary>
        public string DFResponsibleName
        {
            set { _DFResponsibleName = value;}
            get { return _DFResponsibleName; }
        }
        /// <summary>
        /// 开通时间
        /// </summary>
        public DateTime? OpenTime
        {
            set { _OpenTime = value;}
            get { return _OpenTime; }
        }
    }
}
