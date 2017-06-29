using System;
namespace Model.Model
{
    /// <summary>
    /// -
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
        /// 
        /// </summary>
        private string _OrderID;
        /// <summary>
        /// 
        /// </summary>
        private string _ConsigneeID;
        /// <summary>
        /// 
        /// </summary>
        private string _Consignee;
        /// <summary>
        /// 
        /// </summary>
        private string _ConsignorID;
        /// <summary>
        /// 
        /// </summary>
        private string _Consignor;
        /// <summary>
        /// 
        /// </summary>
        private string _logisticsID;
        /// <summary>
        /// 
        /// </summary>
        private string _FHPhone;
        /// <summary>
        /// 
        /// </summary>
        private string _SHPhone;
        /// <summary>
        /// 
        /// </summary>
        private int? _Destination;
        /// <summary>
        /// 
        /// </summary>
        private string _GoodName;
        /// <summary>
        /// 
        /// </summary>
        private int? _Number;
        /// <summary>
        /// 
        /// </summary>
        private string _GoodNo;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _GReceivables;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _Freight;
        /// <summary>
        /// 
        /// </summary>
        private int? _CarryGood;
        /// <summary>
        /// 
        /// </summary>
        private int? _ReceiptGood;
        /// <summary>
        /// 
        /// </summary>
        private int? _freightMode;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _DdTime;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _ConsigneeTime;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _FreightCollect;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _OtherExpenses;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _Total;
        /// <summary>
        /// 
        /// </summary>
        private int? _State;
        /// <summary>
        /// 
        /// </summary>
        private int? _Initially;
        /// <summary>
        /// 
        /// </summary>
        private int? _VehicleID;
        /// <summary>
        /// 
        /// </summary>
        private decimal? _largeCar;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _TruckTime;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _MeetCarTime;
        /// <summary>
        /// 
        /// </summary>
        private DateTime? _DischargeTime;
        /// <summary>
        /// 
        /// </summary>
        private int? _begins;
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string OrderID
        {
            set { _OrderID = value;}
            get { return _OrderID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConsigneeID
        {
            set { _ConsigneeID = value;}
            get { return _ConsigneeID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Consignee
        {
            set { _Consignee = value;}
            get { return _Consignee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConsignorID
        {
            set { _ConsignorID = value;}
            get { return _ConsignorID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Consignor
        {
            set { _Consignor = value;}
            get { return _Consignor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logisticsID
        {
            set { _logisticsID = value;}
            get { return _logisticsID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FHPhone
        {
            set { _FHPhone = value;}
            get { return _FHPhone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SHPhone
        {
            set { _SHPhone = value;}
            get { return _SHPhone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Destination
        {
            set { _Destination = value;}
            get { return _Destination; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodName
        {
            set { _GoodName = value;}
            get { return _GoodName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Number
        {
            set { _Number = value;}
            get { return _Number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodNo
        {
            set { _GoodNo = value;}
            get { return _GoodNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GReceivables
        {
            set { _GReceivables = value;}
            get { return _GReceivables; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Freight
        {
            set { _Freight = value;}
            get { return _Freight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CarryGood
        {
            set { _CarryGood = value;}
            get { return _CarryGood; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ReceiptGood
        {
            set { _ReceiptGood = value;}
            get { return _ReceiptGood; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? freightMode
        {
            set { _freightMode = value;}
            get { return _freightMode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DdTime
        {
            set { _DdTime = value;}
            get { return _DdTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ConsigneeTime
        {
            set { _ConsigneeTime = value;}
            get { return _ConsigneeTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FreightCollect
        {
            set { _FreightCollect = value;}
            get { return _FreightCollect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OtherExpenses
        {
            set { _OtherExpenses = value;}
            get { return _OtherExpenses; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Total
        {
            set { _Total = value;}
            get { return _Total; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _State = value;}
            get { return _State; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Initially
        {
            set { _Initially = value;}
            get { return _Initially; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VehicleID
        {
            set { _VehicleID = value;}
            get { return _VehicleID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? largeCar
        {
            set { _largeCar = value;}
            get { return _largeCar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TruckTime
        {
            set { _TruckTime = value;}
            get { return _TruckTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MeetCarTime
        {
            set { _MeetCarTime = value;}
            get { return _MeetCarTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DischargeTime
        {
            set { _DischargeTime = value;}
            get { return _DischargeTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? begins
        {
            set { _begins = value;}
            get { return _begins; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? finish
        {
            set { _finish = value;}
            get { return _finish; }
        }
    }
}
