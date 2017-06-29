using System;
namespace Model.Model
{
    /// <summary>
    /// 省市区基本数据表
    /// </summary>
    [Serializable]
    public partial class w_address_basic_data : ModelBase
    {
        public w_address_basic_data()
        {}
        /// <summary>
        /// 
        /// </summary>
        private string _Name;
        /// <summary>
        ///  上一层地址ID
        /// </summary>
        private int? _TopAddressID;
        /// <summary>
        /// 
        /// </summary>
        private int? _id;
        /// <summary>
        /// 人口数
        /// </summary>
        private int? _Population;
        /// <summary>
        /// 热门城市 1为热门，0非热门
        /// </summary>
        private int? _IsHot;
        /// <summary>
        /// 主要城市
        /// </summary>
        private int? _MainCity;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _Name = value;}
            get { return _Name; }
        }
        /// <summary>
        ///  上一层地址ID
        /// </summary>
        public int? TopAddressID
        {
            set { _TopAddressID = value;}
            get { return _TopAddressID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? id
        {
            set { _id = value;}
            get { return _id; }
        }
        /// <summary>
        /// 人口数
        /// </summary>
        public int? Population
        {
            set { _Population = value;}
            get { return _Population; }
        }
        /// <summary>
        /// 热门城市 1为热门，0非热门
        /// </summary>
        public int? IsHot
        {
            set { _IsHot = value;}
            get { return _IsHot; }
        }
        /// <summary>
        /// 主要城市
        /// </summary>
        public int? MainCity
        {
            set { _MainCity = value;}
            get { return _MainCity; }
        }
    }
}
