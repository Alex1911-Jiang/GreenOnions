using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlTranslate : UserControl, IConfigSetting
    {
        public CtrlTranslate()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            cboTranslateEngine.SelectedIndex = (int)BotInfo.TranslateEngineType;
            txbTranslateToChinese.Text = BotInfo.TranslateToChineseCMD;
            txbTranslateTo.Text = BotInfo.TranslateToCMD;
            txbTranslateFromToCMD.Text = BotInfo.TranslateFromToCMD;

            foreach (long item in BotInfo.AutoTranslateGroupMemoriesQQ)
                lstAutoTranslateGroupMemoriesQQ.Items.Add(item.ToString());
        }

        public void SaveConfig()
        {
            BotInfo.TranslateEngineType = (TranslateEngine)cboTranslateEngine.SelectedIndex;
            BotInfo.TranslateToChineseCMD = txbTranslateToChinese.Text;
            BotInfo.TranslateToCMD = txbTranslateTo.Text;
            BotInfo.TranslateFromToCMD = txbTranslateFromToCMD.Text;

            List<long> tempAutoTranslateGroupMemoriesQQ = new List<long>();
            foreach (ListViewItem item in lstAutoTranslateGroupMemoriesQQ.Items)
            {
                tempAutoTranslateGroupMemoriesQQ.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.AutoTranslateGroupMemoriesQQ = tempAutoTranslateGroupMemoriesQQ;
        }

        public void UpdateCache()
        {

        }


        private void btnAddAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstAutoTranslateGroupMemoriesQQ, txbAddAutoTranslateGroupMemoryQQ.Text);

        private void btnRemoveAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstAutoTranslateGroupMemoriesQQ);

        private void cboTranslateEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbTranslateTo.Enabled = cboTranslateEngine.SelectedIndex == (int)TranslateEngine.Google;
            BotInfo.TranslateEngineType = (TranslateEngine)cboTranslateEngine.SelectedIndex;
        }
    }
}
