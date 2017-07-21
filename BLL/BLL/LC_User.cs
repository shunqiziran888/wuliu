using System;
using Model.Model;
using CustomExtensions;
using GlobalBLL;

namespace BLL.BLL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_User : BLLBase
    {
        public LC_User()
        {}
        /// <summary>
        /// ע���û�
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User,GlobalBLL.UserLoginVO loginvo, string LogisticsUid="")
        {
            return DAL.DAL.LC_User.Add(lC_User, loginvo, LogisticsUid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) BindUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            string Lineletter = web.GetValue("Lineletter"); //������ĸ
            string logistics = web.GetValue("logistics"); //������˾ID
            string NickName = web.GetValue("NickName"); //�ǳ�
            long phone = web.GetValue<long>("phone");//�绰
            int sheng = web.GetValue<int>("sheng");
            int shi = web.GetValue<int>("shi");
            int qu = web.GetValue<int>("qu");

            if (NickName.StrIsNull())
                return (false, "�ǳƲ���Ϊ��!");
            if (phone <= 0)
                return (false, "��ϵ��ʽ����Ϊ��!");

            switch (myuservo.accountType)
            {
                case AccountTypeEnum.��ͨ�û��˺�:
                    //ע����ͨ�˺�
                    if (logistics.StrIsNull())
                        return (false, "������˾ID����Ϊ��!");
                    if (sheng <= 0)
                        return (false, "ʡ����Ϊ��!");
                    if (shi <= 0)
                        return (false, "�в���Ϊ��!");
                    if (qu <= 0)
                        return (false, "������Ϊ��!");
                    return DAL.DAL.LC_User.OrdinaryAccountBind(myuservo, NickName, phone, logistics, sheng, shi, qu);
                case AccountTypeEnum.������˾Ա���˺�:
                    return DAL.DAL.LC_User.EmployeeAccountBind(myuservo, NickName, phone, logistics);
                case AccountTypeEnum.�����˺�:
                    if (sheng <= 0)
                        return (false, "ʡ����Ϊ��!");
                    if (shi <= 0)
                        return (false, "�в���Ϊ��!");
                    if (qu <= 0)
                        return (false, "������Ϊ��!");
                    //�鿴�󶨵������ǲ����Լ�
                    if (myuservo.uid.Equals(logistics, StringComparison.OrdinalIgnoreCase))
                    {
                        return (false, "���ܰ��Լ�!");
                    }
                    return DAL.DAL.LC_User.LogisticsAccountBind(myuservo, NickName, phone, logistics, sheng, shi, qu, Lineletter);
            }
            return (false, "��������ȷ!");
        }

        /// <summary>
        /// ��֤�Ƿ���Ҫע��
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetToRegUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            return DAL.DAL.LC_User.GetToRegUser(myuservo);
        }

        /// <summary>
        /// ��ӻ��߸����˺�
        /// </summary>
        /// <param name="web"></param>
        /// <param name="suser"></param>
        /// <param name="rtype">����</param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(HttpContextBase web,Model.Model.LC_User suser)
        {
            //��֤�����Ƿ���ȷ
            if (suser.WX_OpenID.StrIsNull())
                return (false, "OPENID����Ϊ��!",null);
            return DAL.DAL.LC_User.AddOrUpdateUserVO(suser);
        }
    }
}