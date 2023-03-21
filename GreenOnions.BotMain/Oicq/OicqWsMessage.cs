namespace GreenOnions.BotMain.Oicq
{
    public class OicqWsMessage
    {
        public string Mode { get; set; } = "message";
        public string Param { get; set; }
        public string Message { get; set; }
        public long? TargetId { get; set; }
        public long? TargetGroup { get; set; }
        public int RevokeTime { get; set; } = 0;
    }
}
