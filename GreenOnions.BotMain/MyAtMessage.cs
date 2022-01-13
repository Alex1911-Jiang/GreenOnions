using Mirai.CSharp.HttpApi.Models.ChatMessages;
using System.Text.Json;

namespace GreenOnions.BotMain
{
    public class MyAtMessage : AtMessage
    {
        public MyAtMessage(long target, string name) : base(target)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
