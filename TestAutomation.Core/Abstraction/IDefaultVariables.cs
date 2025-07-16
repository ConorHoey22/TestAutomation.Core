using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Abstraction
{
    public interface IDefaultVariables
    {
        string getLog { get; }
        string getExtentReport { get; }

        string getFrameworkSettings { get; }
        string getApplicationSettings { get; }
        string gridhuburl { get; }
        string dataSetLocation { get; }
    }
}
