using System.Net.WebSockets;
using System.Text;
using GreenOnions.BotMain.Konata;
using GreenOnions.Interface;
using GreenOnions.Utility.Helper;
using Konata.Core.Message;
using Newtonsoft.Json;

namespace GreenOnions.BotMain.Knife
{
    public class KnifeClient
    {
        public ClientWebSocket? _client = null;
        public CancellationTokenSource? _ts = null;

        public async Task Connect()
        {
            if (_ts is not null)
            {
                _ts.Cancel();
                _ts.Dispose();
            }
            if (_client is not null)
                _client.Dispose();
            _ts = new CancellationTokenSource();
            _client = new ClientWebSocket();
            await _client.ConnectAsync(new Uri("127.0.0.1:33111"), _ts.Token);
            Receive();
        }

        private async void Receive()
        {
            List<byte> messageBytes = new List<byte>();
            var buffer = new byte[4096];
            var offset = 0;
            var free = buffer.Length;
            while (!_ts!.IsCancellationRequested)
            {
                WebSocketReceiveResult result;
                do
                {
                    ArraySegment<byte> bytesReceived = new ArraySegment<byte>(buffer, offset, free);
                    result = await _client!.ReceiveAsync(bytesReceived, _ts!.Token);
                    if (bytesReceived.Array is null)
                    {
                        LogHelper.WriteWarningLog("接收到了空的ws消息");
                        continue;
                    }
                    offset += result.Count;
                    free -= result.Count;
                    messageBytes.AddRange(bytesReceived.Array);
                } while (!result.EndOfMessage);

                string json = Encoding.UTF8.GetString(messageBytes.ToArray(), 0, messageBytes.Count);
                messageBytes.Clear();
                HandleMessage(json);
            }
        }

        public static KnifeMessage? JsonToKnifeMessage(string json)
        {
            return JsonConvert.DeserializeObject<KnifeMessage>(json);
        }

        public static string KQMessagesJson(BaseChain[] msgs)
        {
            return JsonConvert.SerializeObject(msgs);
        }


        public void HandleMessage(string json)
        {
            KnifeMessage? knifeMsg = JsonToKnifeMessage(json);
            if (knifeMsg is null || knifeMsg.Message is null)
                return;
            GreenOnionsMessages msgs = knifeMsg.Message.ToGreenOnionsMessages(knifeMsg.SenderId, knifeMsg.SenderName);
            MessageHandler.HandleMesage(msgs, knifeMsg.SenderGroup, SendMessage);
        }

        private async void SendMessage(GreenOnionsMessages msg)
        {
            BaseChain[] kqMsgs = msg.ToKonataMessages();
            string json = JsonConvert.SerializeObject(kqMsgs);
            await Send(json);
        }

        public async Task Send(string Msg)
        {
            if (_client!.State != WebSocketState.Open)
            {
                LogHelper.WriteErrorLog("发送ws消息失败，没有打开连接", null);
                return;
            }
            ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(Msg));
            await _client.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task Disconnect()
        {
            if (_client is null)
                return;
            await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, _ts!.Token);
            _ts.Cancel();
            _client.Dispose();
            _ts = null;
            _client = null;
        }
    }
}
