using GreenOnions.Interface;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace GreenOnions.TicTacToe
{
    public static class TicTacToeHandler
    {
        public static IDictionary<long, TicTacToeSession> PlayingTicTacToeSessions { get; } = new Dictionary<long, TicTacToeSession>();

        /// <summary>
        /// 开始棋局
        /// </summary>
        /// <param name="qqId">玩家QQ</param>
        public static void StartTicTacToeSession(long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers[qqId] = DateTime.Now.AddMinutes(2);
                SendMessage(BotInfo.TicTacToeAlreadyStartReply.ReplaceGreenOnionsTags());
            }
            else
            {
                Cache.PlayingTicTacToeUsers.TryAdd(qqId, DateTime.Now.AddMinutes(2));
                Cache.SetWorkingTimeout(qqId, () =>  //启动棋局计时
                {
                    if (PlayingTicTacToeSessions.ContainsKey(qqId))
                        PlayingTicTacToeSessions.Remove(qqId);
                    if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
                        Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                    SendMessage(BotInfo.TicTacToeTimeoutReply.ReplaceGreenOnionsTags());  //超时退出棋局
                }, Cache.PlayingTicTacToeUsers);
                TicTacToeSession session = new TicTacToeSession();
                Bitmap chessboard = session.StartNewSession();  //不能using, 要保留在棋局对象里
                using (MemoryStream tempMs = new MemoryStream())
                {
                    chessboard.Save(tempMs, ImageFormat.Jpeg);
                    using (MemoryStream ms = new MemoryStream(tempMs.ToArray()))
                    {
                        PlayingTicTacToeSessions.Add(qqId, session);
                        SendMessage(new GreenOnionsBaseMessage[] { BotInfo.TicTacToeStartedReply.ReplaceGreenOnionsTags(), ms });
                    }
                }
            }
        }

        /// <summary>
        /// 中止棋局
        /// </summary>
        /// <param name="qqId">玩家QQ</param>
        public static void StopTicTacToeSession(long qqId, Action<GreenOnionsMessages> SendMessage)
        {
            if (Cache.PlayingTicTacToeUsers.ContainsKey(qqId))
            {
                Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                SendMessage(BotInfo.TicTacToeStoppedReply.ReplaceGreenOnionsTags());
            }
            else
            {
                SendMessage(BotInfo.TicTacToeAlreadStopReply.ReplaceGreenOnionsTags());
            }
            if (PlayingTicTacToeSessions.ContainsKey(qqId))
                PlayingTicTacToeSessions.Remove(qqId);
        }

        /// <summary>
        /// 使用坐标下子
        /// </summary>
        /// <param name="moveMsg">坐标命令</param>
        /// <param name="qqId">玩家QQ</param>
        public static void PlayerMoveByNomenclature(string moveMsg, long qqId, Action<GreenOnionsMessages> SendMessage)
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
                        SendMessage(BotInfo.TicTacToeMoveFailReply.ReplaceGreenOnionsTags());
                    else
                        SendMessage(SendBitmapAfterMove(qqId, nowStepBmp, winOrLostType));
                }
            }
            else
                LogHelper.WriteErrorLogWithUserMessage($"数据异常, 时间表中存在QQ:{qqId}, 但对局表中不存在, 可能是刚刚超时了", null);
        }

        /// <summary>
        /// 使用涂鸦下子
        /// </summary>
        /// <param name="qqId">玩家QQ</param>
        /// <param name="playerMoveStream">玩家下子图片</param>
        public static GreenOnionsMessages PlayerMoveByBitmap(long qqId, Stream playerMoveStream)
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
                            return BotInfo.TicTacToeNoMoveReply.ReplaceGreenOnionsTags();
                        else if (weight.Keys.Count > 1)  //多个格子被修改
                            return BotInfo.TicTacToeIllegalMoveReply.ReplaceGreenOnionsTags();
                        else
                        {
                            var maxWeight = weight.Where(kv => kv.Value > 11).OrderByDescending(kv => kv.Value);
                            if (maxWeight != null && maxWeight.Count() > 0)
                            {
                                Point hit = maxWeight.First().Key;
                                Bitmap nowStepBmp = PlayingTicTacToeSessions[qqId].PlayerMove(hit.X, hit.Y, out int? winOrLostType);
                                if (nowStepBmp == null)
                                    return BotInfo.TicTacToeMoveFailReply.ReplaceGreenOnionsTags();
                                else
                                    return SendBitmapAfterMove(qqId, nowStepBmp, winOrLostType);
                            }
                        }
                    }
                    return null;
                }
                else
                {
                    LogHelper.WriteErrorLogWithUserMessage("井字棋图片转换失败", null);
                    return "图裂了o(╥﹏╥)o".ReplaceGreenOnionsTags();
                }
            }
            else
            {
                LogHelper.WriteErrorLogWithUserMessage($"数据异常, 时间表中存在QQ:{qqId}, 但对局表中不存在, 可能是刚刚超时了", null);
                return "<机器人名称>把图弄丢了, 这局就当您赢了吧, 请向<机器人名称>反馈Bug o(╥﹏╥)o".ReplaceGreenOnionsTags();
            }
        }

        public static GreenOnionsMessages SendBitmapAfterMove(long qqId, Bitmap nowStepBmp, int? winOrLostMsg)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                nowStepBmp.Save(tempMs, ImageFormat.Jpeg);
                using (MemoryStream ms = new MemoryStream(tempMs.ToArray()))
                {
                    GreenOnionsMessages outMsg = new GreenOnionsMessages();
                    outMsg.Add(ms);

                    if (winOrLostMsg != null)
                    {
                        switch (winOrLostMsg)
                        {
                            case -1: //bot获胜
                                outMsg.Add(BotInfo.TicTacToeBotWinReply.ReplaceGreenOnionsTags());
                                break;
                            case 0:  //平局
                                outMsg.Add(BotInfo.TicTacToeDrawReply.ReplaceGreenOnionsTags());
                                break;
                            case 1:  //玩家获胜
                                outMsg.Add(BotInfo.TicTacToePlayerWinReply.ReplaceGreenOnionsTags());
                                break;
                        }
                        PlayingTicTacToeSessions.Remove(qqId);
                        Cache.PlayingTicTacToeUsers.TryRemove(qqId, out _);
                    }
                    return outMsg;
                }
            }
        }
    }
}
