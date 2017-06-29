using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics
{
    public class CommandRun
    {
        public SuperCommand.CommandRun<LogCommandVO> _command = null;
        public static CommandRun GetInstance { get; } = new CommandRun();
    }
}