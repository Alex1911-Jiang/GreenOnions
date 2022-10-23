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
            txbOriginalPictureCommand.Text = BotInfo.OriginalPictureCommand;
            txbOriginalPictureDownloadingReply.Text = BotInfo.OriginalPictureDownloadingReply;
            chkOriginalPictureCheckPornEnabled.Checked = BotInfo.OriginalPictureCheckPornEnabled;  //是否在下载原图启用鉴黄
            switch (BotInfo.OriginalPictureCheckPornEvent)  //鉴黄不通过的行为
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
            txbOriginalPictureCheckPornIllegalReply.Text = BotInfo.OriginalPictureCheckPornIllegalReply;
            txbOriginalPictureCheckPornErrorReply.Text = BotInfo.OriginalPictureCheckPornErrorReply;
        }

        public void SaveConfig()
        {
            BotInfo.OriginalPictureCommand = txbOriginalPictureCommand.Text;
            BotInfo.OriginalPictureDownloadingReply = txbOriginalPictureDownloadingReply.Text;
            BotInfo.OriginalPictureCheckPornEnabled = chkOriginalPictureCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.OriginalPictureCheckPornEvent = Convert.ToInt32(pnlOriginalPictureCheckPornEvent.Controls.OfType<RadioButton>().Where(x => x.Checked).First().Tag);
            BotInfo.OriginalPictureCheckPornIllegalReply = txbOriginalPictureCheckPornIllegalReply.Text;
            BotInfo.OriginalPictureCheckPornErrorReply = txbOriginalPictureCheckPornErrorReply.Text;
        }

        public void UpdateCache()
        {
        }

        private void chkOriginalPictureCheckPornEnabled_CheckedChanged(object sender, EventArgs e) => pnlOriginalPictureCheckPorn.Enabled = chkOriginalPictureCheckPornEnabled.Checked;

        private void rdoOriginalPictureCheckPornSendByForward_CheckedChanged(object sender, EventArgs e) => pnlOriginalPictureCheckPornMessage.Enabled = rdoOriginalPictureCheckPornReply.Checked;
    }
}
