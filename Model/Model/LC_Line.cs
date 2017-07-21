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
        /// 负责人联系电话
        /// </summary>
        private string _Phone;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _DateTime;
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
        /// 负责人姓名
        /// </summary>
        private string _ResponsibleName;
        /// <summary>
        /// 0 未授权,1已授权
        /// </summary>
        private int? _State;
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
        /// 负责人联系电话
        /// </summary>
        public string Phone
        {
            set { _Phone = value;}
            get { return _Phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateTime
        {
            set { _DateTime = value;}
            get { return _DateTime; }
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
        /// 负责人姓名
        /// </summary>
        public string ResponsibleName
        {
            set { _ResponsibleName = value;}
            get { return _ResponsibleName; }
        }
        /// <summary>
        /// 0 未授权,1已授权
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
    }
}
