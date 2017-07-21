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
    public partial class LC_Line : BLLBase
    {
        public LC_Line()
        {}
        public static Tuple<bool,string> Add(Model.Model.LC_Line LC_Line, GlobalBLL.UserLoginVO uservo)
        {
            return DAL.DAL.LC_Line.Add(LC_Line,uservo);
        }
        /// <summary>
        /// ����·
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) LineBinding(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.�����˺�)
                return (false, "����Ȩ�޲����޷����ʴ˽ӿ�!");

            string logistics = web.GetValue("logistics");
            var lineletter = web.GetValue("lineletter");
            if (lineletter.StrIsNull())
                return (false, "������ĸ����Ϊ��!");
            if (logistics.StrIsNull())
                return (false, "Ҫ�󶨵�����ID����Ϊ��!");

            if (myuservo.uid.Equals(logistics, StringComparison.OrdinalIgnoreCase))
            {
                return (false, "�����ܰ��Լ�!");
            }

            return DAL.DAL.LC_Line.LineBinding(myuservo, lineletter, logistics);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zNumber"></param>
        /// <param name="pwd"></param>
        /// <param name="bindUid"></param>
        /// <param name="Lineletter"></param>
        /// <returns></returns>
        public static Tuple<bool, string> BindHZ(string zNumber, string pwd, string bindUid,string myLineletter,string bindLineletter)
        {
            return DAL.DAL.LC_Line.BindHZ(zNumber, pwd, bindUid, myLineletter, bindLineletter);
        }
    }
}
