using System;
using System.Collections.Generic;
using SuperDataBase;
using CustomExtensions;
using SuperDataBase.InterFace;
using System.Linq;
using Model.Model;
using GlobalBLL;

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
                return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "没有任何数据!", new List<Model.Model.LC_Line>());
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Line>());
        }

        /// <summary>
        /// 获取司机列表
        /// </summary>
        /// <param name="myuservo"></param>
        /// <returns></returns>
        public static (bool, string, object) GetDriverList(UserLoginVO myuservo)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "PositionID=@PositionID and State=1 and LCID=@LCID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@PositionID",PositionEnum.驾驶员.EnumToInt()),
                new System.Data.SqlClient.SqlParameter("@LCID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_User>());
        }

        /// <summary>
        /// 获取我的线路列表
        /// </summary>
        /// <param name="myuservo"></param>
        /// <returns></returns>
        public static (bool, string, object) GetMyLineList(UserLoginVO myuservo)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "UID=@UID and State=1", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@UID",myuservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true,"没有任何数据!",new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Line>().Select((x)=> {
                var startvo = DAL.DALBase.GetAllAddressNames(x.Start);
                var endvo = DAL.DALBase.GetAllAddressNames(x.End);
                return new
                {
                    x.DFPhone,
                    x.DFResponsibleName,
                    x.Start,
                    x.End,
                    x.BindLogisticsUid,
                    x.ID,
                    x.LineID,
                    x.Lineletter,
                    x.MyPhone,
                    x.MyResponsibleName,
                    x.State,
                    x.UID,
                    start_sheng = startvo.sheng,
                    start_shi = startvo.shi,
                    start_qu = startvo.qu,
                    end_sheng = endvo.sheng,
                    end_shi = endvo.shi,
                    end_qu = endvo.qu
                };
            }));
        }

        /// <summary>
        /// 主动绑定线路
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="lineletter"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static (bool, string) LineActiveApplication(UserLoginVO myuservo, string lineletter, string phone)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //查看此物流是否存在
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "Phone=@Phone", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@Phone",phone)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "没有找到您要绑定的物流公司数据!");
                Model.Model.LC_User lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (lcu.State != 0)
                    return (false, "当前您要绑定的物流公司不可用!");

                //检测我是否已经绑定过此物流
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "UID=@UID and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@UID",myuservo.uid),
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",lcu.UID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() > 0)
                    return (false, "不可以重复绑定相同的物流!");

                //开始绑定我的数据
                Model.Model.LC_Line my_line = new Model.Model.LC_Line()
                {
                    ApplicantUID = myuservo.uid,
                    BindLogisticsUid = lcu.UID,
                    LineID = Tools.NewGuid.GuidTo16String(),
                    CreateTime = DateTime.Now,
                    DFPhone = lcu.Phone,
                    DFResponsibleName = lcu.UserName,
                    Lineletter = lineletter,
                    End = lcu.AreaID,
                    MyPhone = myuservo.phones,
                    MyResponsibleName = myuservo.username,
                    Start = myuservo.AreaID,
                    State = 0,
                    UID = myuservo.uid,
                };
                //插入数据库
                sql = makesql.MakeInsertSQL(my_line);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "绑定失败!");

                //绑定对方数据
                Model.Model.LC_Line df_line = new Model.Model.LC_Line()
                {
                    ApplicantUID = myuservo.uid,
                    BindLogisticsUid = myuservo.uid,
                    LineID = Tools.NewGuid.GuidTo16String(),
                    CreateTime = DateTime.Now,
                    DFPhone = myuservo.phones,
                    DFResponsibleName = myuservo.username,
                    End = myuservo.AreaID,
                    MyPhone = lcu.Phone,
                    MyResponsibleName = lcu.UserName,
                    Start = lcu.AreaID,
                    State = 0,
                    UID = lcu.UID,
                };
                sql = makesql.MakeInsertSQL(df_line);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "绑定对方数据时失败!");

                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 获取线路数据
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static (bool, string, object) GetLineData(UserLoginVO myuservo, long id)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "id=@id", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@id",id)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg,null);
            if (!ids.ReadIsOk())
                return (false, "没有找到任何数据!", null);
            var vo = ids.GetVOList<Model.Model.LC_Line>()[0];
            return (true, string.Empty, new {
                vo.DFPhone,
                vo.DFResponsibleName,
                vo.MyPhone,
                vo.MyResponsibleName,
                StartName =DAL.DALBase.GetAllAddressToString(vo.Start.ConvertData<int>()).Replace(" ",""),
                EndName = DAL.DALBase.GetAllAddressToString(vo.End.ConvertData<int>()).Replace(" ", ""),
                vo.OpenTime
            });
        }

        /// <summary>
        /// 线路授权
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static (bool, string) LineAuthorization(UserLoginVO myuservo, long id,int state,string Lineletter)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //获取数据 
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Line), "id=@id", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@id",id)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "当前要操作的线路不存在!");
                var my_line = ids.GetVOList<Model.Model.LC_Line>()[0];

                //判断状态
                if (my_line.State != 0)
                    return (false, "当前线路不是未授权状态,无法进行操作!");
                if (!my_line.UID.Equals(myuservo.uid, StringComparison.OrdinalIgnoreCase))
                    return (false, "当前不是您的数据无法进行操作!");
                if (my_line.UID.Equals(my_line.ApplicantUID))
                    return (false, "您没有权限审核系统!");

                //更新我方线路状态
                sql = makesql.MakeUpdateSQL(new Model.Model.LC_Line()
                {
                    State = state,
                    Lineletter = Lineletter,
                    OpenTime = (state==1 ? (DateTime?)DateTime.Now : null)
                }, "id=@id", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@id",id)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "授权失败请重试!");

                //更新对方线路状态
                sql = makesql.MakeUpdateSQL(new Model.Model.LC_Line()
                {
                    State = state,
                    OpenTime = (state == 1 ? (DateTime?)DateTime.Now : null)
                }, "BindLogisticsUid=@BindLogisticsUid and UID=@UID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",myuservo.uid),
                    new System.Data.SqlClient.SqlParameter("@UID",my_line.BindLogisticsUid)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ExecOk())
                    return (false, "授权失败请重试!");
                db.Commit();
                return (true, string.Empty);
            });
            return box;
            
        }

        /// <summary>
        /// 线路绑定
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="lineletter">货号字母</param>
        /// <param name="logistics">物流UID</param>
        /// <returns></returns>
        public static (bool, string) LineBinding(UserLoginVO myuservo, string lineletter, string logistics)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //获取物流账号是否存在
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",logistics)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return (false, "获取您要绑定的物流数据操作!");
                Model.Model.LC_User df_user = ids.GetVOList<Model.Model.LC_User>()[0];
                if (df_user.ZType.ConvertData<AccountTypeEnum>() != AccountTypeEnum.物流账号)
                    return (false, "您要绑定的数据不是物流账号!");
                //开始双方绑定

                //查看我是否绑定过此物流
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",myuservo.uid),
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",logistics)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return (false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //绑定自己的
                    Model.Model.LC_Line myline = new Model.Model.LC_Line()
                    {
                        CreateTime = DateTime.Now,
                        Start = myuservo.AreaID,
                        End = df_user.AreaID,
                        LineID = Tools.NewGuid.GuidTo16String(),
                        Lineletter = lineletter,
                        MyPhone = myuservo.phones.ConvertData(),
                        MyResponsibleName = myuservo.username,
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
                if (ids.Count() == 0)
                {
                    //绑定对方物流
                    Model.Model.LC_Line dfline = new Model.Model.LC_Line()
                    {
                        Start = df_user.AreaID,
                        End = myuservo.AreaID,
                        Lineletter = string.Empty,
                        DFPhone = myuservo.phones.ConvertData(),
                        DFResponsibleName = myuservo.username,
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
                db.Commit();
                return (true, string.Empty);
            });
            return box;
        }
        /// <summary>
        /// 获取线路授权列表
        /// </summary>
        /// <param name="myuservo"></param>
        /// <param name="page"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static (bool, string, object) GetLineAuthorizationList(UserLoginVO myuservo, int page, int num)
        {
            fysql = makesql.MakeSelectFY(typeof(Model.Model.LC_Line), "UID=@UID and State=0 and UID!=ApplicantUID", "id desc",page,num,"id",new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@UID",myuservo.uid)
            });
            ids = db.Read(fysql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "没有任何数据!", new
                {
                    allcount = fysql.count,
                    data = new object[] { }
                });

            return (true, string.Empty, new
            {
                allcount = fysql.count,
                data = ids.GetVOList<Model.Model.LC_Line>().Select((x) =>
                {
                    return new
                    {
                        x.ID,
                        CreateTime =  x.CreateTime.ConvertData<DateTime>().ToString("yyyy年MM月dd"),
                        x.Lineletter,
                        x.Start,
                        x.End,
                        StartName = DAL.DALBase.GetAllAddressToString(x.Start.ConvertData<int>()).Replace(" ", ""),
                        EndName = DAL.DALBase.GetAllAddressToString(x.End.ConvertData<int>()).Replace(" ", ""),
                        x.DFPhone,
                        x.DFResponsibleName,
                        x.State
                    };
                })
            });
        }

        /// <summary>
        /// 合作物流
        /// </summary>
        /// <param name="zNumber"></param>
        /// <param name="pwd"></param>
        /// <param name="bindUid"></param>
        /// <param name="Lineletter">我的物流运号首字母</param>
        /// <param name="bindLineletter">对方物流运号首字母</param>
        /// <returns></returns>
        public static Tuple<bool, string> BindHZ(string zNumber, string pwd, string bindUid,string myLineletter,string bindLineletter)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                //查看您的账号是否存在
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "zNumber=@zNumber and Password=@Password", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@zNumber",zNumber),
                    new System.Data.SqlClient.SqlParameter("@Password",pwd)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "没有找到您的账号!");
                Model.Model.LC_User my_lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (my_lcu.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != GlobalBLL.AccountTypeEnum.物流账号)
                    return new Tuple<bool, string>(false, "您的账号权限不正确,无法进行操作!");

                //获取绑定方账号信息
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "uid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@uid",bindUid)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "没有找到要绑定方的合作物流数据!");
                Model.Model.LC_User bind_lcu = ids.GetVOList<Model.Model.LC_User>()[0];
                if (bind_lcu.ZType.ConvertData<GlobalBLL.AccountTypeEnum>() != GlobalBLL.AccountTypeEnum.物流账号)
                    return new Tuple<bool, string>(false, "账号类型不能为空!");

                #region 开始我方开始绑定

                //查看我是否绑定过
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@uid and BindLogisticsUid=@BindLogisticsUid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",bind_lcu.UID),
                    new System.Data.SqlClient.SqlParameter("@uid",my_lcu.UID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //绑定我方
                    Model.Model.LC_Line my_ll = new Model.Model.LC_Line()
                    {
                        BindLogisticsUid = bind_lcu.UID,
                        CreateTime = DateTime.Now,
                        End = bind_lcu.AreaID,
                        LineID = Tools.NewGuid.GuidTo16String(),
                        MyPhone = my_lcu.Phone.ConvertData(),
                        MyResponsibleName = my_lcu.UserName,
                        DFPhone = bind_lcu.Phone,
                        DFResponsibleName = bind_lcu.UserName,
                        UID = my_lcu.UID,
                        Start = my_lcu.AreaID,
                        Lineletter = myLineletter,
                        ApplicantUID = my_lcu.UID
                    };
                    //准备添加
                    sql = makesql.MakeInsertSQL(my_ll);
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "添加绑定失败!");
                }
                #endregion


                //判断是否为相同的账号
                if (bindUid.Equals(my_lcu.UID))
                    return new Tuple<bool,string>(false, "不能绑定给自己!");


                if (bind_lcu.AreaID == my_lcu.AreaID)
                    return new Tuple<bool, string>(false, "不能绑定相同地区的物流!");

                #region 对方开始绑定
                //查看对方数据是否存在我的物流绑定
                sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "uid=@BindLogisticsUid and BindLogisticsUid=@uid", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@BindLogisticsUid",bind_lcu.UID),
                    new System.Data.SqlClient.SqlParameter("@uid",my_lcu.UID)
                });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (ids.Count() == 0)
                {
                    //添加数据绑定
                    Model.Model.LC_Line bind_ll = new Model.Model.LC_Line()
                    {
                        BindLogisticsUid = my_lcu.UID,
                        CreateTime = DateTime.Now,
                        End = my_lcu.AreaID,
                        LineID = Tools.NewGuid.GuidTo16String(),
                        DFPhone = my_lcu.Phone.ConvertData(),
                        DFResponsibleName = my_lcu.UserName,
                        MyPhone = bind_lcu.Phone,
                        MyResponsibleName = bind_lcu.UserName,
                        UID = bind_lcu.UID,
                        Start = bind_lcu.AreaID,
                        Lineletter = bindLineletter,
                        ApplicantUID = my_lcu.UID
                    };
                    sql = makesql.MakeInsertSQL(bind_ll);
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "添加绑定失败!");
                }
                #endregion
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// 获取单路线数据
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
            lclo.UserName = GetUserVoFromUID(lclo.UID).Item3?.UserName??string.Empty;
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
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "没有任何数据!", new List<Model.Model.LC_Line>());
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

            //获取线路列表
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(true, "没有任何数据!", new List<Model.Model.LC_Line_Other>());

            //解析表结构
            var lcl_list = ids.GetVOList<Model.Model.LC_Line_Other>();

            List<Model.Model.LC_Region> lcr_list = new List<Model.Model.LC_Region>();
            #region 获取地址列表
            //我把所有的地址ID放在一起
            List<int> addresslist = new List<int>();

            addresslist.AddRange(lcl_list.Select(x => x.Start.ConvertData<int>()));
            addresslist.AddRange(lcl_list.Select(x => x.End.ConvertData<int>()));


            //把这些ID获取出来地址数据
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Region), "ID in (" + addresslist.ListToString() + ")");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                lcr_list = ids.GetVOList<Model.Model.LC_Region>();

            #endregion

            return new Tuple<bool, string, List<Model.Model.LC_Line_Other>>(true, string.Empty, lcl_list.Select((x) => {
                //获取地区名字
                x.StartCityName = GetAllAddressToString(x.Start.ConvertData<int>());
                x.EndCityName = GetAllAddressToString(x.End.ConvertData<int>());
                return x;
            }).ToList());
        }

        //添加新路线
        public static Tuple<bool,string> Add(Model.Model.LC_Line LC_Line, GlobalBLL.UserLoginVO uservo)
        {
            //查看是否存在
            sql = makesql.MakeCount(nameof(Model.Model.LC_Line), "[End]=@End and uid=@uid",new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@End",LC_Line.End),
                new System.Data.SqlClient.SqlParameter("@uid",uservo.uid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (ids.Count() > 0)
                return new Tuple<bool, string>(false, "您已经添加过此路线,无需重复添加!");

            sql = makesql.MakeInsertSQL(LC_Line);
            ids = db.Exec(sql);
            if(!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "添加失败请重试!");
            return new Tuple<bool, string>(true, string.Empty);
        }
        /// <summary>
        /// 中转-中转地下拉
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
            return new Tuple<bool, string, List<Model.Model.LC_Line>>(true, "没有任何数据!", new List<Model.Model.LC_Line>());
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
