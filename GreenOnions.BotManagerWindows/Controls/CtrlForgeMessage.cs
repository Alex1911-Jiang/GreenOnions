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
            txbForgeMessageCmdBegin.Text = BotInfo.Config.ForgeMessageCmdBegin;
            txbForgeMessageCmdNewLine.Text = BotInfo.Config.ForgeMessageCmdNewLine;
            chkForgeMessageAppendBotMessageEnabled.Checked = BotInfo.Config.ForgeMessageAppendBotMessageEnabled;
            chkForgeMessageAdminOnly.Checked = BotInfo.Config.ForgeMessageAdminOnly;
            chkForgeMessageAdminDontAppend.Checked = BotInfo.Config.ForgeMessageAdminDontAppend;
            txbForgeMessageAppendMessage.Text = BotInfo.Config.ForgeMessageAppendMessage;
            chkRefuseForgeAdmin.Checked = BotInfo.Config.RefuseForgeAdmin;
            txbRefuseForgeAdminReply.Text = BotInfo.Config.RefuseForgeAdminReply;
            chkRefuseForgeBot.Checked = BotInfo.Config.RefuseForgeBot;
            txbRefuseForgeBotReply.Text = BotInfo.Config.RefuseForgeBotReply;

            txbForgeMessageCmd.Text = $"{txbForgeMessageCmdBegin.Text}<@QQ><伪造内容>";
        }

        public void SaveConfig()
        {
            BotInfo.Config.ForgeMessageCmdBegin = txbForgeMessageCmdBegin.Text;
            BotInfo.Config.ForgeMessageCmdNewLine = txbForgeMessageCmdNewLine.Text;
            BotInfo.Config.ForgeMessageAppendBotMessageEnabled = chkForgeMessageAppendBotMessageEnabled.Checked;
            BotInfo.Config.ForgeMessageAdminOnly = chkForgeMessageAdminOnly.Checked;
            BotInfo.Config.ForgeMessageAdminDontAppend = chkForgeMessageAdminDontAppend.Checked;
            BotInfo.Config.ForgeMessageAppendMessage = txbForgeMessageAppendMessage.Text;
            BotInfo.Config.RefuseForgeAdmin = chkRefuseForgeAdmin.Checked;
            BotInfo.Config.RefuseForgeAdminReply = txbRefuseForgeAdminReply.Text;
            BotInfo.Config.RefuseForgeBot = chkRefuseForgeBot.Checked;
            BotInfo.Config.RefuseForgeBotReply = txbRefuseForgeBotReply.Text;
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
