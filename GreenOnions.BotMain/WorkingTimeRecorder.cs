using GreenOnions.Interface.Configs.Enums;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain
{
    public static class WorkingTimeRecorder
    {
        private static bool _isRecording = false;
        private static BotProtocol _connectedPlatform = 0;
        public static bool IsRecording => _isRecording;
        private static TimeOnly timeFrom;
        private static TimeOnly timeTo;

        public static bool DoWork { get; set; } = false;

        public static void StartRecord(BotProtocol connectedPlatform, Action<BotProtocol> ConnectMethod, Action DisconnectMethod)
        {
            _connectedPlatform = connectedPlatform;
            timeFrom = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute));
            timeTo = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute));

            if (timeFrom == timeTo)
                return;

            if (BotInfo.Config.WorkingTimeEnabled)
            {
                if (IsRecording)
                    return;
                _isRecording = true;
                Task.Run(() =>
                {
                    while (BotInfo.Config.WorkingTimeEnabled && DoWork)
                    {
                        if (timeFrom < timeTo)  //工作时间在当天内
                        {
                            if (BotInfo.IsLogin)
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute))
                                {
                                    LogHelper.WriteWarningLog("自动断开连接");
                                    DisconnectMethod();
                                }
                            }
                            else
                            {
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute))
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
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute))
                                {
                                    LogHelper.WriteWarningLog("自动断开连接");
                                    DisconnectMethod();
                                }
                            }
                            else
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute))
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
            timeFrom = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.Config.WorkingTimeFromHour).AddMinutes(BotInfo.Config.WorkingTimeFromMinute));
            timeTo = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.Config.WorkingTimeToHour).AddMinutes(BotInfo.Config.WorkingTimeToMinute));
        }
    }
}
