using Mirai.CSharp.HttpApi.Models.ChatMessages;

namespace GreenOnions.ForgeMessage
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
