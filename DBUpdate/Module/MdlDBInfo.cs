using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUpdate.Module
{
    public class MdlDBInfo
    {
        public string Id { get; set; }

        public string ConnName { get; set; }

       
        public string Service { get; set; }
        public string Uid { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }

        public string DBName { get; set; }
        public string SqlPath { get; set; }

    }
}
