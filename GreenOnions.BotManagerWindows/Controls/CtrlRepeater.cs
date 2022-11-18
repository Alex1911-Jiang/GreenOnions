using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlRepeater : UserControl, IConfigSetting
    {
        public CtrlRepeater()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            chkRandomRepeat.Checked = BotInfo.Config.RandomRepeatEnabled;
            txbRandomRepeatProbability.Text = BotInfo.Config.RandomRepeatProbability.ToString();
            chkSuccessiveRepeat.Checked = BotInfo.Config.SuccessiveRepeatEnabled;
            txbSuccessiveRepeatCount.Text = BotInfo.Config.SuccessiveRepeatCount.ToString();
            chkRewindGif.Checked = BotInfo.Config.RewindGifEnabled;
            txbRewindGifProbability.Text = BotInfo.Config.RewindGifProbability.ToString();
            chkHorizontalMirrorImage.Checked = BotInfo.Config.HorizontalMirrorImageEnabled;
            txbHorizontalMirrorImageProbability.Text = BotInfo.Config.HorizontalMirrorImageProbability.ToString();
            chkVerticalMirrorImage.Checked = BotInfo.Config.VerticalMirrorImageEnabled;
            chkReplaceMeToYou.Checked = BotInfo.Config.ReplaceMeToYou;
            txbVerticalMirrorImageProbability.Text = BotInfo.Config.VerticalMirrorImageProbability.ToString();
        }

        public void SaveConfig()
        {
            BotInfo.Config.RandomRepeatEnabled = chkRandomRepeat.Checked;
            BotInfo.Config.RandomRepeatProbability = string.IsNullOrEmpty(txbRandomRepeatProbability.Text) ? 0 : Convert.ToInt32(txbRandomRepeatProbability.Text);
            BotInfo.Config.SuccessiveRepeatEnabled = chkSuccessiveRepeat.Checked;
            BotInfo.Config.SuccessiveRepeatCount = string.IsNullOrEmpty(txbSuccessiveRepeatCount.Text) ? 0 : Convert.ToInt32(txbSuccessiveRepeatCount.Text);
            BotInfo.Config.RewindGifEnabled = chkRewindGif.Checked;
            BotInfo.Config.RewindGifProbability = Convert.ToInt32(txbRewindGifProbability.Text);
            BotInfo.Config.HorizontalMirrorImageEnabled = chkHorizontalMirrorImage.Checked;
            BotInfo.Config.HorizontalMirrorImageProbability = string.IsNullOrEmpty(txbHorizontalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbHorizontalMirrorImageProbability.Text);
            BotInfo.Config.VerticalMirrorImageEnabled = chkVerticalMirrorImage.Checked;
            BotInfo.Config.ReplaceMeToYou = chkReplaceMeToYou.Checked;
            BotInfo.Config.VerticalMirrorImageProbability = string.IsNullOrEmpty(txbVerticalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbVerticalMirrorImageProbability.Text);
        }

        public void UpdateCache()
        {

        }
    }
}
