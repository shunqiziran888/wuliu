using System;
namespace Model.Model
{
    /// <summary>
    /// 货款表
    /// </summary>
    [Serializable]
    public partial class LC_Payment_History : ModelBase
    {
        public LC_Payment_History()
        {}
        /// <summary>
        /// 
        /// </summary>
        private long? _id;
        /// <summary>
        /// 订单号
        /// </summary>
        private string _OrderNumber;
        /// <summary>
        /// 起点物流UID
        /// </summary>
        private string _StartLogisticsUID;
        /// <summary>
        /// 货款总金额（运费+代收货款+其它费用）
        /// </summary>
        private decimal? _PaymentAllAmount;
        /// <summary>
        /// 当前所在物流UID
        /// </summary>
        private string _LocationLogisticsUID;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime? _CreateTime;
        /// <summary>
        /// 最后操作时间
        /// </summary>
        private DateTime? _LastOperationTime;
        /// <summary>
        /// 最后的状态 0未处理（不可用）,1已回收(可用）,2(已放款)
        /// </summary>
        private int? _LastState;
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value;}
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber
        {
            set { _OrderNumber = value;}
            get { return _OrderNumber; }
        }
        /// <summary>
        /// 起点物流UID
        /// </summary>
        public string StartLogisticsUID
        {
            set { _StartLogisticsUID = value;}
            get { return _StartLogisticsUID; }
        }
        /// <summary>
        /// 货款总金额（运费+代收货款+其它费用）
        /// </summary>
        public decimal? PaymentAllAmount
        {
            set { _PaymentAllAmount = value;}
            get { return _PaymentAllAmount; }
        }
        /// <summary>
        /// 当前所在物流UID
        /// </summary>
        public string LocationLogisticsUID
        {
            set { _LocationLogisticsUID = value;}
            get { return _LocationLogisticsUID; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _CreateTime = value;}
            get { return _CreateTime; }
        }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime? LastOperationTime
        {
            set { _LastOperationTime = value;}
            get { return _LastOperationTime; }
        }
        /// <summary>
        /// 最后的状态 0未处理（不可用）,1已回收(可用）,2(已放款)
        /// </summary>
        public int? LastState
        {
            set { _LastState = value;}
            get { return _LastState; }
        }
    }
}
