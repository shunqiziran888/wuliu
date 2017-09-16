using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_History : DALBase
    {
        public LC_History()
        {}
        //发货-历史发货列表
        public static Tuple<bool, string, List<Model.Model.LC_History>> GetHistoryList(string Phone, string SHPhone)
        {
            if (SHPhone != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_History), "FHPhone='" + Phone + "' and SHPhone='" + SHPhone + "' and State=1");
                ids = db.Read(sql);
            }
            else if (SHPhone == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_History), "FHPhone='" + Phone + "' and State=1",new System.Data.SqlClient.SqlParameter[] {
                }, "HistoryTime desc");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_History>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_History>>(true, string.Empty, ids.GetVOList<Model.Model.LC_History>());
            return new Tuple<bool, string, List<Model.Model.LC_History>>(true, "没有任何数据!", new List<Model.Model.LC_History>());
        }
    }
}
