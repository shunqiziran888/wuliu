using System;
using System.Collections.Generic;
using Model.Model;
using CustomExtensions;
using SuperDataBase.InterFace;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_User : DALBase
    {
        public LC_User()
        { }

        public static Tuple<bool, string, List<Model.Model.LC_User>> GetUserList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZType=1");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "û���κ�����!", new List<Model.Model.LC_User>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetLCList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZType=1 and LogisticsName is not null");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "û���κ�����!", new List<Model.Model.LC_User>());
        }
        public static Tuple<bool, string, List<Dictionary<string, I_ModelBase>>> GetLCFHADDList(int CityID,string logID)
        {
            //�����ѯ
            Type[] tlist = new Type[] {
                typeof(Model.Model.LC_User),
                typeof(Model.Model.LC_Line)
            };
            sql = makesql.MakeSelectArrSql(tlist, "{0}.UID={1}.UID and {0}.UID='4b3c4458db2d77c6'");
            //sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "CityID=" + CityID + " and ZType=1 and LogisticsName is not null");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, string.Empty, ids.GetVOList(tlist));
            return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, "û���κ�����", null);
        }
        /// <summary>
        /// ��ȡ�������б�
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetSQList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), $"State=0 and ZType={GlobalBLL.AccountTypeEnum.������˾Ա���˺�.EnumToInt()}");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "û���κ�����!", new List<Model.Model.LC_User>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetSQAllList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), $"State=1  and ZType={GlobalBLL.AccountTypeEnum.������˾Ա���˺�.EnumToInt()}");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "û���κ�����!", new List<Model.Model.LC_User>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lC_User"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User)
        {
            sql = makesql.MakeInsertSQL(lC_User);
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "ע���˺�ʱʧ��,������!");
            return new Tuple<bool, string>(true, string.Empty);
        }
        /// <summary>
        /// ��¼�ʺ�
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static Tuple<bool, string, Model.Model.LC_User> Login(string name, string pwd)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZNumber=@name and Password=@pwd", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@name",name),
                new System.Data.SqlClient.SqlParameter("@pwd",pwd)
            }, string.Empty, 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, Model.Model.LC_User>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
            {
                var lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (lcu.State == 0)
                {
                    return new Tuple<bool, string, Model.Model.LC_User>(false, "��������У����Ժ��¼!", null);
                }
                else if(lcu.State==2)
                {
                    return new Tuple<bool, string, Model.Model.LC_User>(false, "���δͨ�����޷���¼��!", null);
                }
                return new Tuple<bool, string, Model.Model.LC_User>(true, string.Empty, lcu);
            }
            return new Tuple<bool, string, Model.Model.LC_User>(false, "�ֻ��Ż��������!", null);
        }
        public static Tuple<bool, string> UpdateYesOrNo(Model.Model.LC_User LC_User, string UID)
        {
            sql = makesql.MakeUpdateSQL(LC_User, "UID='" + UID + "'");
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "�޸�ʧ��������!");
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
