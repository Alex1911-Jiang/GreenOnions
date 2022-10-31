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
            chkRandomRepeat.Checked = BotInfo.RandomRepeatEnabled;
            txbRandomRepeatProbability.Text = BotInfo.RandomRepeatProbability.ToString();
            chkSuccessiveRepeat.Checked = BotInfo.SuccessiveRepeatEnabled;
            txbSuccessiveRepeatCount.Text = BotInfo.SuccessiveRepeatCount.ToString();
            chkRewindGif.Checked = BotInfo.RewindGifEnabled;
            txbRewindGifProbability.Text = BotInfo.RewindGifProbability.ToString();
            chkHorizontalMirrorImage.Checked = BotInfo.HorizontalMirrorImageEnabled;
            txbHorizontalMirrorImageProbability.Text = BotInfo.HorizontalMirrorImageProbability.ToString();
            chkVerticalMirrorImage.Checked = BotInfo.VerticalMirrorImageEnabled;
            chkReplaceMeToYou.Checked = BotInfo.ReplaceMeToYou;
            txbVerticalMirrorImageProbability.Text = BotInfo.VerticalMirrorImageProbability.ToString();
        }

        public void SaveConfig()
        {
            BotInfo.RandomRepeatEnabled = chkRandomRepeat.Checked;
            BotInfo.RandomRepeatProbability = string.IsNullOrEmpty(txbRandomRepeatProbability.Text) ? 0 : Convert.ToInt32(txbRandomRepeatProbability.Text);
            BotInfo.SuccessiveRepeatEnabled = chkSuccessiveRepeat.Checked;
            BotInfo.SuccessiveRepeatCount = string.IsNullOrEmpty(txbSuccessiveRepeatCount.Text) ? 0 : Convert.ToInt32(txbSuccessiveRepeatCount.Text);
            BotInfo.RewindGifEnabled = chkRewindGif.Checked;
            BotInfo.RewindGifProbability = Convert.ToInt32(txbRewindGifProbability.Text);
            BotInfo.HorizontalMirrorImageEnabled = chkHorizontalMirrorImage.Checked;
            BotInfo.HorizontalMirrorImageProbability = string.IsNullOrEmpty(txbHorizontalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbHorizontalMirrorImageProbability.Text);
            BotInfo.VerticalMirrorImageEnabled = chkVerticalMirrorImage.Checked;
            BotInfo.ReplaceMeToYou = chkReplaceMeToYou.Checked;
            BotInfo.VerticalMirrorImageProbability = string.IsNullOrEmpty(txbVerticalMirrorImageProbability.Text) ? 0 : Convert.ToInt32(txbVerticalMirrorImageProbability.Text);
        }

        public void UpdateCache()
        {

        }
    }
}
