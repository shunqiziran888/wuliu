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
        /// 
        /// </summary>
        private string _LineID;
        /// <summary>
        /// 
        /// </summary>
        private int? _Start;
        /// <summary>
        /// 
        /// </summary>
        private int? _End;
        /// <summary>
        /// 
        /// </summary>
        private int? _UserID;
        /// <summary>
        /// 
        /// </summary>
        private string _Phone;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _DateTime;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LineID
        {
            set { _LineID = value;}
            get { return _LineID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Start
        {
            set { _Start = value;}
            get { return _Start; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? End
        {
            set { _End = value;}
            get { return _End; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _UserID = value;}
            get { return _UserID; }
        }
        /// <summary>
        /// 
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
        /// 
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
    }
}
