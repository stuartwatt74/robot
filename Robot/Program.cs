using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://localhost:40807/";

            string baseAddress = ConfigurationManager.AppSettings["baseUrl"];

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine(baseAddress);
                Console.WriteLine("Press a key to quit.");
                Console.ReadKey();
            }
        }
    }
}
