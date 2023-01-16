namespace GreenOnions.BotMain
{
    public abstract class MiraiClient
    {
        public Action<bool, string> ConnectedEvent { get; }
        public MiraiClient(Action<bool, string> connectedEvent)
        {
            ConnectedEvent = connectedEvent;
        }
        public abstract Task Connect(long qqId, string ip, ushort port, string key);
        public abstract Task Disconnect();
    }
}
