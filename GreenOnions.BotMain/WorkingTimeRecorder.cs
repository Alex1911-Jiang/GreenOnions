using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain
{
    public static class WorkingTimeRecorder
    {
        private static BotPlatform _connectedPlatform = BotPlatform.Mirai_Api_Http;
        private static TimeSpan timeFrom;
        private static TimeSpan timeTo;

        public static async void StartRecord(BotPlatform connectedPlatform, Action<BotPlatform> ConnectMethod, Action DisconnectMethod)
        {
            await Task.Delay(3000);

            _connectedPlatform = connectedPlatform;
            timeFrom = DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute).TimeOfDay;
            timeTo = DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute).TimeOfDay;

            if (timeFrom == timeTo)
                return;

            //bool crossMidnight = timeTo < timeFrom;

            if (BotInfo.Config.WorkingTimeEnabled)
            {
                while (BotInfo.Config.WorkingTimeEnabled)
                {
                    if (!BotInfo.IsLogin)
                    {
                        if (DateTime.Now.TimeOfDay >= timeFrom && DateTime.Now.TimeOfDay <= timeTo)
                        {
                            LogHelper.WriteWarningLog($"自动重新连接到平台{_connectedPlatform}");
                            ConnectMethod(_connectedPlatform);
                        }
                    }
                    else
                    {
                        if (DateTime.Now.TimeOfDay > timeTo || DateTime.Now.TimeOfDay < timeFrom)
                        {
                            LogHelper.WriteWarningLog("自动断开连接");
                            DisconnectMethod();
                        }
                    }
                    await Task.Delay(1000);
                }
            }
        }

        public static void UpdateWorkingTime()
        {
            timeFrom = DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute).TimeOfDay;
            timeTo = DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute).TimeOfDay;
        }
    }
}
