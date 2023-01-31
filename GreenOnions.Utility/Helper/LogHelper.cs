using System;
using System.Threading;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace GreenOnions.Utility.Helper
{
    public static class LogHelper
    {
        private static Logger _logger;
        static LogHelper()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget() { Layout = "${message}    ${longdate}" };
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget() { FileName = "${basedir}/${level}.log", Layout = "${message}    ${longdate}" };
            config.AddTarget("file", fileTarget);


            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            LogManager.Configuration = config;

            _logger = LogManager.GetLogger("LogHelper");
        }

        public static void WriteInfoLog(string msg)
        {
            if (BotInfo.Config.LogLevel <= 0)
            {
                msg = $"{msg}    线程ID:{Thread.GetCurrentProcessorId()}    ";
                _logger.Info(msg);
            }
        }

        public static void WriteWarningLog(string msg)
        {
            if (BotInfo.Config.LogLevel <= 1)
            {
                msg = $"{msg}    线程ID:{Thread.GetCurrentProcessorId()}    ";
                _logger.Warn(msg);
            }
        }

        public static void WriteErrorLog(string messageStart, object? exObj, string messageEnd = "")
        {
            if (BotInfo.Config.LogLevel <= 2)
            {
                Exception ex = exObj as Exception;
                if (ex is null)
                    AppendErrorText($"{messageStart}    {exObj?.ToString()}    {messageEnd}");
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

        private static void WriteErrorLogInner(Exception ex) => AppendErrorText($"发生异常:\r\n    错误信息:{ex.Message}\r\n    完整异常信息:{ex}\r\n");

        private static void AppendErrorText(string msg)
        {
            msg = $"{msg}    线程ID:{Thread.GetCurrentProcessorId()}";
            _logger.Error(msg);
        }
    }
}
