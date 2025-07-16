using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Abstraction
{
    public interface IApplicationSettings
    {
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }


        void LoadApplicationSettings();
    }
}
