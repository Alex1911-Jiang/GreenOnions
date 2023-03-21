using GreenOnions.BotMain.Knife;
using GreenOnions.BotMain.Konata;
using GreenOnions.Interface;
using Konata.Core.Message;
using Newtonsoft.Json;

namespace GreenOnions.BotMain.Knife
{
    public class KnifeClient : WsClient
    {
        public KnifeClient(Action<bool, string> connectedEvent) : base(connectedEvent)
        {
        }

        public override async void ReceiveMessage(string json)
        {
            KnifeMessage? knifeMsg = JsonToKnifeMessage(json);
            if (knifeMsg is null || knifeMsg.Message is null)
                return;
            GreenOnionsMessages msgs = knifeMsg.Message.ToGreenOnionsMessages(knifeMsg.SenderId, knifeMsg.SenderName);
            await MessageHandler.HandleMesage(msgs, knifeMsg.SenderGroup, SendMessage);
        }

        protected async void SendMessage(GreenOnionsMessages msg)
        {
            if (msg is null || msg.Count == 0)
            {
                return;
            }
            if (msg.First() is GreenOnionsTextMessage txm && string.IsNullOrEmpty(txm.Text))
            {
                return;
            }
            BaseChain[] kqMsgs = msg.ToKonataMessages();
            string json = JsonConvert.SerializeObject(kqMsgs);
            await base.SendMessage(json);
        }


        private KnifeMessage? JsonToKnifeMessage(string json)
        {
            return JsonConvert.DeserializeObject<KnifeMessage>(json);
        }

        private string KQMessagesJson(BaseChain[] msgs)
        {
            return JsonConvert.SerializeObject(msgs);
        }


    }
}
