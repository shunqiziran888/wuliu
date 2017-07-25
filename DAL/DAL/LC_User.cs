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
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "没有任何数据!", new List<Model.Model.LC_User>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetLCList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZType=1 and LogisticsName is not null");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "没有任何数据!", new List<Model.Model.LC_User>());
        }

        /// <summary>
        /// 获取账号数据
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
                return (false, "没有找到任何数据!", null);
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
        /// 员工授权
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static (bool, string) EmployeeEmpowerment(UserLoginVO myuservo, long id, UserStateEnum state)
        {
            //查看此账号是否为您的账号
            sql = makesql.MakeCount(nameof(Model.Model.LC_User), "id=@id and LCID=@LCID and ZType=@ZType", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@id",id),
                new System.Data.SqlClient.SqlParameter("@LCID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@ZType",GlobalBLL.AccountTypeEnum.物流公司员工账号.EnumToInt())
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (ids.Count() == 0)
                return (false, "当前数据错误,无法进行操作!");
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
                return (false, "操作失败!");
            return (true, string.Empty);
        }

        /// <summary>
        /// 获取员工授权列表
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
                new System.Data.SqlClient.SqlParameter("@ZType",GlobalBLL.AccountTypeEnum.物流公司员工账号.EnumToInt())
            });
            ids = db.Read(fysql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (true, "没有获取到任何数据!", new
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
        /// 验证是否需要注册
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
                    case AccountTypeEnum.普通用户账号:
                    case AccountTypeEnum.物流公司员工账号:
                    case AccountTypeEnum.物流账号:
                        break;
                    default:
                        return (false, "账号类型不符无法进行注册操作!", null);
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
                return (true, "不需要注册!", new
                {
                    IsReg = true, //已注册
                    vo.Item3.ZType,
                    vo.Item3.PositionID,
                });
            }
        }
        /// <summary>
        /// 物流公司账号绑定
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="nickName"></param>
        /// <param name="phone"></param>
        /// <param name="logistics">要绑定的物流总公司UID</param>
        /// <param name="sheng"></param>
        /// <param name="shi"></param>
        /// <param name="qu"></param>
        /// <param name="lineletter">货号字母</param>
        /// <returns></returns>
        public static (bool, string) LogisticsAccountBind(UserLoginVO myuservo, string nickName, long phone, string logistics, int sheng, int shi, int qu,string lineletter)
        {
            var box = db.CreateTranSandbox((db) =>
            {

                //查看电话号是否存在
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "当前手机号已被使用!");

                //开始绑定
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
                    return (false, "绑定失败请重试!");


                //判断是否需要绑定线路
                if (logistics.StrIsNotNull())
                {
                    //获取物流账号是否存在
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",logistics)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if (!ids.ReadIsOk())
                        return (false, "获取总公司账号错误无法进行操作!");
                    Model.Model.LC_User df_user = ids.GetVOList<Model.Model.LC_User>()[0];
                    if (df_user.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != AccountTypeEnum.物流账号)
                        return (false, "权限错误,无法绑定到总公司!");
                    //开始双方绑定

                    //查看我是否绑定过此物流
                    sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid),
                        new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",logistics)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if(ids.Count()==0)
                    {
                        //绑定自己的
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
                            return (false, "绑定对方物流数据失败!");
                    }

                    //查看对方是否绑定过我的物流
                    sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",logistics),
                        new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",myuservo.uid)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return (false, ids.errormsg);
                    if(ids.Count()==0)
                    {
                        //绑定对方物流
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
                            return (false, "绑定您的物流数据失败!");
                    }
                }
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 员工账号绑定
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="nickName"></param>
        /// <param name="phone"></param>
        /// <param name="logistics">要绑定到的物流公司</param>
        /// <returns></returns>
        public static (bool, string) EmployeeAccountBind(UserLoginVO myuservo, string nickName, long phone,string logistics)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //检测此物流是否存在
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@logistics and ztype=@ztype", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@logistics",logistics),
                    new System.Data.SqlClient.SqlParameter("@ztype",GlobalBLL.AccountTypeEnum.物流账号.EnumToInt())
                },string.Empty,1);
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "您要绑定的物流不存在!");
                Model.Model.LC_User wl_user = ids.GetVOList<Model.Model.LC_User>()[0];

                //查看电话号是否存在
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "当前手机号已被使用!");

                //开始绑定
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
                    return (false, "绑定失败请重试!");
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 普通账号绑定
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
                //检测此物流是否存在
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "uid=@logistics and ztype=@ztype", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@logistics",logistics),
                    new System.Data.SqlClient.SqlParameter("@ztype",GlobalBLL.AccountTypeEnum.物流账号.EnumToInt())
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() == 0)
                    return (false, "您要绑定的物流不存在!");
                
                //查看电话号是否存在
                sql = makesql.MakeCount(nameof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "当前手机号已被使用!");


                //开始绑定
                Model.Model.LC_User user = new Model.Model.LC_User()
                {
                    UserName = nickName,
                    ZNumber = phone.ToString(),
                    State = 1, //默认开通
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
                    return (false, "绑定失败请重试!");

                //添加一个绑定记录
                //查看是否已经绑定过当前物流UID
                sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "uid=@uid and LogisticsUid=@LogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@LogisticsUid",logistics),
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //添加一个物流绑定
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
                        return (false, "添加绑定失败请重试!");
                }
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 添加或者更新用户数据
        /// </summary>
        /// <param name="suser"></param>
        /// <returns></returns>
        public static (bool, string, Model.Model.LC_User suser) AddOrUpdateUserVO(Model.Model.LC_User suser)
        {
            var box = db.CreateTranSandbox<(bool, string, Model.Model.LC_User suser)>((db) =>
            {
                //获取用户是否存在
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "WX_OpenID=@WX_OpenID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@WX_OpenID",suser.WX_OpenID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (ids.ReadIsOk()) //更新数据
                {
                    var ls_usrvo = ids.GetVOList<Model.Model.LC_User>()[0];
                    if (ls_usrvo.ZNumber.StrIsNotNull()) //如果彻底注册成功则不更新用户类型
                    {
                        //更新用户数据
                        //判断是否已经彻底注册完毕
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
                        return (false, "账号类型不正确!",null);
                    sql = makesql.MakeInsertSQL(suser);
                }
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (!ids.ExecOk())
                    return (false, "更新或添加用户失败!",null);

                //获取最后的数据
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "WX_OpenID=@WX_OpenID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@WX_OpenID",suser.WX_OpenID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg,null);
                if (!ids.ReadIsOk())
                    return (false, "刚注册完的数据消失了???",null);
                Model.Model.LC_User new_suser = ids.GetVOList<Model.Model.LC_User>()[0];

                db.Commit();
                return (true, string.Empty, new_suser);
            });
            return box;
        }

        public static Tuple<bool, string, List<Dictionary<string, I_ModelBase>>> GetLCFHADDList(GlobalBLL.UserLoginVO myuservo)
        {

            //获取我绑定的物流列表
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_UserBindLogisticsList), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(false,"您没有绑定任何物流公司无法进行发货!",null);

            var ubll_list = ids.GetVOList<Model.Model.LC_UserBindLogisticsList>();

            //两表查询
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
            return new Tuple<bool, string, List<Dictionary<string, I_ModelBase>>>(true, "没有任何数据", null);
        }
        /// <summary>
        /// 获取用户数据
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
        /// 获取申请人列表
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetSQList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), $"State=0 and ZType={GlobalBLL.AccountTypeEnum.物流公司员工账号.EnumToInt()}");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "没有任何数据!", new List<Model.Model.LC_User>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_User>> GetSQAllList()
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), $"State=1  and ZType={GlobalBLL.AccountTypeEnum.物流公司员工账号.EnumToInt()}");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_User>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_User>>(true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
            return new Tuple<bool, string, List<Model.Model.LC_User>>(true, "没有任何数据!", new List<Model.Model.LC_User>());
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
                //判断
                if (lC_User.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() == GlobalBLL.AccountTypeEnum.普通用户账号 && LogisticsUid.StrIsNotNull())
                {
                    //获取物流公司账号数据
                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",LogisticsUid)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ReadIsOk())
                        return new Tuple<bool, string>(false, "没有找到任何物流公司数据!");
                    Model.Model.LC_User wl_uservo = ids.GetVOList<Model.Model.LC_User>()[0];
                    lC_User.ProvincesID = wl_uservo.ProvincesID;
                    lC_User.CityID = wl_uservo.CityID;
                    lC_User.AreaID = wl_uservo.AreaID;

                    //添加查询是否已经绑定过
                    sql = makesql.MakeCount(nameof(Model.Model.LC_UserBindLogisticsList), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@uid",lC_User.ZNumber)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (ids.Count() == 0)
                    {
                        //添加一个物流绑定
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
                //if(loginvo.uid.StrIsNull()) //如果没有登陆则创建一个账号
                {
                    //判断账号是否存在
                    sql = makesql.MakeCount(nameof(Model.Model.LC_User), "ZNumber=@ZNumber", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@ZNumber",lC_User.ZNumber)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if(ids.Count()>0)
                    {
                        return new Tuple<bool, string>(false,"此帐号已注册！");
                    }
                    if (ids.Count() == 0)
                    {
                        sql = makesql.MakeInsertSQL(lC_User);
                        ids = db.Exec(sql);
                        if (!ids.flag)
                            return new Tuple<bool, string>(false, ids.errormsg);
                        if (!ids.ExecOk())
                            return new Tuple<bool, string>(false, "注册账号时失败,请重试!");
                    }
                }

                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }
        /// <summary>
        /// 登录帐号
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
                    return new Tuple<bool, string, Model.Model.LC_User>(false, "正在审核中，请稍候登录!", null);
                }
                else if(lcu.State==2)
                {
                    return new Tuple<bool, string, Model.Model.LC_User>(false, "审核未通过，无法登录！!", null);
                }
                return new Tuple<bool, string, Model.Model.LC_User>(true, string.Empty, lcu);
            }
            return new Tuple<bool, string, Model.Model.LC_User>(false, "手机号或密码错误!", null);
        }
        public static Tuple<bool, string> UpdateYesOrNo(Model.Model.LC_User LC_User, string UID)
        {
            sql = makesql.MakeUpdateSQL(LC_User, "UID='" + UID + "'");
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "修改失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
