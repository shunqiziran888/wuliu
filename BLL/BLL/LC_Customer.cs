using System;
using CustomExtensions;
namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Customer : BLLBase
    {
        public LC_Customer()
        {}

        public static Tuple<bool, string> Add(Model.Model.LC_Customer LC_Customer)
        {
            if (LC_Customer.Consignee.StrIsNull())
                return new Tuple<bool, string>(false, "����д�ջ���");
            if (LC_Customer.logisticsID.Equals(0))
                return new Tuple<bool, string>(false, "��ѡ��������");
            if (LC_Customer.SHPhone.StrIsNull())
                return new Tuple<bool, string>(false, "����д�ջ��˵绰��");
            if (LC_Customer.Destination.Equals(0))
                return new Tuple<bool, string>(false,"��ѡ��Ŀ�ĵأ�");
            if (LC_Customer.freightMode.Equals(0))
                return new Tuple<bool, string>(false,"��ѡ�񸶷ѷ�ʽ��");
            if (LC_Customer.GoodName.StrIsNull())
                return new Tuple<bool, string>(false,"����д�������ƣ�");
            if (LC_Customer.Number.Equals(0))
                return new Tuple<bool, string>(false,"����д������");
            if (LC_Customer.GReceivables.Equals(0))
                return new Tuple<bool, string>(false,"����д���տ�");
            if (LC_Customer.CarryGood.Equals(0))
                return new Tuple<bool, string>(false,"��ѡ�������ʽ");
            if (LC_Customer.ReceiptGood.Equals(0))
                return new Tuple<bool, string>(false, "��ѡ���ջ���ʽ��");
            return DAL.DAL.LC_Customer.Add(LC_Customer);
        }
    }
}
