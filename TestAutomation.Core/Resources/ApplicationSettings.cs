using DotNetEnv;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Core.Abstraction;

namespace TestAutomation.Core.Resources
{
    public class ApplicationSettings : IApplicationSettings
    {



        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public void LoadApplicationSettings()
        {

            // Load .env variables
            string envPath = Path.Combine(AppContext.BaseDirectory, "applicationSettings.env");

            if (!File.Exists(envPath))
            {
                Console.WriteLine($"Environment file not found at {envPath}. Please ensure it exists.");
                //Logging could be added here 

            }
            else
            {
                // Load the environment variables from the file 
                Env.Load(envPath);
                url = Environment.GetEnvironmentVariable("URL");
                username = Environment.GetEnvironmentVariable("USERNAME");
                password = Environment.GetEnvironmentVariable("PASSWORD");

   
            }
                

        }
    }
}
