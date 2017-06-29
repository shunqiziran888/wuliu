using System;
namespace Model.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Region : ModelBase
    {
        public LC_Region()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 父级
        /// </summary>
        private int? _Pid;
        /// <summary>
        /// 地区名称
        /// </summary>
        private string _District;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 父级
        /// </summary>
        public int? Pid
        {
            set { _Pid = value;}
            get { return _Pid; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string District
        {
            set { _District = value;}
            get { return _District; }
        }
    }
}
