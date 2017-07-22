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

        public static (bool, string, object) GetLineData(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            long id = web.GetValue<long>("id");
            if (id <= 0)
                return (false, "ID参数错误!",null);
            return DAL.DAL.LC_Line.GetLineData(myuservo, id);
        }

        /// <summary>
        /// 线路授权
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) LineAuthorization(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "线路授权不能为空!");
            long id = web.GetValue<long>("id");
            int state = web.GetValue<int>("state"); //状态
            string Lineletter = web.GetValue("Lineletter");
            if (id <= 0)
                return (false, "线路授权ID不能为空!");
            if(state==1)
            {
                if (Lineletter.StrIsNull())
                    return (false, "运号字母不能为空!");
            }
            
            return DAL.DAL.LC_Line.LineAuthorization(myuservo, id, state, Lineletter);
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
        /// 获取线路授权列表
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetLineAuthorizationList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!",null);
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            if (page <= 0)
                page = 1;
            if (num <= 0)
                num = 1000;
            return DAL.DAL.LC_Line.GetLineAuthorizationList(myuservo,page,num);
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
