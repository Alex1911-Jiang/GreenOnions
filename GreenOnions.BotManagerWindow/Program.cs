using System;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
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
            Application.ThreadException += (sender, threadException) => Utility.Helper.LogHelper.WriteErrorLogWithUserMessage($"ȫ���쳣, �쳣����Ϊ:{sender.GetType()}", threadException.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, unhandledException) => Utility.Helper.LogHelper.WriteErrorLogWithUserMessage($"ȫ���쳣, �쳣����Ϊ:{sender.GetType()}", unhandledException.ExceptionObject);
            Application.Run(new FrmMain());
        }
    }
}
