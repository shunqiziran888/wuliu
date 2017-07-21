using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomExtensions;
namespace Logistics.doc
{
    public partial class doc : System.Web.UI.Page
    {
        public DocVO dv { get; set; }
        public string Test = string.Empty;


        public class DocVO
        {
            public int state { get; set; }
            public string key { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string Key { get; set; }
            public Value[] Value { get; set; }
        }

        public class Value
        {
            public string fullName { get; set; }
            public string docKey { get; set; }
            public string docName { get; set; }
            public Inputdoclist[] inputDocList { get; set; }
        }

        public class Inputdoclist
        {
            public string key { get; set; }
            public string description { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            //获取数据
            var html = Tools.GetHtml.GetHtmlFromUrl($"http://{ Request.Url.Authority}/api.ashx?action=GetSysApiDoc", string.Empty, null, null);
            if (html.Item1)
            {
                dv = html.Item2.JsonToVO<DocVO>();
            }
        }
    }
}