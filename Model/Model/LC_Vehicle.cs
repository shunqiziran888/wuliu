using System;
namespace Model.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Vehicle : ModelBase
    {
        public LC_Vehicle()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 
        /// </summary>
        private string _VehicleNo;
        /// <summary>
        /// 
        /// </summary>
        private string _Driver;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 
        /// </summary>
        private string _UID;
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
        public string VehicleNo
        {
            set { _VehicleNo = value;}
            get { return _VehicleNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Driver
        {
            set { _Driver = value;}
            get { return _Driver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value;}
            get { return _CreateTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UID
        {
            set { _UID = value;}
            get { return _UID; }
        }
    }
}
