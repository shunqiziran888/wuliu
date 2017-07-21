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
        /// 绑定线路
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) LineBinding(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!");

            string logistics = web.GetValue("logistics");
            var lineletter = web.GetValue("lineletter");
            if (lineletter.StrIsNull())
                return (false, "货号字母不能为空!");
            if (logistics.StrIsNull())
                return (false, "要绑定的物流ID不能为空!");

            if (myuservo.uid.Equals(logistics, StringComparison.OrdinalIgnoreCase))
            {
                return (false, "您不能绑定自己!");
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
