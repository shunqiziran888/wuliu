using System;
namespace Model.Model
{
    /// <summary>
    /// 车辆表
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
        /// 车号
        /// </summary>
        private string _VehicleNo;
        /// <summary>
        /// （注册人）司机名字
        /// </summary>
        private string _Driver;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 物流公司UID
        /// </summary>
        private string _UID;
        /// <summary>
        /// 车辆长度(车型）
        /// </summary>
        private float? _Carshape;
        /// <summary>
        /// 电话
        /// </summary>
        private string _Phone;
        /// <summary>
        /// 0不可用 1可用(已绑定)
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
        /// 车号
        /// </summary>
        public string VehicleNo
        {
            set { _VehicleNo = value;}
            get { return _VehicleNo; }
        }
        /// <summary>
        /// （注册人）司机名字
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
        /// 物流公司UID
        /// </summary>
        public string UID
        {
            set { _UID = value;}
            get { return _UID; }
        }
        /// <summary>
        /// 车辆长度(车型）
        /// </summary>
        public float? Carshape
        {
            set { _Carshape = value;}
            get { return _Carshape; }
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
        /// 0不可用 1可用(已绑定)
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
    }
}
