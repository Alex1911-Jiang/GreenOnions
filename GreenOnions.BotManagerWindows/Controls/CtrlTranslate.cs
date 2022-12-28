using GreenOnions.Interface.Configs.Enums;
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
            cboTranslateEngine.SelectedIndex = (int)BotInfo.Config.TranslateEngineType;

            txbTranslateAPPID.Text = BotInfo.Config.TranslateAPPID;
            txbTranslateAPPKey.Text = BotInfo.Config.TranslateAPPKey;

            txbTranslateToChinese.Text = BotInfo.Config.TranslateToChineseCMD;
            txbTranslateTo.Text = BotInfo.Config.TranslateToCMD;
            txbTranslateFromToCMD.Text = BotInfo.Config.TranslateFromToCMD;

            foreach (long item in BotInfo.Config.AutoTranslateGroupMembersQQ)
                lstAutoTranslateGroupMemoriesQQ.Items.Add(item.ToString());
        }

        public void SaveConfig()
        {
            BotInfo.Config.TranslateEngineType = (TranslateEngine)cboTranslateEngine.SelectedIndex;

            BotInfo.Config.TranslateAPPID = txbTranslateAPPID.Text;
            BotInfo.Config.TranslateAPPKey = txbTranslateAPPKey.Text;

            BotInfo.Config.TranslateToChineseCMD = txbTranslateToChinese.Text;
            BotInfo.Config.TranslateToCMD = txbTranslateTo.Text;
            BotInfo.Config.TranslateFromToCMD = txbTranslateFromToCMD.Text;

            HashSet<long> tempAutoTranslateGroupMemoriesQQ = new HashSet<long>();
            foreach (ListViewItem item in lstAutoTranslateGroupMemoriesQQ.Items)
            {
                tempAutoTranslateGroupMemoriesQQ.Add(Convert.ToInt64(item.SubItems[0].Text));
            }
            BotInfo.Config.AutoTranslateGroupMembersQQ = tempAutoTranslateGroupMemoriesQQ;
        }

        public void UpdateCache()
        {

        }

        private void btnAddAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => ((IConfigSetting)this).AddItemToListView(lstAutoTranslateGroupMemoriesQQ, txbAddAutoTranslateGroupMemoryQQ.Text);

        private void btnRemoveAutoTranslateGroupMemoryQQ_Click(object sender, EventArgs e) => ((IConfigSetting)this).RemoveItemFromListView(lstAutoTranslateGroupMemoriesQQ);
    }
}
