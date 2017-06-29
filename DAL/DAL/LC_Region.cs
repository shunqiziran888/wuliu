using System;
using System.Collections.Generic;
using Model.Model;
using System.Linq;
using CustomExtensions;
namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Region : DALBase
    {
        public LC_Region()
        {}
        /// <summary>
        /// 获取所有地区到集合
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Model.Model.LC_Region> GetAllAddress()
        {
            var dic = new Dictionary<int, Model.Model.LC_Region>();
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Region));
            ids = db.Read(sql);
            if (ids.ReadIsOk())
            {
                foreach(var p in ids.GetVOList<Model.Model.LC_Region>())
                {
                    dic.Add(p.ID.ConvertData<int>(), p);
                }
            }
            return dic;
        }
    }
}
