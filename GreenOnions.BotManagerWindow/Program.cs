using System;
using System.Windows.Forms;

namespace GreenOnions.BotMainManagerWindow
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (_, threadException) => Utility.Helper.ErrorHelper.WriteErrorLog(threadException.Exception);
            AppDomain.CurrentDomain.UnhandledException += (_, unhandledException) => Utility.Helper.ErrorHelper.WriteErrorLog(unhandledException.ExceptionObject);
            Application.Run(new FrmMain());
        }
    }
}
