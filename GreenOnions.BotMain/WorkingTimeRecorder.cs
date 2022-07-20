using GreenOnions.Utility;

namespace GreenOnions.BotMain
{
    public static class WorkingTimeRecorder
    {
        private static bool _isRecording = false;
        private static int _connectedPlatform = -1;
        public static bool IsRecording => _isRecording;
        private static TimeOnly timeFrom;
        private static TimeOnly timeTo;

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
                    while (BotInfo.WorkingTimeEnabled)
                    {
                        if (timeFrom < timeTo)  //工作时间在当天内
                        {
                            if (BotInfo.IsLogin)
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute))
                                    DisconnectMethod();
                            }
                            else
                            {
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute))
                                    ConnectMethod(_connectedPlatform);
                            }
                        }
                        else  //工作时间跨过0点
                        {
                            if (BotInfo.IsLogin)
                            {
                                if (DateTime.Now > DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute)
                                && DateTime.Now < DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute))
                                    DisconnectMethod();
                            }
                            else
                            {
                                if (DateTime.Now >= DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute))
                                    ConnectMethod(_connectedPlatform);
                            }
                        }

                        Task.Delay(1000 * 10).Wait();
                    }
                    _isRecording = false;
                });
            }
        }

        public  static void UpdateWorkingTime()
        {
            timeFrom = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeFromHour).AddMinutes(BotInfo.WorkingTimeFromMinute));
            timeTo = TimeOnly.FromDateTime(DateTime.Today.AddHours(BotInfo.WorkingTimeToHour).AddMinutes(BotInfo.WorkingTimeToMinute));
        }
    }
}
