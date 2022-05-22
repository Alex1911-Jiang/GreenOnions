using GreenOnions.Model;
using GreenOnions.ForgeMessage;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Sora.Entities;
using Sora.Entities.Segment;
using Sora.Entities.Segment.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GreenOnions.Help;
using Sora.Enumeration.ApiType;

namespace GreenOnions.BotMain.CqHttp
{
    public static class MessageHandler
    {
        private static Regex regexSearchOn;
        private static Regex regexSearchOff;
        private static Regex regexTranslateToChinese;
        private static Regex regexTranslateTo;
        private static Regex regexTranslateFromTo;
        private static Regex regexHPicture;
        private static Regex regexBeautyPicture;
        private static Regex regexForgeMessage;
        private static Regex regexDownloadPixivOriginPicture;
        private static Regex regexSelectPhone;
        private static Regex regexHelp;
        private static Regex regexTicTacToeStart;
        private static Regex regexTicTacToeStop;

        static MessageHandler()
        {
            regexDownloadPixivOriginPicture = new Regex($"{BotInfo.BotName}下[載载][Pp]([Ii][Xx][Ii][Vv]|站)原[圖图][:：]");
            regexHelp = new Regex($"{BotInfo.BotName}帮助");
            regexSelectPhone = new Regex($"{BotInfo.BotName}查询手机号[:：]");
            UpdateRegexs();
        }

        public static void UpdateRegexs()
        {
            regexSearchOn = new Regex(BotInfo.SearchModeOnCmd.ReplaceGreenOnionsTags());
            regexSearchOff = new Regex(BotInfo.SearchModeOffCmd.ReplaceGreenOnionsTags());
            regexTranslateToChinese = new Regex(BotInfo.TranslateToChineseCMD.ReplaceGreenOnionsTags());
            regexTranslateTo = new Regex(BotInfo.TranslateToCMD.ReplaceGreenOnionsTags());
            regexTranslateFromTo = new Regex(BotInfo.TranslateFromToCMD.ReplaceGreenOnionsTags());
            regexHPicture = new Regex(BotInfo.HPictureCmd.ReplaceGreenOnionsTags());
            regexBeautyPicture = new Regex(BotInfo.BeautyPictureCmd.ReplaceGreenOnionsTags());
            regexForgeMessage = new Regex(BotInfo.ForgeMessageCmdBegin.ReplaceGreenOnionsTags());
            regexTicTacToeStart = new Regex(BotInfo.StartTicTacToeCmd.ReplaceGreenOnionsTags());
            regexTicTacToeStop = new Regex(BotInfo.StopTicTacToeCmd.ReplaceGreenOnionsTags());
        }

        public static ValueTask Event_OnGroupMessage(string eventType, Sora.EventArgs.SoraEvent.GroupMessageEventArgs eventArgs)
        {
            var msg = eventArgs.Message.MessageBody.FirstOrDefault();
            GreenOnionsBaseMessage[] greenOnionsMsgs = null;

            if (msg != null)
            {
                if (msg.Data is AtSegment)
                {

                }
                else if (msg.Data is TextSegment textMsg)
                {
                    string firstText = textMsg.Content;

                    #region -- 伪造消息 --
                    if (BotInfo.ForgeMessageEnabled && regexForgeMessage.IsMatch(firstText))
                    {
                        LogHelper.WriteInfoLog($"{eventArgs.Sender.Id}消息触发伪造消息");
                        GreenOnionsBaseMessage forgeMsg = ForgeMessageHandler.SendForgeMessage(eventArgs.Message.MessageBody.ToOnionsMessages(), eventArgs.Sender.Id);
                        greenOnionsMsgs = new GreenOnionsBaseMessage[] { forgeMsg };
                        
                        return ValueTask.CompletedTask;
                    }
                    #endregion -- 伪造消息 --

                    #region -- 帮助 --
                    greenOnionsMsgs = HelpHandler.Helps(regexHelp, firstText, eventArgs.SourceGroup.Id);
                    #endregion -- 帮助 --
                }
                else if (msg.Data is ImageSegment)
                {

                }
            }

            if (greenOnionsMsgs != null && greenOnionsMsgs.Length > 0)
            {
                if (greenOnionsMsgs.FirstOrDefault() is GreenOnionsForwardMessage forwardMsg)
                {
                    List<CustomNode> customNodes = new();
                    for (int i = 0; i < forwardMsg.ItemMessages.Count; i++)
                    {
                        customNodes.Add(new(forwardMsg.ItemMessages[i].NickName, forwardMsg.ItemMessages[i].QQid, CreateCqMessages(new[] { forwardMsg.ItemMessages[i].itemMessage })));
                    }
                    eventArgs.SourceGroup.SendGroupForwardMsg(customNodes);
                }
                else
                {
                    var valueTask = eventArgs.SourceGroup.SendGroupMessage(CreateCqMessages(greenOnionsMsgs));
                    if (valueTask.Result.apiStatus.RetCode == ApiStatusType.Ok)
                    {
                        //eventArgs.SoraApi.RecallMessage(valueTask.Result.messageId);
                    }
                }
            }

            return ValueTask.CompletedTask;
        }

        private static MessageBody CreateCqMessages(GreenOnionsBaseMessage[] greenOnionsMsgs)
        {
            MessageBody msg = new();
            for (int i = 0; i < greenOnionsMsgs.Length; i++)
            {
                if (greenOnionsMsgs[i] is GreenOnionsAtMessage atMsg)
                    msg.Add(SoraSegment.At(atMsg.AtId));
                else if (greenOnionsMsgs[i] is GreenOnionsImageMessage imageMsg)
                {
                    if (imageMsg.MemoryStream == null)
                        msg.Add(SoraSegment.Image(imageMsg.Url));
                    else
                        msg.Add(SoraSegment.Image(MemoryStreamToBase64(imageMsg.MemoryStream)));
                }
                else if (greenOnionsMsgs[i] is GreenOnionsTextMessage textMsg)
                    msg.Add(SoraSegment.Text(textMsg.Text));
            }
            return msg;
        }

        private static string MemoryStreamToBase64(MemoryStream ms)
        {
            try
            {
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                string base64Img = Convert.ToBase64String(arr);
                ms.Dispose();
                return base64Img;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
