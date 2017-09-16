using System;
using GlobalBLL;
using System.Linq;
using CustomExtensions;
using SuperDataBase;
using System.Collections.Generic;
using System.Data;
using SuperDataBase.Vo;
using SuperDataBase.InterFace;

namespace DAL.DAL
{
    /// <summary>
    /// -
    /// </summary>
    [Serializable]
    public partial class LC_Customer : DALBase
    {
        public LC_Customer()
        { }
        /// <summary>
        /// �ͻ����������
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <returns></returns>
        public static Tuple<bool, string> Add(Model.Model.LC_Customer LC_Customer)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeInsertSQL(LC_Customer);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "���ʧ��������!");
                AddToHistory(LC_Customer, db);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// ������ӵ���ʷ��¼
        /// </summary>
        /// <param name="lcc"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(Model.Model.LC_Customer lcc, SuperDataBase.Model.DBSandbox db)
        {
            sql = makesql.MakeCount(nameof(Model.Model.LC_History), "OrderID=@OrderID and state=@state", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@state",lcc.State),
                new System.Data.SqlClient.SqlParameter("@OrderID",lcc.OrderID)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (ids.Count() > 0)
            {
                return (true, "�Ѿ���������ͬ��״̬");
            }

            sql = makesql.MakeInsertSQL(new Model.Model.LC_History()
            {
                begins = lcc.begins,
                beginUID = lcc.beginUID,
                CarryGood = lcc.CarryGood,
                Consignee = lcc.Consignee,
                ConsigneeTime = lcc.ConsigneeTime,
                Consignor = lcc.Consignor,
                ConsignorID = lcc.ConsignorID,
                DdTime = lcc.DdTime,
                Destination = lcc.Destination,
                DischargeTime = lcc.DischargeTime,
                DriverID = lcc.DriverID,
                FHPhone = lcc.FHPhone,
                finish = lcc.finish,
                finishUID = lcc.finishUID,
                Freight = lcc.Freight,
                FreightCollect = lcc.FreightCollect,
                freightMode = lcc.freightMode,
                GoodName = lcc.GoodName,
                GoodNo = lcc.GoodNo,
                GReceivables = lcc.GReceivables,
                HistoryTime = DateTime.Now,
                Initially = lcc.Initially,
                largeCar = lcc.largeCar,
                logisticsID = lcc.logisticsID,
                MeetCarTime = lcc.MeetCarTime,
                Number = lcc.Number,
                OrderID = lcc.OrderID,
                OtherExpenses = lcc.OtherExpenses,
                ReceiptGood = lcc.ReceiptGood,
                SHPhone = lcc.SHPhone,
                State = lcc.State,
                Total = lcc.Total,
                TruckTime = lcc.TruckTime,
                VehicleID = lcc.VehicleID
            });
            ids = db.Exec(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ExecOk())
                return (false, "�����ʷʧ��!");
            return (true, string.Empty);
        }

        public static (bool, string, object) GetMyCount(UserLoginVO myuservo,DateTime DischargeTime,DateTime fristtime,DateTime lasttime)
        {
            //�������
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as TotalCount from LC_Customer where logisticsID='"+myuservo.uid+ "'and DischargeTime>='" + DischargeTime.AddDays(1).ToString("yyyy-MM-dd") + "' and DischargeTime<'" + DischargeTime.AddDays(2).ToString("yyyy-MM-dd") + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            var r = ids.dt.Rows[0];
            //�����տ�
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as YesterdayTotalCount from LC_Customer where logisticsID='"+myuservo.uid+"' and DischargeTime>='"+ DischargeTime.ToString("yyyy-MM-dd") + "' and DischargeTime<'"+DischargeTime.AddDays(1).ToString("yyyy-MM-dd")+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            var zuotian = ids.dt.Rows[0];
            //����֧��
            sql = new SuperDataBase.Vo.SqlVO(@"select SUM(Total) as ThismonthCount  from LC_Customer where logisticsID='" + myuservo.uid+"'  and DischargeTime>='"+fristtime+"'  and DischargeTime<'"+lasttime+"'");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            var Thismonth = ids.dt.Rows[0];


            return (true, string.Empty, new {
                TotalCount = r["TotalCount"].ConvertData<long>(),
                YesterdayTotalCount = zuotian["YesterdayTotalCount"].ConvertData<long>(),
                ThismonthCount= Thismonth["ThismonthCount"].ConvertData<long>()
            });
        }

        public static (bool, string, object) GetCollectDebtsDetailTop(UserLoginVO myuservo, string sHPhone)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"select SHPhone,Consignee,Count(SHPhone) as SHPhone,Sum(Freight) as Freight,Sum(GReceivables) as GReceivables,
                            (select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime asc) as 'StartTime',(select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime desc) as 'EndTime'
                            from LC_Customer a
                            where State=9 and logisticsID='" + myuservo.uid + "' and SHPhone='" + sHPhone + "' group by SHPhone,Consignee,logisticsID");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            return (true, string.Empty, ids.dt);
        }

