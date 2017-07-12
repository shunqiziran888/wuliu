using System;
using System.Collections.Generic;
using Model.Model;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;
using GlobalBLL;

namespace DAL.DAL
{
    /// <summary>
    /// 绑定物流表
    /// </summary>
    [Serializable]
    public partial class LC_UserBindLogisticsList : DALBase
    {
        public LC_UserBindLogisticsList()
        {}
        public static Tuple<bool, string> UserAdd(Model.Model.LC_UserBindLogisticsList LC_UserBindLogisticsList)
        {
            sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "Uid=@Uid and LogisticsUid=@LogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@Uid",LC_UserBindLogisticsList.Uid),
                new System.Data.SqlClient.SqlParameter("@LogisticsUid",LC_UserBindLogisticsList.LogisticsUid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (ids.Count() > 0)
                return new Tuple<bool, string>(false, "您已经绑定过次物流了!");

            sql = makesql.MakeInsertSQL(LC_UserBindLogisticsList);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "绑定失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
        /// <summary>
        /// 根据电话绑定物流
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UserAddFromPhone(UserLoginVO myuservo, string phone)
        {
            string LogisticsUid = string.Empty;
            //获取当前物流是否存在并获取数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@Phone",phone)
            }, string.Empty, 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string>(false, "当前电话号码的物流信息不存在!");
            Model.Model.LC_User lcu = ids.GetVOList<Model.Model.LC_User>()[0];
            //判断是否为物流
            if (lcu.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != AccountTypeEnum.物流账号)
                return new Tuple<bool, string>(false, "此电话并非物流公司电话,请检查电话是否正确!");
            LogisticsUid = lcu.UID;

            //检查此物流是否已经绑定过了
            sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "uid=@uid and LogisticsUid=@LogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@LogisticsUid",LogisticsUid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (ids.Count() > 0)
                return new Tuple<bool, string>(false, "当前物流已经绑定过了,无需重新绑定!");

            //开始绑定
            Model.Model.LC_UserBindLogisticsList ubll = new Model.Model.LC_UserBindLogisticsList()
            {
                CreateTime = DateTime.Now,
                LogisticsUid = LogisticsUid,
                Uid = myuservo.uid
            };
            sql = makesql.MakeInsertSQL(ubll);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "绑定失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
