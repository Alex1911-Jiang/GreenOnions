using System.Net.WebSockets;
using System.Text;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotMain
{
    public class WsClient : MiraiClient
    {
        public ClientWebSocket? _client = null;
        public CancellationTokenSource? _ts = null;

        public WsClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        {
        }

        public override async Task Connect(long qqId, string ip, ushort port, string key)
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
            await _client.ConnectAsync(new Uri($"ws://{ip}:{port}/"), _ts.Token);
            Receive();
        }

        private async void Receive()
        {
            List<byte> messageBytes = new List<byte>();
            while (!_ts!.IsCancellationRequested)
            {
                var buffer = new byte[4096];
                var offset = 0;
                var free = buffer.Length;
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
                ReceiveMessage(json);
            }
        }

        public virtual void ReceiveMessage(string json)
        {

        }
        protected virtual Task SendMessage(string msg)
        {
            return Send(msg);
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

        public override async Task Disconnect()
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
