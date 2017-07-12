using System;
using System.Collections.Generic;
using Model.Model;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;
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
    }
}
