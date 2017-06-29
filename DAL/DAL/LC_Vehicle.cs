using System;
using System.Collections.Generic;
using Model.Model;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Vehicle : DALBase
    {
        public LC_Vehicle()
        { }
        public static Tuple<bool, string, List<Model.Model.LC_Vehicle>> GetVehList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle),"UID='"+UID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Vehicle>());
            return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, "没有任何数据!", new List<Model.Model.LC_Vehicle>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Vehicle>> GetDetailList(int ID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Vehicle), "ID='"+ID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Vehicle>());
            return new Tuple<bool, string, List<Model.Model.LC_Vehicle>>(true, "没有任何数据!", new List<Model.Model.LC_Vehicle>());
        }
        public static Tuple<bool, string> Add(Model.Model.LC_Vehicle LC_Vehicle)
        {
            sql = makesql.MakeInsertSQL(LC_Vehicle);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "添加失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
