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
        private static Dictionary<int, Model.Model.LC_Vehicle> aCarDic = null;
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
        /// 根据UID获取用户数据
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        internal static (bool, string, Model.Model.LC_User) GetUserVoFromUID(string uid)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new SqlParameter[] {
                new SqlParameter("@id",uid)
            }, string.Empty, 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (false, "没有任何数据!", null);
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_User>()[0]);
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
            if(wabd!=null)
            {
                wabd = GetAddressFromID(wabd.TopAddressID.ConvertData<int>()).Item2;
                allname = (wabd?.Name ?? string.Empty) + " " + allname;
                if (wabd != null)
                {
                    wabd = GetAddressFromID(wabd.TopAddressID.ConvertData<int>()).Item2;
                    allname = (wabd?.Name ?? string.Empty) + " " + allname;
                }
            }

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
        /// <summary>
        /// 获取车牌号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Tuple<bool, Model.Model.LC_Vehicle> GetCarFromID(int id)
        {
            lock (_lockobj)
            {
                Model.Model.LC_Vehicle lcr = null;

                if (aCarDic == null)
                    aCarDic = LC_Vehicle.GetAllCar();

                if (aCarDic.TryGetValue(id, out lcr))
                {
                    return new Tuple<bool, Model.Model.LC_Vehicle>(true, lcr);
                }
                return new Tuple<bool, Model.Model.LC_Vehicle>(false, null);
            }
        }
        /// <summary>
        /// 根据收货电话筛选地区
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetPhoneAdressList(string Phone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone=@SHPhone", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@SHPhone",Phone)
            }, "DdTime desc", 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "没有任何数据!", new List<Model.Model.LC_Customer>());

        }

        /// <summary>
        /// 根据OPENID获取用户数据
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static (bool,string,Model.Model.LC_User) GetUserVOFromOpenID(string openid,SuperDataBase.Model.DBSandbox db)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "wx_openid=@wx_openid", new SqlParameter[] {
                new SqlParameter("@wx_openid",openid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (false, "没有找到任何数据!",null);
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_User>()[0]);
        }


        /// <summary>
        /// 生成货号
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public static Tuple<bool, string> GetGoodNo(ref Model.Model.LC_Customer lc)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "[End]=@End", new SqlParameter[] {
                    new SqlParameter("@End",lc.finish)
                });
            ids = db.Read(sql);
            if (!ids.flag)
            {
                Tools.SaveLog.AddLog(ids.errormsg, "获取路线错误");
            }
            if (!ids.ReadIsOk())
                return new Tuple<bool, string>(false, "没有任何数据!");

            Model.Model.LC_Line lcl = ids.GetVOList<Model.Model.LC_Line>()[0];

            DateTime starttime = DateTime.Now.ToString("yyyy-MM-dd 00:00:00").ConvertData<DateTime>();
            DateTime endtime = DateTime.Now.ToString("yyyy-MM-dd 23:59:59").ConvertData<DateTime>();

            //获取当前线路当日总单数
            sql = makesql.MakeCount(nameof(Model.Model.LC_Customer), "finish=@finish and DdTime between @starttime and @endtime", new SqlParameter[] {
                    new SqlParameter("@finish",lcl.End),
                    new SqlParameter("@starttime",starttime),
                    new SqlParameter("@endtime",endtime)
                });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);

            long nowOrderNumber = ids.Count();

            StringBuilder goodbuffer = new StringBuilder();
            goodbuffer.Append(lcl.Lineletter);
            goodbuffer.Append(DateTime.Now.Day.ToString().PadLeft(2, '0'));
            goodbuffer.Append("-");
            goodbuffer.Append(nowOrderNumber);
            goodbuffer.Append("-");
            goodbuffer.Append(lc.Number);
            return new Tuple<bool, string>(true, goodbuffer.ToString());
        }
        //用户绑定物流判断
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetUserBindingsList(string Phone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZNumber='" + Phone + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "没有任何数据!", new List<Model.Model.LC_User>());
        }
    }
}
