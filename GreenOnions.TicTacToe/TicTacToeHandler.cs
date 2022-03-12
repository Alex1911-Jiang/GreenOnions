using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreenOnions.TicTacToe
{
    public static class TicTacToeHandler
    {
        public static IDictionary<long, TicTacToeSession> PlayingTicTacToeSessions { get; } = new Dictionary<long, TicTacToeSession>();

        public static async void StartTicTacToeSession(long qqId, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers[qqId] = DateTime.Now.AddMinutes(2);
                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeAlreadyStartReply.ReplaceGreenOnionsTags()) }, true);
            }
            else
            {
                Cache.PlayingTicTacToeUsers.TryAdd(qqId, DateTime.Now.AddMinutes(2));
                Cache.SetWorkingTimeout(qqId, Cache.PlayingTicTacToeUsers, () =>  //启动棋局计时
                {
                    if (PlayingTicTacToeSessions.ContainsKey(qqId))
                        PlayingTicTacToeSessions.Remove(qqId);
                    if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
                        Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeTimeoutReply.ReplaceGreenOnionsTags()) }, true);
                });
                TicTacToeSession session = new TicTacToeSession();
                Bitmap chessboard = session.StartNewSession();  //不能using, 要保留在棋局对象里
                using (MemoryStream tempMs = new MemoryStream())
                {
                    chessboard.Save(tempMs, ImageFormat.Jpeg);
                    using (MemoryStream ms = new MemoryStream(tempMs.ToArray()))
                    {
                        IImageMessage image = await UploadPicture(ms);
                        SendMessage?.Invoke(new IChatMessage[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeStartedReply.ReplaceGreenOnionsTags()), image }, true);
                        PlayingTicTacToeSessions.Add(qqId, session);
                    }
                }
            }
        }

        public static void StopTicTacToeSession(long qqId, Func<IChatMessage[], bool, Task<int>> SendMessage)
        {
            if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                SendMessage?.Invoke(new IChatMessage[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeStoppedReply.ReplaceGreenOnionsTags()) }, true);
            }
            else
            {
                SendMessage?.Invoke(new IChatMessage[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeAlreadStopReply.ReplaceGreenOnionsTags()) }, true);
            }
            if (PlayingTicTacToeSessions.ContainsKey(qqId))
                PlayingTicTacToeSessions.Remove(qqId);
        }

        public static void PlayerMoveByNomenclature(string moveMsg, long qqId, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            if (PlayingTicTacToeSessions.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers[qqId] = DateTime.Now.AddMinutes(2);

                int x = -1;
                int y = -1;

                if (char.IsDigit(moveMsg[1]))
                    x = moveMsg[1] - '1';

                if (char.IsUpper(moveMsg[0]))
                    y = moveMsg[0] - 'A';
                else if (char.IsLower(moveMsg[0]))
                    y = moveMsg[0] - 'a';
                else if (char.IsDigit(moveMsg[0]))
                    y = moveMsg[0] - '1';

                if (x > -1 && x < 3 && y > -1 && y < 3)
                {
                    Bitmap nowStepBmp = PlayingTicTacToeSessions[qqId].PlayerMove(x, y, out int? winOrLostType);
                    if (nowStepBmp == null)  //下子失败
                        SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeMoveFailReply.ReplaceGreenOnionsTags()) }, true);
                    else
                        SendBitmapAfterMove(qqId, nowStepBmp, SendMessage, UploadPicture, winOrLostType);
                }
            }
            else
                ErrorHelper.WriteErrorLogWithUserMessage($"数据异常, 时间表中存在QQ:{qqId}, 但对局表中不存在, 可能是刚刚超时了", null);
        }

        public static async void PlayerMoveByBitmap(long qqId, Stream playerMoveStream, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture)
        {
            if (PlayingTicTacToeSessions.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers[qqId] = DateTime.Now.AddMinutes(2);

                Bitmap bmpTemp = new Bitmap(playerMoveStream);
                Bitmap playerMoveBmp = new Bitmap(bmpTemp);
                bmpTemp.Dispose();
                if (playerMoveBmp != null)
                {
                    int isameSize = PlayingTicTacToeSessions[qqId].IsBitmapSizeSame(playerMoveBmp.Width, playerMoveBmp.Height); //图片尺寸相同才进行识别, 有时沙雕群友都喜欢在棋局中间穿插表情包
                    if (isameSize != -1)
                    {
                        var weight = PlayingTicTacToeSessions[qqId].PlayerMoveByBitmap(playerMoveBmp);

                        if (weight.Keys.Count == 0)  //没有修改
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeNoMoveReply.ReplaceGreenOnionsTags()) }, true);
                        else if (weight.Keys.Count > 1)  //多个格子被修改
                            SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeIllegalMoveReply.ReplaceGreenOnionsTags()) }, true);
                        else
                        {
                            var maxWeight = weight.Where(kv => kv.Value > 11).OrderByDescending(kv => kv.Value);
                            if (maxWeight != null && maxWeight.Count() > 0)
                            {
                                Point hit = maxWeight.First().Key;
                                Bitmap nowStepBmp = PlayingTicTacToeSessions[qqId].PlayerMove(hit.X, hit.Y, out int? winOrLostType);
                                if (nowStepBmp == null) 
                                    SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeMoveFailReply.ReplaceGreenOnionsTags()) }, true);
                                else
                                    SendBitmapAfterMove(qqId, nowStepBmp, SendMessage, UploadPicture, winOrLostType);
                            }
                        }
                    }
                }
                else
                    ErrorHelper.WriteErrorLogWithUserMessage("井字棋图片转换失败", null);
            }
            else
                ErrorHelper.WriteErrorLogWithUserMessage($"数据异常, 时间表中存在QQ:{qqId}, 但对局表中不存在, 可能是刚刚超时了", null);
        }

        public static async void SendBitmapAfterMove(long qqId, Bitmap nowStepBmp, Func<IChatMessage[], bool, Task<int>> SendMessage, Func<Stream, Task<IImageMessage>> UploadPicture, int? winOrLostMsg)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                nowStepBmp.Save(tempMs, ImageFormat.Jpeg);
                using (MemoryStream ms = new MemoryStream(tempMs.ToArray()))
                {
                    IImageMessage image = await UploadPicture(ms);
                    SendMessage?.Invoke(new[] { image }, false);
                    ms.Dispose();

                    if (winOrLostMsg != null)
                    {
                        switch (winOrLostMsg)
                        {
                            case -1:
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeBotWinReply.ReplaceGreenOnionsTags()) }, true);
                                break;
                            case 0:
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToeDrawReply.ReplaceGreenOnionsTags()) }, true);
                                break;
                            case 1:
                                SendMessage?.Invoke(new[] { new Mirai.CSharp.HttpApi.Models.ChatMessages.PlainMessage(BotInfo.TicTacToePlayerWinReply.ReplaceGreenOnionsTags()) }, true);
                                break;
                        }
                        PlayingTicTacToeSessions.Remove(qqId);
                        Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                    }
                }
            }
        }
    }
}
