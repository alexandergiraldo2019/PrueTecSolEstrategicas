using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                Service1 serv = new Service1();
                serv.TestStartupAndStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                        new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
