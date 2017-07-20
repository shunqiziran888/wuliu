using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.ApiCommand
{
    public class WebCommandVOBase : SuperCommand.CommandVO
    {
        public GlobalBLL.HttpContextBase web;
    }
}