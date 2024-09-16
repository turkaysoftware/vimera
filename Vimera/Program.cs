﻿using System;
using System.Windows.Forms;
//
using static Vimera.TSModules;

namespace Vimera{
    internal static class Program{
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main(){
            if (Environment.OSVersion.Version.Major >= 6){ SetProcessDPIAware(); }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Vimera());
        }
    }
}