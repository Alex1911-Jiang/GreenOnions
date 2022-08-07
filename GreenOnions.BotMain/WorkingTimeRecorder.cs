using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain
{
    public static class WorkingTimeRecorder
    {
        private static bool _isRecording = false;
        private static int _connectedPlatform = -1;
        public static bool IsRecording => _isRecording;
        private static TimeOnly timeFrom;
        private static TimeOnly timeTo;

        public static bool DoWork { get; set; } = false;

        public static void StartRecord(int connectedPlatform, Action<int> ConnectMethod, Action DisconnectMethod)
        {
            _connectedPlatform = connectedPlatform;
            timeFrom = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute));
            timeTo = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute));

            if (timeFrom == timeTo)
                return;

            if (BotInfo.WorkingTimeEnabled)
            {
                if (IsRecording)
                    return;
                _isRecording = true;
                Task.Run(() =>
                {
                    while (BotInfo.WorkingTimeEnabled && DoWork)
                    {
                        if (timeFrom < timeTo)  //工作时间在当天内
                        {
                            if (BotInfo.IsLogin)
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute))
                                {
                                    LogHelper.WriteWarningLog("自动断开连接");
                                    DisconnectMethod();
                                }
                            }
                            else
                            {
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute))
                                {
                                    LogHelper.WriteWarningLog($"自动重新连接到平台{_connectedPlatform}");
                                    ConnectMethod(_connectedPlatform);
                                }
                            }
                        }
                        else  //工作时间跨过0点
                        {
                            if (BotInfo.IsLogin)
                            {
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute))
                                {
                                    LogHelper.WriteWarningLog("自动断开连接");
                                    DisconnectMethod();
                                }
                            }
                            else
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute))
                                {
                                    LogHelper.WriteWarningLog($"自动重新连接到平台{_connectedPlatform}");
                                    ConnectMethod(_connectedPlatform);
                                }
                            }
                        }

                        Task.Delay(1000 * 10).Wait();
                    }
                    _isRecording = false;
                });
            }
        }

        public static void UpdateWorkingTime()
        {
            timeFrom = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute));
            timeTo = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute));
        }
    }
}
