using NLog;
using NLog.Config;
using NLog.Targets;

namespace GreenOnions.NT.Base
{
    public static class LogHelper
    {
        private static Logger _logger;
        static LogHelper()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ColoredConsoleTarget() { Layout = "${longdate}    ${message}" };
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget() { FileName = "${basedir}/log/${shortdate}_${level}.log", Layout = "${longdate}    ${message}\r\n${exception}" };
            config.AddTarget("file", fileTarget);

            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

            LogManager.Configuration = config;

            _logger = LogManager.GetLogger("LogHelper");
        }

        public static void LogDebug(string msg)
        {
            _logger.Debug(msg);
        }

        public static void LogMessage(string msg)
        {
            _logger.Info(msg);
        }

        public static void LogWarning(string msg)
        {
            _logger.Warn(msg);
        }

        public static void LogError(string msg)
        {
            _logger.Error(msg);
        }

        public static void LogException(Exception ex, string msg)
        {
            _logger.Error(ex, $"{msg}");
        }
    }
}
