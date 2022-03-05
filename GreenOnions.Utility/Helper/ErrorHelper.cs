using System;
using System.IO;

namespace GreenOnions.Utility.Helper
{
    public static class ErrorHelper
    {
        public static void WriteErrorLog(Exception ex) => WriteErrorLogInner(ex);

        public static void WriteMessage(string msg)
        {
            try
            {
                File.AppendAllTextAsync("message.log", $"{msg}  打印时间:{DateTime.Now}\r\n");
            }
            catch
            {
            }
        }

        public static void WriteErrorLog(object exObj)
        {
            Exception ex = exObj as Exception;
            if (ex == null)
                WriteLogText(exObj?.ToString());
            else if (ex is AggregateException)
            {
                AggregateException aex = ex as AggregateException;
                foreach (var iex in aex.InnerExceptions)
                    WriteErrorLogInner(iex);
            }
            else
                WriteErrorLogInner(ex);
        }

        public static void WriteErrorLogWithUserMessage(string messageStart, object exObj, string messageEnd = "")
        {
            Exception ex = exObj as Exception;
            if (ex == null)
                WriteLogText($"{messageStart}。{exObj?.ToString()}。{messageEnd}");
            else if (ex is AggregateException)
            {
                WriteLogText(messageStart);
                   AggregateException aex = ex as AggregateException;
                foreach (var iex in aex.InnerExceptions)
                    WriteErrorLogInner(iex);
                WriteLogText(messageEnd);
            }
            else
            {
                WriteLogText(messageStart);
                WriteErrorLogInner(ex);
                WriteLogText(messageEnd);
            }
        }

        private static void WriteErrorLogInner(Exception ex) => WriteLogText($"发生异常:\r\n    错误信息:{ex.Message}\r\n    调用堆栈:{ex.StackTrace}\r\n    源:{ex.Source}\r\n    完整异常信息:{ex.ToString()}\r\n");

        private static void WriteLogText(string text)
        {
            try
            {
                File.AppendAllTextAsync("error.log", text + $"    异常发生时间:{DateTime.Now}\r\n\r\n");
            }
            catch
            {
            }
        }
    }
}
