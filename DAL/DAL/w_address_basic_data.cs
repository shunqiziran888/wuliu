using System;
using System.Collections.Generic;
using Model.Model;
using System.Linq;
using CustomExtensions;
namespace DAL.DAL
{
    /// <summary>
    /// 省市区基本数据表
    /// </summary>
    [Serializable]
    public partial class w_address_basic_data : DALBase
    {
        public w_address_basic_data()
        {}

        public static Dictionary<int, Model.Model.w_address_basic_data> GetAllAddress()
        {
            Dictionary<int, Model.Model.w_address_basic_data> vlist = new Dictionary<int, Model.Model.w_address_basic_data>();
            sql = makesql.MakeSelectSql(typeof(Model.Model.w_address_basic_data));
            ids = db.Read(sql);
            foreach(var x in ids.GetVOList<Model.Model.w_address_basic_data>())
            {
                vlist.Add(x.id.ConvertData<int>(),x);
            }
            return vlist;
        }
    }
}
