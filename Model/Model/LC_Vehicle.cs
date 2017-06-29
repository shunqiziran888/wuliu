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
        { }
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        private string _VehicleNo;
        private string _Driver;
        private DateTime? _CreateTime;
        private string _UID;

        public int? ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string VehicleNo
        {
            get
            {
                return _VehicleNo;
            }

            set
            {
                _VehicleNo = value;
            }
        }

        public string Driver
        {
            get
            {
                return _Driver;
            }

            set
            {
                _Driver = value;
            }
        }

        public DateTime? CreateTime
        {
            get
            {
                return _CreateTime;
            }

            set
            {
                _CreateTime = value;
            }
        }

        public string UID
        {
            get
            {
                return _UID;
            }

            set
            {
                _UID = value;
            }
        }
    }
}
