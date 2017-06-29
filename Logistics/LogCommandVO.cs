using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics
{
    public class LogCommandVO : SuperCommand.CommandVO
    {
        public HttpContextBase web;
    }
}