using Logistics.ApiCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics
{
    public class WebCommandRun
    {
        public SuperCommand.CommandRun<WebCommandVOBase> _command = null;
        public static WebCommandRun GetInstance { get; } = new WebCommandRun();
    }
}