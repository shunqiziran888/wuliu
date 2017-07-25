using System;
using System.Collections.Generic;
using Model.Model;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;
using GlobalBLL;
using SuperDataBase;
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

        /// <summary>
        /// ��ȡ�˺�����
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static (bool, string, object) GetAccountData(UserLoginVO myuservo, long id)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "id=@id", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@id",id)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (false, "û���ҵ��κ�����!", null);
            var vo = ids.GetVOList<Model.Model.LC_User>()[0];
            return (true, string.Empty,new {
                vo.AreaID,
                vo.CityID,
                vo.CreateTime,
                vo.ID,
                vo.LCID,
                vo.LogisticsName,
                vo.Phone,
                vo.PositionID,
                vo.ProvincesID,
                PositionName = GetPosition(vo.PositionID).Item3?.PositionName,
                vo.State,
                vo.UID,
                vo.UserName,
                vo.WX_City,
                vo.WX_Country,
                vo.WX_HeadPic,
                vo.WX_NickName,
                vo.WX_Province,
                vo.WX_Sex,
                vo.ZNumber,
                vo.ZType
            });
        }

        /// <summary>
        /// Ա����Ȩ
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static (bool, string) EmployeeEmpowerment(UserLoginVO myuservo, long id, UserStateEnum state)
        {
            //�鿴���˺��Ƿ�Ϊ�����˺�
            sql = makesql.MakeCount(nameof(Model.Model.LC_User), "id=@id and LCID=@LCID and ZType=@ZType", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@id",id),
                new System.Data.SqlClient.SqlParameter("@LCID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@ZType",GlobalBLL.AccountTypeEnum.������˾Ա���˺�.EnumToInt())
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (ids.Count() == 0)
                return (false, "��ǰ���ݴ���,�޷����в���!");
            sql = makesql.MakeUpdateSQL(new Model.Model.LC_User()
            {
                State = state.EnumToInt()
            }, "id=@id", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@id",id)
            });
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ExecOk())
                return (false, "����ʧ��!");
            return (true, string.Empty);
        }

        /// <summary>
        /// ��ȡԱ����Ȩ�б�
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="page"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static (bool, string, object) GetEmployeeEmpowermentList(UserLoginVO myuservo, int page, int num)
        {
            var tlist = new Type[] { typeof(Model.Model.LC_User), typeof(Model.Model.LC_Position) };
            fysql = makesql.MakeSelectFY(tlist, "{0}.PositionID={1}.id and {0}.ZType=@ZType and {0}.LCID=@LCID and {0}.State=0", "{0}.id desc", page, num, "{0}.id", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@LCID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@ZType",GlobalBLL.AccountTypeEnum.������˾Ա���˺�.EnumToInt())
            });
            ids = db.Read(fysql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (true, "û�л�ȡ���κ�����!", new
                {
                    allcount =fysql.count,
                    pagenum = 0,
                    data = new object[] { }
                });
            return (true, string.Empty, new
            {
                allcount = fysql.count,
                pagenum = fysql.GetTotalPage(num),
                data = ids.GetVOList(tlist).Select((x)=> {
                    var lcu = x.GetDicVO<Model.Model.LC_User>();
                    var lcp = x.GetDicVO<Model.Model.LC_Position>();
                    return new
                    {
                        lcu.AreaID,
                        lcu.CityID,
                        lcu.CreateTime,
                        lcu.ID,
                        lcu.LogisticsName,
                        lcu.Phone,
                        lcu.PositionID,
                        lcu.ProvincesID,
                        lcu.UID,
                        lcu.UserName,
                        lcu.WX_City,
                        lcu.WX_Country,
                        lcu.WX_HeadPic,
                        lcu.WX_NickName,
                        lcu.WX_Province,
                        lcu.WX_Sex,
                        lcu.ZType,
                        lcu.State,
                        lcp.PositionName,
                    };
                })
            });
        }

        /// <summary>
        /// ��֤�Ƿ���Ҫע��
        /// </summary>
        /// <param name="myuservo"></param>
        /// <returns></returns>
        public static (bool, string, object) GetToRegUser(UserLoginVO myuservo)
        {
            var vo = GetUserVoFromId(myuservo.id);
            if (!vo.Item1)
                return (false, vo.Item2,null);
            if (vo.Item3.ZNumber.StrIsNull())
            {
                switch (myuservo.accountType)
                {
                    case AccountTypeEnum.��ͨ�û��˺�:
                    case AccountTypeEnum.������˾Ա���˺�:
                    case AccountTypeEnum.�����˺�:
                        break;
                    default:
                        return (false, "�˺����Ͳ����޷�����ע�����!", null);
                }
                return (true, string.Empty, new
                {
                    IsReg = false,
                    vo.Item3.ZType,
                    vo.Item3.PositionID,
                });
            }
            else
            {
                return (true, "����Ҫע��!", new
                {
                    IsReg = true, //��ע��
                    vo.Item3.ZType,
                    vo.Item3.PositionID,
                });
            }
        }
        /// <summary>
        /// ������˾�˺Ű�
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="nickName"></param>
        /// <param name="phone"></param>
        /// <param name="logistics">Ҫ�󶨵������ܹ�˾UID</param>
        /// <param name="sheng"></param>
        /// <param name="shi"></param>
        /// <param name="qu"></param>
        /// <param name="lineletter">������ĸ</param>
        /// <returns></returns>
        public static (bool, string) LogisticsAccountBind(UserLoginVO myuservo, string nickName, long phone, string logistics, int sheng, int shi, int qu,string lineletter)
        {
            var box = db.CreateTranSandbox((db) =>
            {

                //�鿴�绰���Ƿ����
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "��ǰ�ֻ����ѱ�ʹ��!");

                //��ʼ��
                Model.Model.LC_User user = new Model.Model.LC_User()
                {
                    UserName = nickName,
                    ZNumber = phone.ToString(),
                    LogisticsName = nickName,
                    Phone = phone.ToString(),
                    LCID = logistics,
                    ProvincesID = sheng,
                    CityID = shi,
                    AreaID = qu,
                    State = logistics.StrIsNotNull() ? 0 : 1
                };
                sql = makesql.MakeUpdateSQL(user, "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "��ʧ��������!");


                //�ж��Ƿ���Ҫ����·
                if (logistics.StrIsNotNull())
                {
                    //��ȡ�����˺��Ƿ����
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",logistics)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if (!ids.ReadIsOk())
                        return (false, "��ȡ�ܹ�˾�˺Ŵ����޷����в���!");
                    Model.Model.LC_User df_user = ids.GetVOList<Model.Model.LC_User>()[0];
                    if (df_user.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != AccountTypeEnum.�����˺�)
                        return (false, "Ȩ�޴���,�޷��󶨵��ܹ�˾!");
                    //��ʼ˫����

                    //�鿴���Ƿ�󶨹�������
                    sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid),
                        new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",logistics)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if(ids.Count()==0)
                    {
                        //���Լ���
                        Model.Model.LC_Line myline = new Model.Model.LC_Line()
                        {
                            CreateTime = DateTime.Now,
                            Start = qu,
                            End = df_user.AreaID,
                            LineID = Tools.NewGuid.GuidTo16String(),
                            Lineletter = lineletter,
                            MyPhone =phone.ConvertData(),
                            MyResponsibleName = nickName,
                            DFPhone = df_user.Phone,
                            DFResponsibleName = df_user.UserName,
                            UID = myuservo.uid,
                            BindLogisticsUid = logistics,
                            State = 0,
                            ApplicantUID = myuservo.uid
                        };
                        sql = makesql.MakeInsertSQL(myline);
                        ids = db.Exec(sql);
                        if (!ids.flag)
                            return (false, ids.errormsg);
                        if (!ids.ExecOk())
                            return (false, "�󶨶Է���������ʧ��!");
                    }

                    //�鿴�Է��Ƿ�󶨹��ҵ�����
                    sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",logistics),
                        new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",myuservo.uid)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if(ids.Count()==0)
                    {
                        //�󶨶Է�����
                        Model.Model.LC_Line dfline = new Model.Model.LC_Line()
                        {
                            Start = df_user.AreaID,
                            End = qu,
                            Lineletter = string.Empty,
                            DFPhone = phone.ConvertData(),
                            DFResponsibleName = nickName,
                            MyPhone = df_user.Phone,
                            MyResponsibleName = df_user.UserName,
                            UID = logistics,
                            BindLogisticsUid = myuservo.uid,
                            State = 0,
                            CreateTime = DateTime.Now,
                            LineID = Tools.NewGuid.GuidTo16String(),
                            ApplicantUID = myuservo.uid
                        };
                        sql = makesql.MakeInsertSQL(dfline);
                        ids = db.Exec(sql);
                        if (!ids.flag)
                            return (false, ids.errormsg);
                        if (!ids.ExecOk())
                            return (false, "��������������ʧ��!");
                    }
                }
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// Ա���˺Ű�
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="nickName"></param>
        /// <param name="phone"></param>
        /// <param name="logistics">Ҫ�󶨵���������˾</param>
        /// <returns></returns>
        public static (bool, string) EmployeeAccountBind(UserLoginVO myuservo, string nickName, long phone,string logistics)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //���������Ƿ����
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@logistics and ztype=@ztype", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@logistics",logistics),
                    new System.Data.SqlClient.SqlParameter("@ztype",GlobalBLL.AccountTypeEnum.�����˺�.EnumToInt())
                },string.Empty,1);
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "��Ҫ�󶨵�����������!");
                Model.Model.LC_User wl_user = ids.GetVOList<Model.Model.LC_User>()[0];

                //�鿴�绰���Ƿ����
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "��ǰ�ֻ����ѱ�ʹ��!");

                //��ʼ��
                Model.Model.LC_User user = new Model.Model.LC_User()
                {
                    UserName = nickName,
                    ZNumber = phone.ToString(),
                    Phone = phone.ToString(),
                    ProvincesID = wl_user.ProvincesID,
                    CityID = wl_user.CityID,
                    AreaID = wl_user.AreaID,
                    LCID = logistics
                };
                sql = makesql.MakeUpdateSQL(user, "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "��ʧ��������!");
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// ��ͨ�˺Ű�
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="phone"></param>
        /// <param name="logistics"></param>
        /// <param name="sheng"></param>
        /// <param name="shi"></param>
        /// <param name="qu"></param>
        /// <returns></returns>
        public static (bool, string) OrdinaryAccountBind(UserLoginVO myuservo, string nickName, long phone, string logistics, int sheng, int shi, int qu)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //���������Ƿ����
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "uid=@logistics and ztype=@ztype", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@logistics",logistics),
                    new System.Data.SqlClient.SqlParameter("@ztype",GlobalBLL.AccountTypeEnum.�����˺�.EnumToInt())
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() == 0)
                    return (false, "��Ҫ�󶨵�����������!");
                
                //�鿴�绰���Ƿ����
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "��ǰ�ֻ����ѱ�ʹ��!");


                //��ʼ��
                Model.Model.LC_User user = new Model.Model.LC_User()
                {
                    UserName = nickName,
                    ZNumber = phone.ToString(),
                    State = 1, //Ĭ�Ͽ�ͨ
                    Phone = phone.ToString(),
                    ProvincesID = sheng,
                    CityID = shi,
                    AreaID = qu,
                };
                sql = makesql.MakeUpdateSQL(user,"uid=@uid",new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "��ʧ��������!");

                //���һ���󶨼�¼
                //�鿴�Ƿ��Ѿ��󶨹���ǰ����UID
                sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "uid=@uid and LogisticsUid=@LogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@LogisticsUid",logistics),
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //���һ��������
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_UserBindLogisticsList()
                    {
                        CreateTime = DateTime.Now,
                        LogisticsUid = logistics,
                        Uid = myuservo.uid
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if (!ids.ExecOk())
                        return (false, "��Ӱ�ʧ��������!");
                }
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// ��ӻ��߸����û�����
        /// </summary>
        /// <param name="suser"></param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(Model.Model.LC_User suser)
        {
            var box = db.CreateTranSandbox<(bool, string, Model.Model.LC_User suser)>((db) =>
            {
                //��ȡ�û��Ƿ����
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "WX_OpenID=@WX_OpenID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@WX_OpenID",suser.WX_OpenID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (ids.ReadIsOk()) //��������
                {
                    var ls_usrvo = ids.GetVOList<Model.Model.LC_User>()[0];
                    if (ls_usrvo.ZNumber.StrIsNotNull()) //�������ע��ɹ��򲻸����û�����
                    {
                        //�����û�����
                        //�ж��Ƿ��Ѿ�����ע�����
                        suser.ZType = null;
                        suser.PositionID = null;
                    }
                    
                    sql = makesql.MakeUpdateSQL(suser, "WX_OpenID=@WX_OpenID");
                }
                else
                {
                    suser.CreateTime = DateTime.Now;
                    suser.UID = Tools.NewGuid.GuidTo16String();
                    if (suser.ZType <= 0)
                        return (false, "�˺����Ͳ���ȷ!",null);
                    sql = makesql.MakeInsertSQL(suser);
                }
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (!ids.ExecOk())
                    return (false, "���»�����û�ʧ��!",null);

                //��ȡ��������
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "WX_OpenID=@WX_OpenID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@WX_OpenID",suser.WX_OpenID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (!ids.ReadIsOk())
                    return (false, "��ע�����������ʧ��???",null);
                Model.Model.LC_User new_suser = ids.GetVOList<Model.Model.LC_User>()[0];

                db.Commit();
                return (true, string.Empty, new_suser);
            });
            return box;
        }

        public static Tuple<bool, string, List<Dictionary<string, I_ModelBase>>> GetLCFHADDList(GlobalBLL.UserLoginVO myuservo)
        {

            //��ȡ�Ұ󶨵������б�
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_UserBindLogisticsList), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false,"��û�а��κ�������˾�޷����з���!",null);

            var ubll_list = ids.GetVOList<Model.Model.LC_UserBindLogisticsList>();

            //�����ѯ
            Type[] tlist = new Type[] {
                typeof(Model.Model.LC_User),
                typeof(Model.Model.LC_Line)
            };
            sql = makesql.MakeSelectArrSql(tlist, "{0}.UID={1}.UID and {0}.UID in ("+ ubll_list.Select(x=>"'"+x.LogisticsUid+"'").ToList().ListToString()+ ")");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, string.Empty, ids.GetVOList(tlist));
            return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, "û���κ�����", null);
        }
        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="my_openid"></param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User) GetUserDataFromOpenID(string my_openid)
        {
            var box = db.CreateDBSandbox((db) =>
            {
                return GetUserVOFromOpenID(my_openid, db);
            });
            return box;
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
        public static Tuple<bool, string> Add(Model.Model.LC_User lC_User,GlobalBLL.UserLoginVO loginvo, string LogisticsUid)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //�ж�
                if (lC_User.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() == GlobalBLL.AccountTypeEnum.��ͨ�û��˺� && LogisticsUid.StrIsNotNull())
                {
                    //��ȡ������˾�˺�����
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",LogisticsUid)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ReadIsOk())
                        return new Tuple<bool, string>(false, "û���ҵ��κ�������˾����!");
                    Model.Model.LC_User wl_uservo = ids.GetVOList<Model.Model.LC_User>()[0];
                    lC_User.ProvincesID = wl_uservo.ProvincesID;
                    lC_User.CityID = wl_uservo.CityID;
                    lC_User.AreaID = wl_uservo.AreaID;

                    //��Ӳ�ѯ�Ƿ��Ѿ��󶨹�
                    sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",lC_User.ZNumber)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (ids.Count() == 0)
                    {
                        //���һ��������
                        sql = makesql.MakeInsertSQL(new Model.Model.LC_UserBindLogisticsList()
                        {
                            CreateTime = DateTime.Now,
                            LogisticsUid = LogisticsUid,
                            Uid = loginvo.uid.StrIsNull() ? lC_User.UID : loginvo.uid
                        });
                        ids = db.Exec(sql);
                        if (!ids.flag)
                            return new Tuple<bool, string>(false, ids.errormsg);
                    }
                }
                //if(loginvo.uid.StrIsNull()) //���û�е�½�򴴽�һ���˺�
                {
                    //�ж��˺��Ƿ����
                    sql = makesql.MakeCount(nameof(Model.Model.LC_User), "ZNumber=@ZNumber", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@ZNumber",lC_User.ZNumber)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if(ids.Count()>0)
                    {
                        return new Tuple<bool, string>(false,"���ʺ���ע�ᣡ");
                    }
                    if (ids.Count() == 0)
                    {
                        sql = makesql.MakeInsertSQL(lC_User);
                        ids = db.Exec(sql);
                        if (!ids.flag)
                            return new Tuple<bool, string>(false, ids.errormsg);
                        if (!ids.ExecOk())
                            return new Tuple<bool, string>(false, "ע���˺�ʱʧ��,������!");
                    }
                }

                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
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
