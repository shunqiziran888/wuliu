﻿using SuperDataBase.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperDataBase;
using System.Diagnostics;

namespace Logistics.LC
{
    public partial class LC_Line : PageLoginBase
    {
        public List<Model.Model.LC_Line_Other> list=new List<Model.Model.LC_Line_Other>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var myuservo = GetMyLoginUserVO();
            var vo = DAL.DAL.LC_Line.GetLineList(-1, myuservo.uid);
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