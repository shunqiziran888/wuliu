using System;
namespace Model.Model
{
    /// <summary>
    /// 物流车辆绑定表
    /// </summary>
    [Serializable]
    public partial class LC_VehicleBinding : ModelBase
    {
        public LC_VehicleBinding()
        {}
        /// <summary>
        /// 
        /// </summary>
        private long? _id;
        /// <summary>
        /// 
        /// </summary>
        private long? _VehicleID;
        /// <summary>
        /// 司机UID
        /// </summary>
        private string _DriverUID;
        /// <summary>
        /// 绑定时间
        /// </summary>
        private DateTime? _BindingTime;
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
        public long? VehicleID
        {
            set { _VehicleID = value;}
            get { return _VehicleID; }
        }
        /// <summary>
        /// 司机UID
        /// </summary>
        public string DriverUID
        {
            set { _DriverUID = value;}
            get { return _DriverUID; }
        }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime? BindingTime
        {
            set { _BindingTime = value;}
            get { return _BindingTime; }
        }
    }
}
