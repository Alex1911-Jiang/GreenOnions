using System;
using System.IO;
using System.Threading;

namespace GreenOnions.Utility.Helper
{
    public static class LogHelper
    {
        public static void WriteInfoLog(string msg)
        {
            if (BotInfo.LogLevel <= 0)
            {
                msg = $"{msg}    时间:{DateTime.Now}    线程ID:{Thread.GetCurrentProcessorId()}\r\n";
                Console.Write(msg);
                try
                {
                    File.AppendAllText("message.log", msg);
                }
                catch
                {
                }
            }
        }

        public static void WriteWarningLog(string msg)
        {
            if (BotInfo.LogLevel <= 1)
            {
                msg = $"{msg}    警告时间:{DateTime.Now}    线程ID:{Thread.GetCurrentProcessorId()}\r\n";
                Console.Write(msg);
                try
                {
                    File.AppendAllText("warning.log", msg);
                }
                catch
                {
                }
            }
        }

        public static void WriteErrorLog(Exception ex)
        {
            if (BotInfo.LogLevel <= 2)
            {
                WriteErrorLogInner(ex);
            }
        }

        public static void WriteErrorLog(object exObj)
        {
            if (BotInfo.LogLevel <= 2)
            {
                Exception ex = exObj as Exception;
                if (ex == null)
                    AppendErrorText(exObj?.ToString());
                else if (ex is AggregateException)
                {
                    AggregateException aex = ex as AggregateException;
                    foreach (var iex in aex.InnerExceptions)
                        WriteErrorLogInner(iex);
                }
                else
                    WriteErrorLogInner(ex);
            }
        }

        public static void WriteErrorLogWithUserMessage(string messageStart, object exObj, string messageEnd = "")
        {
            if (BotInfo.LogLevel <= 2)
            {
                Exception ex = exObj as Exception;
                if (ex == null)
                    AppendErrorText($"{messageStart}。{exObj?.ToString()}。{messageEnd}");
                else if (ex is AggregateException)
                {
                    AppendErrorText(messageStart);
                    AggregateException aex = ex as AggregateException;
                    foreach (var iex in aex.InnerExceptions)
                        WriteErrorLogInner(iex);
                    AppendErrorText(messageEnd);
                }
                else
                {
                    AppendErrorText(messageStart);
                    WriteErrorLogInner(ex);
                    AppendErrorText(messageEnd);
                }
            }
        }

        private static void WriteErrorLogInner(Exception ex) => AppendErrorText($"发生异常:\r\n    错误信息:{ex.Message}\r\n    调用堆栈:{ex.StackTrace}\r\n    源:{ex.Source}\r\n    完整异常信息:{ex}\r\n");

        private static void AppendErrorText(string msg)
        {
            msg = msg + $"\r\n    异常发生时间:{DateTime.Now}    线程ID:{Thread.GetCurrentProcessorId()}\r\n\r\n";
            Console.Write(msg);
            try
            {
                File.AppendAllText("error.log", msg);
            }
            catch
            {
            }
        }
    }
}
