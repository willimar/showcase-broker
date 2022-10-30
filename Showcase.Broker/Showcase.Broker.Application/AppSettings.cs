using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showcase.Broker.Application
{
    public class AppSettings
    {
        public Apis Apis { get; set; }
        public string SystemSource { get; set; }
    }

    public class Apis
    {
        public string Authenticate { get; internal set; }
    }
}
