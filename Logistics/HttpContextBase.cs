using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics
{
    public class HttpContextBase : SuperCommand.HttpContextBase
    {
        public HttpContextBase(HttpContext _hc) : base(_hc)
        {
        }
        public object GetMyLoginUserVO()
        {
            return null;
        }
    }
}