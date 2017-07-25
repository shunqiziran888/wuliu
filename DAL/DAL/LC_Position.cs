using System;
namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Position : DALBase
    {
        public LC_Position()
        {}

        public static (bool, string, object) GetPositionList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Position), string.Empty);
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Position>());
        }
    }
}
