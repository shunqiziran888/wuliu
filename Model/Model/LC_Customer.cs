using System;
namespace Model.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    [Serializable]
    public partial class LC_Customer : ModelBase
    {
        public LC_Customer()
        {}
        /// <summary>
        /// 
        /// </summary>
        private int? _ID;
        /// <summary>
        /// 订单ID
        /// </summary>
        private string _OrderID;
        /// <summary>
        /// 收货人姓名
        /// </summary>
        private string _Consignee;
        /// <summary>
        /// 发货人UID
        /// </summary>
        private string _ConsignorID;
        /// <summary>
        /// 发货人姓名
        /// </summary>
        private string _Consignor;
        /// <summary>
        /// 物流公司ID
        /// </summary>
        private string _logisticsID;
        /// <summary>
        /// 发货人电话
        /// </summary>
        private string _FHPhone;
        /// <summary>
        /// 收货人电话
        /// </summary>
        private string _SHPhone;
        /// <summary>
        /// 目的地
        /// </summary>
        private int? _Destination;
        /// <summary>
        /// 物品名称
        /// </summary>
        private string _GoodName;
        /// <summary>
        /// 件数
        /// </summary>
        private int? _Number;
        /// <summary>
        /// 货号
        /// </summary>
        private string _GoodNo;
        /// <summary>
        /// 代收款
        /// </summary>
        private decimal? _GReceivables;
        /// <summary>
        /// 运费
        /// </summary>
        private decimal? _Freight;
        /// <summary>
        /// 提货方式(客户自提=1, 送货上门=2)
        /// </summary>
        private int? _CarryGood;
        /// <summary>
        /// 收货方式(我方去送 = 1,物流来提 = 2）
        /// </summary>
        private int? _ReceiptGood;
        /// <summary>
        /// （运费方式）（提付 = 1, 现付 = 2, 扣付 = 3）
        /// </summary>
        private int? _freightMode;
        /// <summary>
        /// 订单生成时间
        /// </summary>
        private DateTime? _DdTime;
        /// <summary>
        /// 收货时间
        /// </summary>
        private DateTime? _ConsigneeTime;
        /// <summary>
        /// 运费提付金额
        /// </summary>
        private decimal? _FreightCollect;
        /// <summary>
        /// 其他费用
        /// </summary>
        private decimal? _OtherExpenses;
        /// <summary>
        /// 合计
        /// </summary>
        private decimal? _Total;
        /// <summary>
        /// 订单状态（已发货=1,物流已收货 = 2,已装车运输中 = 3,已到收货地可提货 = 4,客户取货=5,订单完成=6,货物已中转=7）
        /// </summary>
        private int? _State;
        /// <summary>
        /// 出发地
        /// </summary>
        private int? _Initially;
        /// <summary>
        /// 车号ID
        /// </summary>
        private int? _VehicleID;
        /// <summary>
        /// 大车运费
        /// </summary>
        private decimal? _largeCar;
        /// <summary>
        /// 装车时间
        /// </summary>
        private DateTime? _TruckTime;
        /// <summary>
        /// 到达目的地（最后接车的时间）
        /// </summary>
        private DateTime? _MeetCarTime;
        /// <summary>
        /// 放货时间
        /// </summary>
        private DateTime? _DischargeTime;
        /// <summary>
        /// 当前物流路线出发地
        /// </summary>
        private int? _begins;
        /// <summary>
        /// 当前物流路线目的地
        /// </summary>
        private int? _finish;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _ID = value;}
            get { return _ID; }
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID
        {
            set { _OrderID = value;}
            get { return _OrderID; }
        }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Consignee
        {
            set { _Consignee = value;}
            get { return _Consignee; }
        }
        /// <summary>
        /// 发货人UID
        /// </summary>
        public string ConsignorID
        {
            set { _ConsignorID = value;}
            get { return _ConsignorID; }
        }
        /// <summary>
        /// 发货人姓名
        /// </summary>
        public string Consignor
        {
            set { _Consignor = value;}
            get { return _Consignor; }
        }
        /// <summary>
        /// 物流公司ID
        /// </summary>
        public string logisticsID
        {
            set { _logisticsID = value;}
            get { return _logisticsID; }
        }
        /// <summary>
        /// 发货人电话
        /// </summary>
        public string FHPhone
        {
            set { _FHPhone = value;}
            get { return _FHPhone; }
        }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string SHPhone
        {
            set { _SHPhone = value;}
            get { return _SHPhone; }
        }
        /// <summary>
        /// 目的地
        /// </summary>
        public int? Destination
        {
            set { _Destination = value;}
            get { return _Destination; }
        }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string GoodName
        {
            set { _GoodName = value;}
            get { return _GoodName; }
        }
        /// <summary>
        /// 件数
        /// </summary>
        public int? Number
        {
            set { _Number = value;}
            get { return _Number; }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string GoodNo
        {
            set { _GoodNo = value;}
            get { return _GoodNo; }
        }
        /// <summary>
        /// 代收款
        /// </summary>
        public decimal? GReceivables
        {
            set { _GReceivables = value;}
            get { return _GReceivables; }
        }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal? Freight
        {
            set { _Freight = value;}
            get { return _Freight; }
        }
        /// <summary>
        /// 提货方式(客户自提=1, 送货上门=2)
        /// </summary>
        public int? CarryGood
        {
            set { _CarryGood = value;}
            get { return _CarryGood; }
        }
        /// <summary>
        /// 收货方式(我方去送 = 1,物流来提 = 2）
        /// </summary>
        public int? ReceiptGood
        {
            set { _ReceiptGood = value;}
            get { return _ReceiptGood; }
        }
        /// <summary>
        /// （运费方式）（提付 = 1, 现付 = 2, 扣付 = 3）
        /// </summary>
        public int? freightMode
        {
            set { _freightMode = value;}
            get { return _freightMode; }
        }
        /// <summary>
        /// 订单生成时间
        /// </summary>
        public DateTime? DdTime
        {
            set { _DdTime = value;}
            get { return _DdTime; }
        }
        /// <summary>
        /// 收货时间
        /// </summary>
        public DateTime? ConsigneeTime
        {
            set { _ConsigneeTime = value;}
            get { return _ConsigneeTime; }
        }
        /// <summary>
        /// 运费提付金额
        /// </summary>
        public decimal? FreightCollect
        {
            set { _FreightCollect = value;}
            get { return _FreightCollect; }
        }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherExpenses
        {
            set { _OtherExpenses = value;}
            get { return _OtherExpenses; }
        }
        /// <summary>
        /// 合计
        /// </summary>
        public decimal? Total
        {
            set { _Total = value;}
            get { return _Total; }
        }
        /// <summary>
        /// 订单状态（已发货=1,物流已收货 = 2,已装车运输中 = 3,已到收货地可提货 = 4,客户取货=5,订单完成=6,货物已中转=7）
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
        /// <summary>
        /// 出发地
        /// </summary>
        public int? Initially
        {
            set { _Initially = value;}
            get { return _Initially; }
        }
        /// <summary>
        /// 车号ID
        /// </summary>
        public int? VehicleID
        {
            set { _VehicleID = value;}
            get { return _VehicleID; }
        }
        /// <summary>
        /// 大车运费
        /// </summary>
        public decimal? largeCar
        {
            set { _largeCar = value;}
            get { return _largeCar; }
        }
        /// <summary>
        /// 装车时间
        /// </summary>
        public DateTime? TruckTime
        {
            set { _TruckTime = value;}
            get { return _TruckTime; }
        }
        /// <summary>
        /// 到达目的地（最后接车的时间）
        /// </summary>
        public DateTime? MeetCarTime
        {
            set { _MeetCarTime = value;}
            get { return _MeetCarTime; }
        }
        /// <summary>
        /// 放货时间
        /// </summary>
        public DateTime? DischargeTime
        {
            set { _DischargeTime = value;}
            get { return _DischargeTime; }
        }
        /// <summary>
        /// 当前物流路线出发地
        /// </summary>
        public int? begins
        {
            set { _begins = value;}
            get { return _begins; }
        }
        /// <summary>
        /// 当前物流路线目的地
        /// </summary>
        public int? finish
        {
            set { _finish = value;}
            get { return _finish; }
        }
    }
}
