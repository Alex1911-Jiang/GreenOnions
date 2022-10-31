using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlForgeMessage : UserControl, IConfigSetting
    {
        public CtrlForgeMessage()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            txbForgeMessageCmdBegin.Text = BotInfo.ForgeMessageCmdBegin;
            txbForgeMessageCmdNewLine.Text = BotInfo.ForgeMessageCmdNewLine;
            chkForgeMessageAppendBotMessageEnabled.Checked = BotInfo.ForgeMessageAppendBotMessageEnabled;
            chkForgeMessageAdminOnly.Checked = BotInfo.ForgeMessageAdminOnly;
            chkForgeMessageAdminDontAppend.Checked = BotInfo.ForgeMessageAdminDontAppend;
            txbForgeMessageAppendMessage.Text = BotInfo.ForgeMessageAppendMessage;
            chkRefuseForgeAdmin.Checked = BotInfo.RefuseForgeAdmin;
            txbRefuseForgeAdminReply.Text = BotInfo.RefuseForgeAdminReply;
            chkRefuseForgeBot.Checked = BotInfo.RefuseForgeBot;
            txbRefuseForgeBotReply.Text = BotInfo.RefuseForgeBotReply;
        }

        public void SaveConfig()
        {
            BotInfo.ForgeMessageCmdBegin = txbForgeMessageCmdBegin.Text;
            BotInfo.ForgeMessageCmdNewLine = txbForgeMessageCmdNewLine.Text;
            BotInfo.ForgeMessageAppendBotMessageEnabled = chkForgeMessageAppendBotMessageEnabled.Checked;
            BotInfo.ForgeMessageAdminOnly = chkForgeMessageAdminOnly.Checked;
            BotInfo.ForgeMessageAdminDontAppend = chkForgeMessageAdminDontAppend.Checked;
            BotInfo.ForgeMessageAppendMessage = txbForgeMessageAppendMessage.Text;
            BotInfo.RefuseForgeAdmin = chkRefuseForgeAdmin.Checked;
            BotInfo.RefuseForgeAdminReply = txbRefuseForgeAdminReply.Text;
            BotInfo.RefuseForgeBot = chkRefuseForgeBot.Checked;
            BotInfo.RefuseForgeBotReply = txbRefuseForgeBotReply.Text;
        }

        public void UpdateCache()
        {
        }

        private void txbForgeMessageCmd_TextChanged(object? sender, EventArgs e)
        {
            txbForgeMessageCmdBegin.TextChanged -= txbForgeMessageCmd_TextChanged;
            txbForgeMessageCmd.Text = $"{txbForgeMessageCmdBegin.Text}<@QQ><伪造内容>";
            txbForgeMessageCmdBegin.TextChanged += txbForgeMessageCmd_TextChanged;
        }

        private void chkForgeMessageAppendBotMessageEnabled_CheckedChanged(object sender, EventArgs e) => txbForgeMessageAppendMessage.Enabled = chkForgeMessageAppendBotMessageEnabled.Checked;

        private void chkRefuseForgeAdmin_CheckedChanged(object sender, EventArgs e) => txbRefuseForgeAdminReply.Enabled = chkRefuseForgeAdmin.Checked;

        private void chkRefuseForgeBot_CheckedChanged(object sender, EventArgs e) => txbRefuseForgeBotReply.Enabled = chkRefuseForgeBot.Checked;
    }
}
