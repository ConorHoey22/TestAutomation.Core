using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework.Internal;
using Reqnroll;
using Reqnroll.BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Container;

namespace TestAutomation.Core.Runner
{
    [Binding]
    public class BBD_Runner
    {


        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            //Can be used to set up the environment before any tests are run.
            // Config file loading

            //Setting environment variables

            //Logging configuration

            //Launching external test services(like a local server or database)
        }
    }
}