        public static (bool, string, object) GetCollectDebtsEdit(UserLoginVO myuservo, string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and OrderID=@OrderID and State=@State", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@OrderID",OID),
                new System.Data.SqlClient.SqlParameter("@State","9")
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        }

        public static (bool, string, object) GetCollectDebtsDetail(UserLoginVO myuservo, string SHPhone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and SHPhone=@SHPhone and State=@State", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",myuservo.uid),
                new System.Data.SqlClient.SqlParameter("@SHPhone",SHPhone),
                new System.Data.SqlClient.SqlParameter("@State","9")
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            return (true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        }

        public static (bool, string, object) GetCollectDebts(UserLoginVO myuservo)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"
                        select SHPhone,Consignee,Count(SHPhone) as SHPhone,Sum(Freight) as Freight,Sum(GReceivables) as GReceivables,
                        (select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime asc) as 'StartTime',(select top 1(ArrearsTime) from LC_Customer where State=9 and logisticsID=a.logisticsID order by ArrearsTime desc) as 'EndTime'
                        from LC_Customer a
                        where State=9 and logisticsID='" + myuservo.uid + "' group by SHPhone,Consignee,logisticsID");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            return (true, string.Empty, ids.dt);
        }

        /// <summary>
        /// �Ѷ����б���ӵ���ʷ
        /// </summary>
        /// <param name="orderNumberList"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(List<string> orderNumberList, SuperDataBase.Model.DBSandbox db)
        {
            return AddToHistory(orderNumberList.Select(x => $"'{x}'").ToList().ListToString(), db);
        }

        /// <summary>
        /// �����ʷ��¼
        /// </summary>
        /// <param name="VehicleID">����ID</param>
        /// <param name="nowUid">��ǰ������˾UID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(int VehicleID, string nowUid, SuperDataBase.Model.DBSandbox db)
        {
            //��ȡ���ж�������
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"VehicleID=@VehicleID and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",VehicleID),
                new System.Data.SqlClient.SqlParameter("@finishUID",nowUid)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ReadIsOk())
                return (false, "��ȡ����ʧ��!");
            foreach (var p in ids.GetVOList<Model.Model.LC_Customer>())
            {
                var vv = AddToHistory(p, db);
                if (!vv.Item1)
                    return (false, vv.Item2);
            }
            return (true, string.Empty);
        }



        /// <summary>
        /// �Ѷ����б���ӵ���ʷ
        /// </summary>
        /// <param name="orderNumberStr"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static (bool, string) AddToHistory(string orderNumberStr, SuperDataBase.Model.DBSandbox db)
        {
            //��ȡ���ж�������
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"OrderID in({orderNumberStr})");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg);
            if (!ids.ReadIsOk())
                return (false, "��ȡ����ʧ��!");
            foreach (var p in ids.GetVOList<Model.Model.LC_Customer>())
            {
                var vv = AddToHistory(p, db);
                if (!vv.Item1)
                    return (false, vv.Item2);
            }
            return (true, string.Empty);
        }

        /// <summary>
        /// ���������ӳ�
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cH"></param>
        /// <param name="End">Ŀ�ĵ�</param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdateMC(long id, int cH, string UID, int End)
        {
            var box = db.CreateTranSandbox<Tuple<bool, string>>((db) =>
             {
                 var uservo = GetUserVoFromId(id, db);
                 if (!uservo.Item1)
                     return new Tuple<bool, string>(false, uservo.Item2);

                 #region ���¶����Ѿ������յ�Ķ���
                 sql = makesql.MakeUpdateSQL(new Model.Model.LC_Customer()
                 {
                     State = 4,
                     logisticsID = UID,
                     MeetCarTime = DateTime.Now
                 }, "Destination=finish and VehicleID=@VehicleID and State=3 and finish=@finish and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH),
                    new System.Data.SqlClient.SqlParameter("@finish",End),
                    new System.Data.SqlClient.SqlParameter("@finishUID",UID)
                 });
                 ids = db.Exec(sql);
                 if (!ids.flag)
                     return new Tuple<bool, string>(false, ids.errormsg);
                 #endregion

                 #region ���¶�����ǰδ���յ�Ķ���
                 sql = makesql.MakeUpdateSQL(new Model.Model.LC_Customer()
                 {
                     State = 7,
                     logisticsID = UID
                 }, "Destination<>finish and VehicleID=@VehicleID and State=3 and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@VehicleID",cH),
                    new System.Data.SqlClient.SqlParameter("@finish",End)
                 });
                 ids = db.Exec(sql);
                 if (!ids.flag)
                     return new Tuple<bool, string>(false, ids.errormsg);
                 #endregion

                 var ath = AddToHistory(cH, UID, db);
                 if (!ath.Item1)
                     return new Tuple<bool, string>(false, ath.Item2);

                 db.Commit();
                 return new Tuple<bool, string>(true, string.Empty);
             });
            return box;
        }

        /// <summary>
        ///�ջ����б��ѯ
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCusList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=1 and logisticsID='" + UID + "'",new System.Data.SqlClient.SqlParameter[] {
            }, "DdTime desc");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// ���£���ID
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <param name="updateGoodNum">�Ƿ���»���</param>
        /// <returns></returns>
        public static Tuple<bool, string> Update(Model.Model.LC_Customer LC_Customer, string OrderID, bool updateGoodNum = false)
        {
            Model.Model.LC_Customer lcc = null;
            var box = db.CreateTranSandbox((db) =>
            {
                //��ȡ�˶�������
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",OrderID)
                    });
                ids = db.Read(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ReadIsOk())
                    return new Tuple<bool, string>(false, "û���ҵ��κζ������ݣ�");
                lcc = ids.GetVOList<Model.Model.LC_Customer>()[0];
                if (updateGoodNum)
                {

                    lcc.finish = LC_Customer.finish;
                    lcc.begins = LC_Customer.begins;
                    if (lcc.GoodNo.StrIsNull())
                    {
                        var vo = GetGoodNo(ref lcc);
                        if (vo.Item1)
                            LC_Customer.GoodNo = vo.Item2;
                    }
                }

                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@OrderID",OrderID)
                });
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "�޸�ʧ��������!");

                if (LC_Customer.State.ConvertData<GlobalBLL.OrderStateEnum>() == GlobalBLL.OrderStateEnum.�������)
                {

                    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_History), $"OrderID=@OrderID and State={GlobalBLL.OrderStateEnum.�ѷ���.EnumToInt()}", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",lcc.OrderID)
                    });
                    ids = db.Read(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);

                    if (!ids.ReadIsOk())
                        return new Tuple<bool, string>(false, "�������ݲ���Ϊ��!");

                    var fastordervo = ids.GetVOList<Model.Model.LC_History>()[0];

                    //���һ����������
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_Payment()
                    {
                        CreateTime = DateTime.Now,
                        LastOperationTime = DateTime.Now,
                        LastState = 1,
                        LocationLogisticsUID = lcc.logisticsID,
                        StartLogisticsUID = fastordervo.logisticsID,
                        OrderNumber = lcc.OrderID,
                        PaymentAllAmount = lcc.Freight + lcc.GReceivables + lcc.OtherExpenses,
                        LocationLogisticsIndex = GetLogisticsIndex(lcc.logisticsID).index
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "������������ʧ��!");

                    //����������ʷ����
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_Payment_History()
                    {
                        CreateTime = DateTime.Now,
                        LastOperationTime = DateTime.Now,
                        LocationLogisticsUID = lcc.beginUID,
                        StartLogisticsUID = lcc.logisticsID,
                        OrderNumber = lcc.OrderID,
                        PaymentAllAmount = lcc.Freight + lcc.GReceivables + lcc.OtherExpenses,
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "��ӻ�����ʷʧ��!");

                }

                var addh = AddToHistory(new string[] { OrderID }.ToList(), db);
                if (!addh.Item1)
                    return new Tuple<bool, string>(false, addh.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }
        /// <summary>
        /// װ�����б��ѯ
        /// </summary>
        /// <param name="Initially"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCmdList(string UID, int sta, int end)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=2 and logisticsID='" + UID + "' and begins=" + sta + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// װ�������ID����
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdatePC(Model.Model.LC_Customer LC_Customer, string OrderID)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID in (" + OrderID + ")");
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "�޸�ʧ��������!");

                var ath = AddToHistory(OrderID, db);
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// �ӳ�����ѯ�б�
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="AreaID">��ǰ�������ڵ���ID</param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable> GetMCList(string UID, int AreaID)
        {
            sql = new SuperDataBase.Vo.SqlVO("select finish,SUM(Freight) as 'Freight',VehicleID from LC_Customer where State=3 group by finish,VehicleID;");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(false, ids.errormsg, null, null);
            var mydt = ids.dt;

            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=3 and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@finish",AreaID)
                });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(false, ids.errormsg, null, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>(), mydt);
            return new Tuple<bool, string, List<Model.Model.LC_Customer>, DataTable>(true, "û���κ�����!", new List<Model.Model.LC_Customer>(), null);
        }
        /// <summary>
        /// ������ʷ�б�
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGList(string Phone, string SHPhone)
        {
            //�����ѯ
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            if (SHPhone != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + Phone + "' and SHPhone='" + SHPhone + "'");
                ids = db.Read(sql);
            }
            else if (SHPhone == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + Phone + "'",new System.Data.SqlClient.SqlParameter[] {
                }, "DdTime desc");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// ����׷��-�ջ�
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDGSHList(string Phone, string FHPhone)
        {
            //�����ѯ
            //Type[] tlist = new Type[] {
            //    typeof(Model.Model.LC_User),
            //    typeof(Model.Model.LC_Customer)
            //};
            //sql = makesql.MakeSelectArrSql(tlist, "{0}.Phone={1}.FHPhone and {0}.ZType=3");
            if (FHPhone != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and FHPhone='" + FHPhone + "'");
                ids = db.Read(sql);
            }
            else if (FHPhone == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and State!=10", new System.Data.SqlClient.SqlParameter[] {
                }, "DdTime desc");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// ����ǩ��-�����б�
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetSGList(string Phone, string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "SHPhone='" + Phone + "' and OrderID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());

        }

        /// <summary>
        /// ����ǩ��
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetQSList(string Phone)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(State=4 or State=8) and SHPhone='" + Phone + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());

        }
        /// <summary>
        /// ��ѯ-ID
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetGRList(string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@OrderID",OID),
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �ӳ�
        /// </summary>
        /// <param name="CH"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetGDList(int CH, int MDD)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "VehicleID=@VehicleID and State=@State and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@VehicleID",CH),
                new System.Data.SqlClient.SqlParameter("@State","3"),
                new System.Data.SqlClient.SqlParameter("@finish",MDD)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �Ż�-�ͻ������Ϣ
        /// </summary>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetFHandZZList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(State=5 Or State=7) and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        ///�Ż�-��ת�����б�
        /// </summary>
        /// <returns></returns>
        //public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetZZList(string UID)
        //{
        //    sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=7 and logisticsID='" + UID+"'");
        //    ids = db.Read(sql);
        //    if (!ids.flag)
        //        return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
        //    if (ids.ReadIsOk())
        //        return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
        //    return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        //}
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetOrderList(string FSPhone, string OrderNo)
        {
            if (OrderNo != null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "(FHPhone='" + FSPhone + "' Or SHPhone='" + FSPhone + "') and OrderID='" + OrderNo + "'");
                ids = db.Read(sql);
            }
            else if (OrderNo == null)
            {
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "FHPhone='" + FSPhone + "' Or SHPhone='" + FSPhone + "'");
                ids = db.Read(sql);
            }
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetZCSuccessList(int VehicleNo)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "VehicleID='" + VehicleNo + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �Ż�-�ͻ������Ϣ-�Ż�����
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetFHEditList(string UID, string logisticsID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=5 and logisticsID='" + logisticsID + "' and OrderID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �Ż�-�ͻ������Ϣ-δ�Ż����
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetWFHEditList(string UID, string logisticsID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=8 and logisticsID='" + logisticsID + "' and OrderID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �Ż�-�̵��б�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetInventoryList(string OID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=4 and logisticsID='" + OID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDFHList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "logisticsID='" + UID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// �̵�ɹ�
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public static Tuple<bool, string> UpdateIty(Model.Model.LC_Customer LC_Customer, string OrderID)
        {
            var box = db.CreateTranSandbox((db) =>
            {
                sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID in (" + OrderID + ")");
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "�޸�ʧ��������!");

                var ath = AddToHistory(OrderID, db);
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);
                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            return box;
        }

        /// <summary>
        /// �ջ�-��ʷ��¼
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetHistoyList(string UID)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "State=2 and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// װ��-�Ḷ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Gettifu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// װ��-�ָ�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getxianfu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// װ��-�۸�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) Getkoufu(string OID, int start, int end)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and logisticsID='" + OID + "' and State=2 and begins=" + start + " and finish=" + end + "");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// �ӳ�-�Ḷ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GettifuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// �ӳ�-�ָ�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetxianfuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// �ӳ�-�۸�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetkoufuMeetCar(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and finishUID='" + OID + "' and State=3");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }

        /// <summary>
        /// δ�Ż����-�Ḷ
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GettifuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=1 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// δ�Ż����-�ָ�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetxianfuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=2 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// δ�Ż����-�۸�
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetkoufuDHG(string OID)
        {
            sql = makesql.MakeSelectFieldSql(typeof(Model.Model.LC_Customer), new string[] { "sum(Freight)" }, "freightMode=3 and finishUID='" + OID + "' and State=8");
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }

        /// <summary>
        /// ��ȡ�ջ���һ����ʱ��
        /// </summary>
        /// <param name="OID"></param>
        /// <returns></returns>
        public static (bool, string, decimal) GetSHFristTime(string OID, int begins, int finish)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), $"logisticsID=@logisticsID and begins=@begins and finish=@finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@begins",begins),
                new System.Data.SqlClient.SqlParameter("@finish",finish),
                new System.Data.SqlClient.SqlParameter("@logisticsID",OID)
            }, "ConsigneeTime asc", 1);
            ids = db.Read(sql);
            if (!ids.flag)
                return (false, ids.errormsg, 0);
            if (ids.ReadIsOk())
                return (true, string.Empty, ids.GetFristData<decimal>(0));
            return (true, "û���κ�����!", 0);
        }
        /// <summary>
        /// ������ѯ��·��
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetCityOrderList(string UID, string start, string end)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "logisticsID=@logisticsID and beginUID=@beginUID and finishUID=@finishUID", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@logisticsID",UID),
                new System.Data.SqlClient.SqlParameter("@beginUID",start),
                new System.Data.SqlClient.SqlParameter("@finishUID",end)
            });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// ������ѯ������
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public static Tuple<bool, string, List<Model.Model.LC_Customer>> GetDateOrderList(string UID, string StartTime, string EndTime)
        {
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "ConsigneeTime between '" + StartTime + "' and '" + EndTime + "' and logisticsID='" + UID + "'");
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(false, ids.errormsg, null);
            if (ids.ReadIsOk())
                return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, string.Empty, ids.GetVOList<Model.Model.LC_Customer>());
            return new Tuple<bool, string, List<Model.Model.LC_Customer>>(true, "û���κ�����!", new List<Model.Model.LC_Customer>());
        }
        /// <summary>
        /// New:�ӳ��б�
        /// </summary>
        /// <param name="myuservo"></param>
        /// <returns></returns>
        public static (bool, string, object) GetMettCarList(UserLoginVO myuservo)
        {
            new SqlVO(@"select Initially,finish,Count(Freight) as [Count],SUM(Freight) as Freight,SUM(GReceivables) as GReceivables,VehicleID,Sum(largeCar) as largeCar,sum(Number) as number,DriverID,TruckTime from LC_Customer where State=3 and finish=" + myuservo.AreaID + " group by Initially,finish,VehicleID,DriverID,TruckTime").Bind(out SqlVO sql);
            db.Read(sql).Bind(out IDataState ids);
            if (!ids.flag)
                return (false, ids.errormsg, null);
            if (!ids.ReadIsOk())
                return (true, "û���κ�����!", new object[] { });
            return (true, string.Empty, new
            {
                StartSheng = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).sheng,//��ʼ-ʡz
                StartShi = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).shi,//��ʼ-��
                StartQu = DALBase.GetAllAddressNames(ids.dt.Rows[0]["Initially"].ConvertData<int>()).qu,//��ʼ-��
                EndSheng = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).sheng,//����-ʡ
                EndShi = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).shi,//����-��
                EndQu = DALBase.GetAllAddressNames(ids.dt.Rows[0]["finish"].ConvertData<int>()).qu,//����-��
                DrivePhone = DALBase.GetDriverPhone(ids.dt.Rows[0]["DriverID"].ConvertData<int>()).Item2.Phone, //˾���绰
                VehicleNo = DALBase.GetCarFromID(ids.dt.Rows[0]["VehicleID"].ConvertData<int>()).Item2.VehicleNo, //���ƺ�
                Count = ids.dt.Rows[0]["Count"],
                GReceivables = ids.dt.Rows[0]["GReceivables"],
                largeCar = ids.dt.Rows[0]["largeCar"],
                number = ids.dt.Rows[0]["number"],
                Freight = ids.dt.Rows[0]["Freight"],
                VehicleID = ids.dt.Rows[0]["VehicleID"],//��ֵ-����id
                Initially = ids.dt.Rows[0]["Initially"],//��ֵ-������
                finish = ids.dt.Rows[0]["finish"],//��ֵ-Ŀ�ĵ�
                TruckTime=ids.dt.Rows[0]["TruckTime"]
            });
        }
        public static Tuple<bool, string, DataTable> GetPretendCarCount(string UID)
        {
            sql = new SuperDataBase.Vo.SqlVO(@"select begins,finish from LC_Customer where State =@State and begins is not null and finish is not null and logisticsID =@logisticsID group by begins, finish", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@State","2"),
                new System.Data.SqlClient.SqlParameter("@logisticsID",UID)
            });
            ids = db.Read(sql);

            if (!ids.flag)
                return new Tuple<bool, string, DataTable>(false, ids.errormsg, null);
            return new Tuple<bool, string, DataTable>(true, string.Empty, ids.dt);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="LC_Customer"></param>
        /// <returns></returns>
        public static Tuple<bool, string> AutonomyBilling(Model.Model.LC_Customer LC_Customer, UserLoginVO myuservo, bool updateGoodNum = false)
        {
            Model.Model.LC_Customer lcc = null;
            string uid = Tools.NewGuid.GuidTo16String();
            var box = db.CreateTranSandbox<Tuple<bool, string>>((db) =>
            {
                //����Ƿ񴴽��������û�
                sql = makesql.MakeSelectSql(typeof(Model.Model.LC_User), "ZNumber=@ZNumber", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@ZNumber",myuservo.uid)
                },string.Empty,1);
                ids = db.Read(sql);
                if (ids.num == 0)
                {
                    sql = makesql.MakeInsertSQL(new Model.Model.LC_User()
                    {
                        UID = uid,
                        Phone = myuservo.phones,
                        ZNumber = myuservo.uid,
                        ProvincesID = myuservo.ProvincesID,
                        CityID = myuservo.CityID,
                        AreaID = myuservo.AreaID,
                        UserName = myuservo.LogisticsName,
                        ZType=1
                    });
                    ids = db.Exec(sql);
                    if (!ids.flag)
                        return new Tuple<bool, string>(false, ids.errormsg);
                    if (!ids.ExecOk())
                        return new Tuple<bool, string>(false, "���ʧ��������!");
                }
                else
                {
                    //��ȡ����󶨹�ϵ���˵�����
                    var _uservo = ids.GetVOList<Model.Model.LC_User>()[0];
                    uid = _uservo.UID;
                }

                LC_Customer.ConsignorID = uid;

                //��Ӷ���
                sql = makesql.MakeInsertSQL(LC_Customer);
                ids = db.Exec(sql);
                if (!ids.flag)
                    return new Tuple<bool, string>(false, ids.errormsg);
                if (!ids.ExecOk())
                    return new Tuple<bool, string>(false, "����ʧ��,������!");

                LC_Customer.State = GlobalBLL.OrderStateEnum.�ѷ���.EnumToInt();
                var ath =   AddToHistory(LC_Customer, db); //
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);

                LC_Customer.State = GlobalBLL.OrderStateEnum.�������ջ�.EnumToInt();
                ath =  AddToHistory(LC_Customer, db); //
                if (!ath.Item1)
                    return new Tuple<bool, string>(false, ath.Item2);

                db.Commit();
                return new Tuple<bool, string>(true, string.Empty);
            });
            //��ȡ�˶�������
            sql = makesql.MakeSelectSql(typeof(Model.Model.LC_Customer), "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                        new System.Data.SqlClient.SqlParameter("@OrderID",LC_Customer.OrderID)
                    });
            ids = db.Read(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ReadIsOk())
                return new Tuple<bool, string>(false, "û���ҵ��κζ������ݣ�");
            lcc = ids.GetVOList<Model.Model.LC_Customer>()[0];
            if (updateGoodNum)
            {

                lcc.finish = LC_Customer.finish;
                lcc.begins = LC_Customer.begins;
                if (lcc.GoodNo.StrIsNull())
                {
                    var vo = GetGoodNo(ref lcc);
                    if (vo.Item1)
                        LC_Customer.GoodNo = vo.Item2;
                }
            }
            sql = makesql.MakeUpdateSQL(LC_Customer, "OrderID=@OrderID", new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@OrderID",LC_Customer.OrderID)
                });
            ids = db.Exec(sql);
            if (!ids.flag)
                return new Tuple<bool, string>(false, ids.errormsg);
            if (!ids.ExecOk())
                return new Tuple<bool, string>(false, "�޸�ʧ��������!");
            return box;
        }
    }
}
