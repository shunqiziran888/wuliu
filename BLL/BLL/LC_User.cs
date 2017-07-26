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
        /// 注册用户
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User,GlobalBLL.UserLoginVO loginvo, string LogisticsUid="")
        {
            return DAL.DAL.LC_User.Add(lC_User, loginvo, LogisticsUid);
        }
        /// <summary>
        /// 根据手机号检测是否存在司机
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) CheckDriverIsHaveFromPhone(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            string phone = web.GetValue("phone");
            if (phone.StrIsNull())
                return (false, "电话不能为空!", null);
            return DAL.DAL.LC_User.CheckDriverIsHaveFromPhone(myuservo, phone);
        }

        /// <summary>
        /// 获取司机列表
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetDriverList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!",null);
            return DAL.DAL.LC_Line.GetDriverList(myuservo);
        }

        /// <summary>
        /// 获取账号数据
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetAccountData(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            long id = web.GetValue<long>("id");
            if (id <= 0)
                return (false, "ID参数错误!", null);
            return DAL.DAL.LC_User.GetAccountData(myuservo, id);
        }

        /// <summary>
        /// 员工授权
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) EmployeeEmpowerment(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限无法访问此接口!");

            long id = web.GetValue<long>("id");
            if (id <= 0)
                return (false, "ID参数错误!");
            UserStateEnum state = web.GetValue<UserStateEnum>("state");
            return DAL.DAL.LC_User.EmployeeEmpowerment(myuservo,id,state);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetEmployeeEmpowermentList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!", null);
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            if (page <= 0)
                page = 1;
            if (num <= 0)
                num = 1000;
            return DAL.DAL.LC_User.GetEmployeeEmpowermentList(myuservo, page, num);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) BindUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            string Lineletter = web.GetValue("Lineletter"); //货号字母
            string logistics = web.GetValue("logistics"); //物流公司ID
            string NickName = web.GetValue("NickName"); //昵称
            long phone = web.GetValue<long>("phone");//电话
            int sheng = web.GetValue<int>("sheng");
            int shi = web.GetValue<int>("shi");
            int qu = web.GetValue<int>("qu");

            if (NickName.StrIsNull())
                return (false, "昵称不能为空!");
            if (phone <= 0)
                return (false, "联系方式不能为空!");

            switch (myuservo.accountType)
            {
                case AccountTypeEnum.普通用户账号:
                    //注册普通账号
                    if (logistics.StrIsNull())
                        return (false, "物流公司ID不能为空!");
                    if (sheng <= 0)
                        return (false, "省不能为空!");
                    if (shi <= 0)
                        return (false, "市不能为空!");
                    if (qu <= 0)
                        return (false, "区不能为空!");
                    return DAL.DAL.LC_User.OrdinaryAccountBind(myuservo, NickName, phone, logistics, sheng, shi, qu);
                case AccountTypeEnum.物流公司员工账号:
                    return DAL.DAL.LC_User.EmployeeAccountBind(myuservo, NickName, phone, logistics);
                case AccountTypeEnum.物流账号:
                    if (sheng <= 0)
                        return (false, "省不能为空!");
                    if (shi <= 0)
                        return (false, "市不能为空!");
                    if (qu <= 0)
                        return (false, "区不能为空!");
                    //查看绑定的物流是不是自己
                    if (myuservo.uid.Equals(logistics, StringComparison.OrdinalIgnoreCase))
                    {
                        return (false, "不能绑定自己!");
                    }
                    return DAL.DAL.LC_User.LogisticsAccountBind(myuservo, NickName, phone, logistics, sheng, shi, qu, Lineletter);
            }
            return (false, "参数不正确!");
        }

        /// <summary>
        /// 验证是否需要注册
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetToRegUser(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            return DAL.DAL.LC_User.GetToRegUser(myuservo);
        }

        /// <summary>
        /// 添加或者更新账号
        /// </summary>
        /// <param name="web"></param>
        /// <param name="suser"></param>
        /// <param name="rtype">类型</param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(HttpContextBase web,Model.Model.LC_User suser)
        {
            //验证数据是否正确
            if (suser.WX_OpenID.StrIsNull())
                return (false, "OPENID不能为空!",null);
            return DAL.DAL.LC_User.AddOrUpdateUserVO(suser);
        }
    }
}