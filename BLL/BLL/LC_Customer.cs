using System;
using CustomExtensions;
using GlobalBLL;

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

        public static (bool, string, object) GetMyCount(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);
            DateTime AweekDate = web.GetValue<DateTime>("AweekDate");
            DateTime fristtime = DateTime.Now.ToString("yyyy-MM-01 00:00:00").ConvertData<DateTime>();//���쿪ʼʱ��
            DateTime lasttime = fristtime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 23:59:59").ConvertData<DateTime>();//�������ʱ��
            return DAL.DAL.LC_Customer.GetMyCount(myuservo, AweekDate, fristtime, lasttime);
        }

        public static (bool, string, object) GetMeetCarList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);
            return DAL.DAL.LC_Customer.GetMettCarList(myuservo);
        }

        public static (bool, string, object) GetCollectDebtsDetailTop(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);
            string SHPhone = web.GetValue("SHPhone");
            return DAL.DAL.LC_Customer.GetCollectDebtsDetailTop(myuservo, SHPhone);
        }

        public static (bool, string, object) GetCollectDebtsEdit(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);
            string OID = web.GetValue("OID");
            return DAL.DAL.LC_Customer.GetCollectDebtsEdit(myuservo, OID);
        }

        public static (bool, string, object) GetCollectDebtsDetail(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);
            string SHPhone = web.GetValue("SHPhone");
            return DAL.DAL.LC_Customer.GetCollectDebtsDetail(myuservo,SHPhone);
        }

        public static (bool, string, object) GetCollectDebts(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ��б�!", null);

            return DAL.DAL.LC_Customer.GetCollectDebts(myuservo);
        }
    }
}
