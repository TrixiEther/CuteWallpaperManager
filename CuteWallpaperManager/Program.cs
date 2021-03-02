using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CuteWallpaperManager
{

    static class Program
    {
        /// <summary>
        /// set the parameter of system
        /// </summary>
        /// <param name="uAction"></param>
        /// <param name="uParam"></param>
        /// <param name="lpvParam"></param>
        /// <param name="fuWinIni"></param>
        /// <example></example>
        /// <returns></returns>
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static void Main()
        {
#if DEBUG
            WallpaperService ws = new WallpaperService();
            ws.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WallpaperService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
