using System;
using System.Collections.Generic;
using SuperDataBase;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;
using Model.Model;

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

        public static Tuple<bool, string, List<Model.Model.LC_Line>> GetLineListFromUid(string uid)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@uid",uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "û���κ�����!", new List<Model.Model.LC_Line>());
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Line>());
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="zNumber"></param>
        /// <param name="pwd"></param>
        /// <param name="bindUid"></param>
        /// <param name="Lineletter">�ҵ������˺�����ĸ</param>
        /// <param name="bindLineletter">�Է������˺�����ĸ</param>
        /// <returns></returns>
        public static Tuple<bool, string> BindHZ(string zNumber, string pwd, string bindUid,string myLineletter,string bindLineletter)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //�鿴�����˺��Ƿ����
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "zNumber=@zNumber and Password=@Password", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@zNumber",zNumber),
                    new System.Data.SqlClient.SqlParameter("@Password",pwd)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "û���ҵ������˺�!");
                Model.Model.LC_User my_lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (my_lcu.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != GlobalBLL.AccountTypeEnum.�����˺�)
                    return new Tuple<bool, string>(false, "�����˺�Ȩ�޲���ȷ,�޷����в���!");

                //��ȡ�󶨷��˺���Ϣ
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",bindUid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "û���ҵ�Ҫ�󶨷��ĺ�����������!");
                Model.Model.LC_User bind_lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (bind_lcu.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != GlobalBLL.AccountTypeEnum.�����˺�)
                    return new Tuple<bool, string>(false, "�˺����Ͳ���Ϊ��!");

                #region ��ʼ�ҷ���ʼ��

                //�鿴���Ƿ�󶨹�
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",bind_lcu.UID),
                    new System.Data.SqlClient.SqlParameter("@uid",my_lcu.UID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //���ҷ�
                    Model.Model.LC_Line my_ll = new Model.Model.LC_Line()
                    {
                        BindLogisticsUid = bind_lcu.UID,
                        DateTime = DateTime.Now,
                        End = bind_lcu.AreaID,
                        LineID = Tools.NewGuid.GuidTo16String(),
                        Phone = bind_lcu.Phone,
                        UID = my_lcu.UID,
                        Start = my_lcu.AreaID,
                        Lineletter = myLineletter
                    };
                    //׼�����
                    sql = makesql.MakeInsertSQL(my_ll);
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "��Ӱ�ʧ��!");
                }
                #endregion


                //�ж��Ƿ�Ϊ��ͬ���˺�
                if (bindUid.Equals(my_lcu.UID))
                    return new Tuple<bool,string>(false, "���ܰ󶨸��Լ�!");


                if (bind_lcu.AreaID == my_lcu.AreaID)
                    return new Tuple<bool, string>(false, "���ܰ���ͬ����������!");

                #region �Է���ʼ��
                //�鿴�Է������Ƿ�����ҵ�������
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@BindLogisticsUid and BindLogisticsUid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",bind_lcu.UID),
                    new System.Data.SqlClient.SqlParameter("@uid",my_lcu.UID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //������ݰ�
                    Model.Model.LC_Line bind_ll = new Model.Model.LC_Line()
                    {
                        BindLogisticsUid = my_lcu.UID,
                        DateTime = DateTime.Now,
                        End = my_lcu.AreaID,
                        LineID = Tools.NewGuid.GuidTo16String(),
                        Phone = my_lcu.Phone,
                        UID = bind_lcu.UID,
                        Start = bind_lcu.AreaID,
                        Lineletter = bindLineletter
                    };
                    sql = makesql.MakeInsertSQL(bind_ll);
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "��Ӱ�ʧ��!");
                }
                #endregion
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

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
        public static Tuple<bool,string> Add(Model.Model.LC_Line LC_Line, GlobalBLL.UserLoginVO uservo)
        {
            //�鿴�Ƿ����
            sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "[End]=@End and uid=@uid",new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@End",LC_Line.End),
                new System.Data.SqlClient.SqlParameter("@uid",uservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (ids.Count() > 0)
                return new Tuple<bool, string>(false, "���Ѿ���ӹ���·��,�����ظ����!");

            sql = makesql.MakeInsertSQL(LC_Line);
            ids = db.Exec(sql);
            if(!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "���ʧ��������!");
            return new Tuple<bool, string>(true, string.Empty);
        }
        /// <summary>
        /// ��ת-��ת������
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Line>> GetLCEndList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "UID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Line>());
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "û���κ�����!", new List<Model.Model.LC_Line>());
        }

        public static Tuple<bool,string,List<Dictionary<string, I_ModelBase>>> GetNewLineList(string UID)
        {
            var tlist = new Type[] {
                typeof(Model.Model.LC_Line),
                typeof(Model.Model.LC_User)
            };
            sql = makesql.MakeSelectArrSql(tlist,"{0}.UID={1}.UID and {0}.UID='"+UID+"'");
            ids = db.Read(sql);
            
            return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, string.Empty, ids.GetVOList(tlist));
        }
    }
}
