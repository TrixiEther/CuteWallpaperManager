using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace CuteWallpaperManager
{

    public enum UAction
    {
        /// <summary>
        /// set the desktop background image
        /// </summary>
        SPI_SETDESKWALLPAPER = 0x0014,
        /// <summary>
        /// set the desktop background image
        /// </summary>
        SPI_GETDESKWALLPAPER = 0x0073,
    }

    public partial class WallpaperService : ServiceBase
    {
        string testPath1 = "C:/wallpapers/1.jpg";
        string testPath2 = "C:/wallpapers/2.jpg";

        bool useFirst = true;
        TimerCallback tm;
        Timer timer;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(UAction uAction, int uParam, StringBuilder lpvParam, int fuWinIni);

        public WallpaperService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            tm = new TimerCallback(ChangeWallpaper);
            timer = new Timer(tm, null, 0, 10000);
        }

        protected override void OnStop()
        {
        }

        private void ChangeWallpaper(object obj)
        {
            if ( useFirst )
            {
                StringBuilder s = new StringBuilder(testPath1);
                SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
                useFirst = false;
            } else
            {
                StringBuilder s = new StringBuilder(testPath2);
                SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
                useFirst = true;
            }
        }
    }
}
