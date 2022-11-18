using System.Data;
using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlOriginalPicture : UserControl, IConfigSetting
    {
        public CtrlOriginalPicture()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            txbOriginalPictureCommand.Text = BotInfo.Config.OriginalPictureCommand;
            txbOriginalPictureDownloadingReply.Text = BotInfo.Config.OriginalPictureDownloadingReply;
            chkOriginalPictureCheckPornEnabled.Checked = BotInfo.Config.OriginalPictureCheckPornEnabled;  //是否在下载原图启用鉴黄
            switch (BotInfo.Config.OriginalPictureCheckPornEvent)  //鉴黄不通过的行为
            {
                case 0:
                    rdoOriginalPictureCheckPornSendByForward.Checked = true;
                    break;
                case 1:
                    rdoOriginalPictureCheckPornDoNothing.Checked = true;
                    break;
                case 2:
                    rdoOriginalPictureCheckPornReply.Checked = true;
                    break;
            }
            txbOriginalPictureCheckPornIllegalReply.Text = BotInfo.Config.OriginalPictureCheckPornIllegalReply;
            txbOriginalPictureCheckPornErrorReply.Text = BotInfo.Config.OriginalPictureCheckPornErrorReply;
        }

        public void SaveConfig()
        {
            BotInfo.Config.OriginalPictureCommand = txbOriginalPictureCommand.Text;
            BotInfo.Config.OriginalPictureDownloadingReply = txbOriginalPictureDownloadingReply.Text;
            BotInfo.Config.OriginalPictureCheckPornEnabled = chkOriginalPictureCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.Config.OriginalPictureCheckPornEvent = Convert.ToInt32(pnlOriginalPictureCheckPornEvent.Controls.OfType<RadioButton>().Where(x => x.Checked).First().Tag);
            BotInfo.Config.OriginalPictureCheckPornIllegalReply = txbOriginalPictureCheckPornIllegalReply.Text;
            BotInfo.Config.OriginalPictureCheckPornErrorReply = txbOriginalPictureCheckPornErrorReply.Text;
        }

        public void UpdateCache()
        {
        }

        private void chkOriginalPictureCheckPornEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginalPictureCheckPorn.Enabled = chkOriginalPictureCheckPornEnabled.Checked;

        private void rdoOriginalPictureCheckPornSendByForward_CheckedChanged(object sender, EventArgs e) => pnlOriginalPictureCheckPornMessage.Enabled = rdoOriginalPictureCheckPornReply.Checked;
    }
}
