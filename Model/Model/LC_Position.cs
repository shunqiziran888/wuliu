using System;
namespace Model.Model
{
    /// <summary>
    /// 员工类型表
    /// </summary>
    [Serializable]
    public partial class LC_Position : ModelBase
    {
        public LC_Position()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 职位ID
        /// </summary>
        private string _PositionID;
        /// <summary>
        /// 职位名称
        /// </summary>
        private string _PositionName;
        /// <summary>
        /// 图标
        /// </summary>
        private string _Icon;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 职位ID
        /// </summary>
        public string PositionID
        {
            set { _PositionID = value;}
            get { return _PositionID; }
        }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName
        {
            set { _PositionName = value;}
            get { return _PositionName; }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            set { _Icon = value;}
            get { return _Icon; }
        }
    }
}
