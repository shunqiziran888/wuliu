﻿using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC.Business.PretendCar
{
    public partial class LC_IndexPC : PageLoginBase
    {
        public List<Model.Model.LC_Line> list = new List<Model.Model.LC_Line>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            string uid = myuservo.uid;
            var vo = DAL.DAL.LC_Line.GetXLList(uid);
            if (!vo.Item1)
            {
                //有错误
                Debug.Print(vo.Item2);
                return;
            }
            list = vo.Item3;
        }
    }
}