using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;
using CustomExtensions;

namespace Logistics.LC.OwnBilling
{
    public partial class LC_Success : PageLoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            var lcc = new Model.Model.LC_Customer()
            {
                OrderID = Tools.NewGuid.GuidToLongID().ToString(),//订单ID
                Consignor = GetValue("Consignor"),//发货人
                FHPhone = GetValue("FHPhone"),//发货人电话
                Consignee = GetValue("Consignee"),//收货人名称
                logisticsID = myuservo.uid,//物流
                SHPhone = GetValue("SHPhone"),//收货人电话
                Destination = GetValue<int>("End"),//目的地
                Initially = myuservo.AreaID,//出发地
                begins = myuservo.AreaID,//路线开始地
                finish=GetValue<int>("finish"),//路线结束地
                beginUID=myuservo.uid,//路线绑定ID
                finishUID=GetValue("BindLogisticsUid"),
                GoodName = GetValue("GoodName"),//货物名称
                Number = GetValue<int>("Number"),//件数
                Freight = GetValue<decimal>("Freight"),//运费
                OtherExpenses = GetValue<decimal>("OtherExpenses"),//其他费用
                GReceivables = GetValue<decimal>("GReceivables"),//代收款 
                freightMode = GetValue<int>("freightMode"),//付款方式
                CarryGood = GetValue<int>("CarryGood"),//提货方式
                ReceiptGood = GetValue<int>("ReceiptGood"),//收货方式
                DdTime = DateTime.Now,//发货时间
                ConsigneeTime = DateTime.Now,//收货时间
                State = 2,
                
            };
            //添加
            Tuple<bool, string> vo = DAL.DAL.LC_Customer.AutonomyBilling(lcc,myuservo,true);
            if (vo.Item1)
            {
                //Jump("/LC/MenuBar/LC_BusinessIndex.aspx");
            }
        }
    }
}