using CustomExtensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Logistics
{
    public partial class GetQR : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = GetValue("url");
            string logo = GetValue("logo");
            if (url.StrIsNull())
            {
                Tools.SaveLog.AddLog("URL地址不能为空", "二维码生成");
            }
            else if(logo.StrIsNull())
            {
                Tools.SaveLog.AddLog("LOGO图地址不能为空", "二维码生成");
            }
            else
            {
                Random seed = new Random();
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(logo + "?r=" + seed.NextDouble());
                using (System.Net.WebResponse webres = webreq.GetResponse())
                {
                    using (Stream stream = webres.GetResponseStream())
                    {
                        Bitmap logo_bm = new Bitmap(stream);
                        var vo = Tools.MakeImage.GetQRCode(url, logo_bm);
                        if (vo.Item1)
                        {
                            Request.ContentType = "image/png";
                            vo.Item3.Save(Response.OutputStream, ImageFormat.Png);
                            vo.Item3.Dispose();
                        }
                        else
                        {
                            Tools.SaveLog.AddLog("生成二维码错误", "二维码生成");
                        }
                    }
                }
            }
            Response.End();
        }
    }
}