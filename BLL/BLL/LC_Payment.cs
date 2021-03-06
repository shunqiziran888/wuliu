using System;
using GlobalBLL;
using CustomExtensions;
using System.Collections.Generic;

namespace BLL.BLL
{
    /// <summary>
    /// 货款表
    /// </summary>
    [Serializable]
    public partial class LC_Payment : BLLBase
    {
        public LC_Payment()
        {}
        /// <summary>
        /// 获取货款记录
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetPaymentRecording(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            int state = web.GetValue<int>("state");
            DateTime starttime = web.GetValue<DateTime>("starttime");
            DateTime endtime = web.GetValue<DateTime>("endtime");
            string startuid = web.GetValue("startuid",string.Empty);
            string enduid = web.GetValue("enduid", string.Empty);
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            string orderlist = web.GetValue("orderlist", string.Empty);
            string HKDetail = web.GetValue("HKDetail");

            if (page <= 0)
                page = 1;
            if (num <= 0)
                num = 10;
            return DAL.DAL.LC_Payment.GetPaymentRecording(myuservo,state,starttime,endtime,startuid,enduid,page,num, orderlist, HKDetail);
        }

        public static (bool, string, object) Yesterdaybalance(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.普通用户账号)
                return (false, "您的权限不足无法访问此列表!", null);
            var AweekDate = web.GetValue("AweekDate");
            DateTime zuotian = AweekDate.ConvertData<DateTime>();
            DateTime fristtime = zuotian.ToString("yyyy-MM-dd 00:00:00").ConvertData<DateTime>();
            DateTime lasttime = zuotian.ToString("yyyy-MM-dd 23:59:59").ConvertData<DateTime>();
            DateTime fristToday = DateTime.Now.ToString("yyyy-MM-dd 00:00:00").ConvertData<DateTime>();
            DateTime lastToday = DateTime.Now.ToString("yyyy-MM-dd 23:59:59").ConvertData<DateTime>();
            return DAL.DAL.LC_Payment.Yesterdaybalance(myuservo, fristtime, lasttime, fristToday, lastToday);
        }

        public static (bool, string, object) GetPaymentDay(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            DateTime starttime = web.GetValue<DateTime>("starttime");
            DateTime endtime = web.GetValue<DateTime>("endtime");
            return DAL.DAL.LC_Payment.GetPaymentDay(myuservo,starttime,endtime);
        }

        public static (bool, string, object) GetPaidCount(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此列表!", null);
            int state = web.GetValue<int>("state");
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            if (page <= 0)
                page = 1;
            if (num <= 0)
                num = 10;
            return DAL.DAL.LC_Payment.GetPaidCount(myuservo, state, page, num);
        }

        /// <summary>
        /// 货款放款
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) LendersPayment(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的账号类型权限不足!", null);
            var orderdata = web.GetValue("orderdata");
            if (orderdata.StrIsNull())
                return (false, "数据不能为空!", null);
            List<string> orderList = orderdata.JsonToVO<List<string>>();
            if (orderList.Count == 0)
                return (false, "数据不能为空!", null);
            return DAL.DAL.LC_Payment.LendersPayment(myuservo, orderList);
        }

        /// <summary>
        /// 获取放款记录
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string, object) GetLendersList(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!", null);
            int page = web.GetValue<int>("page");
            int num = web.GetValue<int>("num");
            if (page == 0)
                page = 1;
            if (num == 0)
                num = 100;
            return DAL.DAL.LC_Payment.GetLendersList(myuservo, page, num);
        }

        /// <summary>
        /// 上缴或回收
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public static (bool, string) TurnedOrRecoveryPayment(HttpContextBase web)
        {
            var myuservo = web.GetMyLoginUserVO();
            if (myuservo.accountType != AccountTypeEnum.物流账号)
                return (false, "您的权限不足无法访问此接口!");
            string orderlist = web.GetValue("orderlist"); //JSON数组
            int model = web.GetValue<int>("model");//1为上缴,2,回收
            if (orderlist.StrIsNull())
                return (false, "要操作的数据不能为空!");
            List<string> list = orderlist.JsonToVO<List<string>>();
            if(list.Count==0)
                return (false, "要操作的数据不能为空!");
            return DAL.DAL.LC_Payment.TurnedOrRecoveryPayment(myuservo, list,model);
        }
    }
}
