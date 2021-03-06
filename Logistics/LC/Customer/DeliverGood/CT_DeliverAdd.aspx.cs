﻿using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;
using CustomExtensions;
namespace Logistics.LC.Customer
{
    public partial class CT_DeliverAdd :PageLoginBase
    {
        public List<Dictionary<string,SuperDataBase.InterFace.I_ModelBase>> list = new List<Dictionary<string, I_ModelBase>>();
        public List<Model.Model.w_address_basic_data> shengList = new List<Model.Model.w_address_basic_data>();
        public List<Model.Model.LC_Line> list2 = new List<Model.Model.LC_Line>();
        public string shr;
        public string shrdh;
        public string mbd;
        public string uffs;
        public string wlid;
        public int CarryGood;
        public int ReceiptGood;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取地区省列表
            shengList = DAL.DAL.DALBase.GetNextAddressListFromId(1);
            shr = GetValue("shr");
            shrdh = GetValue("shrdh");
            mbd = GetValue("mbd");
            uffs = GetValue("uffs");
            wlid = GetValue("wlid");
            CarryGood = GetValue<int>("CarryGood");
            ReceiptGood = GetValue<int>("ReceiptGood");
            try
            {
                var Ident = GetValue("Ident");
                if(Ident!="1")
                {
                    var myuservo = GetMyLoginUserVO();
                    string UserName = myuservo.username;
                    string Phone = myuservo.phones;
                    int cfd = myuservo.AreaID;

                    var lcc = new Model.Model.LC_Customer()
                    {
                        OrderID = Tools.NewGuid.GuidToLongID().ToString(),//订单ID
                        Consignor = UserName,//发货人
                        ConsignorID = Tools.NewGuid.GuidTo16String(),//发货人ID
                        FHPhone = Phone,//发货人电话
                        Consignee = GetValue("Consignee"),//收货人名称
                        logisticsID = GetValue("logisticsID").StringToArray().GetIndexValue(0),//物流
                        SHPhone = GetValue("SHPhone"),//收货人电话
                        Destination = GetValue<int>("End"),//目的地
                        Initially = GetValue("logisticsID").StringToArray().GetIndexValue(3).ConvertData<int>(),//出发地
                        GoodName = GetValue("GoodName"),//货物名称
                        Number = GetValue<int>("Number"),//件数
                        GReceivables = GetValue<decimal>("GReceivables"),//代收款
                        freightMode = GetValue<int>("freightMode"),//付款方式
                        CarryGood = GetValue<int>("CarryGood"),//提货方式
                        ReceiptGood = GetValue<int>("ReceiptGood"),//收货方式
                        DdTime = DateTime.Now,//发货时间
                        OtherExpenses = GetValue<decimal>("OtherExpenses"),//其他费用
                        PickupCost = GetValue<decimal>("PickupCost"),
                        GivegoodCost=GetValue<decimal>("GivegoodCost"),
                        State = 1
                    };
                    //添加
                    Tuple<bool, string> vo = BLL.BLL.LC_Customer.Add(lcc);
                    if (vo.Item1)
                    {
                        Jump("/LC/Customer/DeliverGood/CT_Success.aspx?OID=" + lcc.OrderID+ "&DdTime="+lcc.DdTime+ "&GoodName=" +lcc.GoodName+ "&Number=" +lcc.Number+ "&freightMode=" +lcc.freightMode+ "&Consignee=" +lcc.Consignee+ "&Consignor=" +lcc.Consignor+ "&Destination=" +lcc.Destination+ "&OtherExpenses=" +lcc.OtherExpenses+ "&GReceivables=" +lcc.GReceivables+ "&CarryGood=" +lcc.CarryGood+ "&ReceiptGood=" +lcc.ReceiptGood+ "&SHPhone=" +lcc.SHPhone+ "&FHPhone=" +lcc.FHPhone+ "&OtherExpenses=" + lcc.OtherExpenses);
                    }
                    else if (lcc.logisticsID == "0")
                    {
                        ReturnPager("请选择物流！");
                    }
                    else
                    {
                        ReturnPager("所有内容均不能为空！");
                    }
                }
                var myuservo1 = GetMyLoginUserVO();
                int CityID = myuservo1.CityID;
                string logID = GetValue("logisticsID").StringToArray().GetIndexValue(0);
                //物流
                var vo1 = DAL.DAL.LC_User.GetLCFHADDList(myuservo1);
                if (!vo1.Item1)
                {
                    //有错误
                    Debug.Print(vo1.Item2);
                    return;
                }
                list = vo1.Item3.Distinct(new DistinctObj()).ToList();
            }
            catch (Exception)
            {
                Alert("添加失败请重试");
            }
        }

        class DistinctObj : IEqualityComparer<Dictionary<string, SuperDataBase.InterFace.I_ModelBase>>
        {
            public bool Equals(Dictionary<string, I_ModelBase> x, Dictionary<string, I_ModelBase> y)
            {
                var x_vo = x.GetDicVO<Model.Model.LC_Line>();
                var y_vo = y.GetDicVO<Model.Model.LC_Line>();
                if (x_vo.UID == y_vo.UID)
                    return true;
                return false;
            }

            public int GetHashCode(Dictionary<string, I_ModelBase> obj)
            {
                return 0;
            }
        }
    }
}