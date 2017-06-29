using SuperDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CustomExtensions;
namespace DAL.DAL
{
    public class DALBase
    {
        private static Dictionary<int, Model.Model.w_address_basic_data> addressDic = null;
        private static object _lockobj = new object();
        /// <summary>
        /// 数据库操作类
        /// </summary>
        internal readonly static IDataBaseCommand db = DataBaseCommandBase.CreateDataBase(SuperDataBase.DBEnum.DbEnum.DB_TYPE.MSSQL, "db");
        /// <summary>
        /// SQL制造类
        /// </summary>
        internal readonly static IMakeSql<SqlParameter> makesql = MakeSqlBase.CreateMakeSql<SqlParameter>(SuperDataBase.DBEnum.DbEnum.DB_TYPE.MSSQL, "db");

        [ThreadStatic]
        internal static MakeSqlBase.FY_SQL_VO fysql = null;
        [ThreadStatic]
        internal static SuperDataBase.InterFace.IDataState ids;
        [ThreadStatic]
        internal static SuperDataBase.Vo.SqlVO sql = null;

        /// <summary>
        /// 根据ID获取用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static Tuple<bool,string,Model.Model.LC_User> GetUserVoFromId(long id)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "id=@id", new SqlParameter[] {
                new SqlParameter("@id",id)
            },string.Empty,1);
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, Model.Model.LC_User>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, Model.Model.LC_User>(false, "没有任何数据!", null);
            return new Tuple<bool, string, Model.Model.LC_User>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>()[0]);
        }
        /// <summary>
        /// 根据ID获取用户数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static Tuple<bool, string, Model.Model.LC_User> GetUserVoFromId(long id,SuperDataBase.Model.DBSandbox db)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "id=@id", new SqlParameter[] {
                new SqlParameter("@id",id)
            }, string.Empty, 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, Model.Model.LC_User>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, Model.Model.LC_User>(false, "没有任何数据!", null);
            return new Tuple<bool, string, Model.Model.LC_User>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>()[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AreaID"></param>
        /// <returns></returns>
        internal static string GetAllAddressToString(int AreaID)
        {
            string allname = string.Empty;
            Model.Model.w_address_basic_data wabd = null;
            wabd = GetAddressFromID(AreaID)?.Item2;
            allname = wabd?.Name?? string.Empty;

            wabd = GetAddressFromID(wabd.TopAddressID.ConvertData<int>()).Item2;
            allname = (wabd?.Name ?? string.Empty) +" "+ allname;
            wabd = GetAddressFromID(wabd.TopAddressID.ConvertData<int>()).Item2;
            allname = (wabd?.Name ?? string.Empty) + " " + allname;
            return allname;
        }

        /// <summary>
        /// 获取下一级地区列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Model.Model.w_address_basic_data> GetNextAddressListFromId(int id)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.w_address_basic_data), "TopAddressID=@id", new SqlParameter[] {
                new SqlParameter("@id",id)
            });
            ids = db.Read(sql);
            return ids.GetVOList<Model.Model.w_address_basic_data>();
        }


            /// <summary>
            /// 获取地区数据
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public static Tuple<bool, Model.Model.w_address_basic_data> GetAddressFromID(int id)
            {
                lock (_lockobj)
                {
                    Model.Model.w_address_basic_data lcr = null;

                    if (addressDic == null)
                        addressDic = w_address_basic_data.GetAllAddress();

                    if (addressDic.TryGetValue(id, out lcr))
                    {
                        return new Tuple<bool, Model.Model.w_address_basic_data>(true, lcr);
                    }
                    return new Tuple<bool, Model.Model.w_address_basic_data>(false, null);
                }
            }

            
    }
}
