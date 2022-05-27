using GreenOnions.Help;
using GreenOnions.Model;
using GreenOnions.Utility;
using Sora;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;
using Sora.Interfaces;
using Sora.Net.Config;
using Sora.Util;
using System.Text.RegularExpressions;
using YukariToolBox.LightLog;
using GreenOnions.Utility.Helper;
using Sora.Entities.Base;
using Sora.Entities.Info;

namespace GreenOnions.CqHttp
{
    public class Main
    {
        public static async Task Connect(long qqId, string ip, ushort port, string authKey, Action<bool, string> ConnectedEvent)
        {
            ////设置log等级
            //Log.LogConfiguration
            //   .EnableConsoleOutput()
            //   .SetLogLevel(LogLevel.Error);

            try
            {
                //实例化Sora服务
                ISoraService service = SoraServiceFactory.CreateService(new ClientConfig() { Host = ip, Port = port, AccessToken = authKey });
                service.Event.OnGroupMessage += MessageEvents.Event_OnGroupMessage;
                service.Event.OnPrivateMessage += MessageEvents.Event_OnPrivateMessage;

                //启动服务并捕捉错误
                await service.StartService().RunCatch(e => Log.Error("Sora Service", Log.ErrorLogBuilder(e)));

                service.Event.OnClientConnect += async (eventType, eventArgs) =>
                {
                    SoraApi api = service.GetApi(service.ServiceId);

                    BotInfo.QQId = api.GetLoginUserId();

                    List<FriendInfo> IFriendInfos = (await api.GetFriendList()).friendList;
                    string nickname = "未知";

                    var self = IFriendInfos.Where(q => q.UserId == qqId).FirstOrDefault();
                    if (self != null)
                        nickname = self.Nick;

                    ConnectedEvent?.Invoke(true, nickname);
                };

                BotMain.RssWorker.StartRssTask((msgs, targetId, groupId) =>
                {
                    SoraApi api = service.GetApi(service.ServiceId);

                    if (msgs != null && msgs.Count > 0)
                    {
                        if (msgs.First() is GreenOnionsForwardMessage forwardMessage)
                        {
                            _ = api.SendGroupForwardMsg(targetId, forwardMessage.ToCqHttpForwardMessage());
                        }
                        else
                        {
                            if (targetId != -1)
                                _ = api.SendGroupMessage(targetId, msgs.ToCqHttpMessages());
                            else if (groupId != -1)
                                _ = api.SendGroupMessage(groupId, msgs.ToCqHttpMessages());
                        }
                    }
                });


                while (true)
                {
                    BotInfo.IsLogin = true;
                    if (Console.ReadLine() == "exit")
                    {
                        BotInfo.IsLogin = false;
                        ConnectedEvent?.Invoke(false, "");
                        break;
                    }
                    Task.Delay(100).Wait();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
                ConnectedEvent(false, ex.Message);
            }
        }

        public static void UpdateRegexs() => BotMain.MessageHandler.UpdateRegexs();
    }
}