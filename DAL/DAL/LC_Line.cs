using System;
using System.Collections.Generic;
using SuperDataBase;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Line : DALBase
    {
        public LC_Line()
        {}
        /// <summary>
        /// ��ȡ��·������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Tuple<bool, string, Model.Model.LC_Line_Other> GetLineData(int id)
        {
            Model.Model.LC_Line_Other lclo = null;
            var vo = GetLineList(id);
            if (!vo.Item1)
                return new Tuple<bool, string, Model.Model.LC_Line_Other>(vo.Item1, vo.Item2, null);
            lclo = vo.Item3[0];
            lclo.UserName = GetUserVoFromId(lclo.UserID.ConvertData<int>())?.Item3?.UserName??string.Empty;
            return new Tuple<bool, string, Model.Model.LC_Line_Other>(true, string.Empty, lclo);
        }
        public static Tuple<bool, string, List<Model.Model.LC_Line>> GetXLList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "UID='"+UID+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Line>());
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "û���κ�����!", new List<Model.Model.LC_Line>());
        }

        public static Tuple<bool, string, List<Model.Model.LC_Line_Other>> GetLineList(int LID,string uid="")
        {
            if (LID > 0 | uid.StrIsNotNull())
            {
                if(uid.StrIsNotNull())
                {
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",uid) });
                }
                else
                {
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "id=@id", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@id",LID) });
                }
            }
            else
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line));
            }
            ids = db.Read(sql);

            //��ȡ��·�б�
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(true, "û���κ�����!", new List<Model.Model.LC_Line_Other>());

            //������ṹ
            var lcl_list = ids.GetVOList<Model.Model.LC_Line_Other>();

            List<Model.Model.LC_Region> lcr_list = new List<Model.Model.LC_Region>();
            #region ��ȡ��ַ�б�
            //�Ұ����еĵ�ַID����һ��
            List<int> addresslist = new List<int>();

            addresslist.AddRange(lcl_list.Select(x => x.Start.ConvertData<int>()));
            addresslist.AddRange(lcl_list.Select(x => x.End.ConvertData<int>()));


            //����ЩID��ȡ������ַ����
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Region), "ID in (" + addresslist.ListToString() + ")");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                lcr_list = ids.GetVOList<Model.Model.LC_Region>();

            #endregion

            return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(true, string.Empty, lcl_list.Select((x) => {
                //��ȡ��������
                x.StartCityName = GetAllAddressToString(x.Start.ConvertData<int>());
                x.EndCityName = GetAllAddressToString(x.End.ConvertData<int>());
                return x;
            }).ToList());
        }

        //�����·��
        public static Tuple<bool,string> Add(Model.Model.LC_Line LC_Line)
        {
            sql = makesql.MakeInsertSQL(LC_Line);
            ids = db.Exec(sql);
            if(!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "���ʧ��������!");
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
