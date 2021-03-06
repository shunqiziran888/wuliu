﻿using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.DschargeGood
{
    public partial class LC_DeliveryEdit : PageLoginBase
    {
        public List<Model.Model.LC_Customer> list = new List<Model.Model.LC_Customer>();
        public List<Model.Model.LC_User> list2 = new List<Model.Model.LC_User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //放货-送货
            string OID = GetValue("OID");
            var vo = DAL.DAL.LC_Customer.GetGRList(OID);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;

            //查询员工  
            var myuservo = GetMyLoginUserVO();
            var vo1 = DAL.DAL.LC_User.GetStaffList(myuservo.uid);
            if (!vo1.Item1)
            {
                //有错误
                Debug.Print(vo1.Item2);
                return;
            }
            list2 = vo1.Item3;
        }
    }
}