using Lagrange.Core;

namespace GreenOnions.NT.Base
{
    public static class SngletonInstance
    {
        public static BotContext? Bot { get; set; }
        public static ICommonConfig? Config { get; set; }
    }
}
