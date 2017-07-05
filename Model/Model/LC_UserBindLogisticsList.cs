using System;
namespace Model.Model
{
    /// <summary>
    /// 绑定物流表
    /// </summary>
    [Serializable]
    public partial class LC_UserBindLogisticsList : ModelBase
    {
        public LC_UserBindLogisticsList()
        {}
        /// <summary>
        /// 
        /// </summary>
        private long? _id;
        /// <summary>
        /// 
        /// </summary>
        private string _Uid;
        /// <summary>
        /// 
        /// </summary>
        private string _LogisticsUid;
        /// <summary>
        /// 绑定时间
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value;}
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Uid
        {
            set { _Uid = value;}
            get { return _Uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogisticsUid
        {
            set { _LogisticsUid = value;}
            get { return _LogisticsUid; }
        }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value;}
            get { return _CreateTime; }
        }
    }
}
