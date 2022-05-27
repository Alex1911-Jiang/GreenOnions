using Sora.EventArgs.SoraEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenOnions.CqHttp
{
    public static class MessageEvents
    {
        public static ValueTask Event_OnGroupMessage(string eventType, GroupMessageEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        public static ValueTask Event_OnPrivateMessage(string eventType, PrivateMessageEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
