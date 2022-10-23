using GreenOnions.Utility;

namespace GreenOnions.BotManagerWindows.Controls
{
    public partial class CtrlSearchPicture : UserControl, IConfigSetting
    {
        public CtrlSearchPicture()
        {
            InitializeComponent();
        }

        public void LoadConfig()
        {
            chkPmAutoSearch.Checked = BotInfo.PmAutoSearch;

            chkSearchTraceMoeEnabled.Checked = BotInfo.SearchEnabledTraceMoe;  //是否启用TraceMoe搜番
            txbTraceMoeSendThreshold.Text = BotInfo.TraceMoeSendThreshold.ToString();
            chkTraceMoeSendAdultThuImg.Checked = BotInfo.TraceMoeSendAdultThuImg;

            chkSearchSauceNAOEnabled.Checked = BotInfo.SearchEnabledSauceNAO;  //SauceNAO Api-Key
            chkSearchSauceNAOSortByDesc.Checked = BotInfo.SearchSauceNAOSortByDesc;
            chkSearchSauceNAOSendPixivOriginalPicture.Checked = BotInfo.SearchSauceNAOSendPixivOriginalPicture;
            txbSearchSauceNAOApiKey.Text = string.Join("\r\n", BotInfo.SauceNAOApiKey);
            txbSearchSauceNAOLowSimilarity.Text = BotInfo.SearchSauceNAOLowSimilarity.ToString();
            txbSearchSauceNAOHighSimilarity.Text = BotInfo.SearchSauceNAOHighSimilarity.ToString();

            chkSearchASCII2DEnabled.Checked = BotInfo.SearchEnabledASCII2D;  //是否启用ASCII2D搜图
            cboSearchShowAscii2dCount.SelectedIndex = BotInfo.SearchShowASCII2DCount - 1;

            chkSearchIqdbEnabled.Checked = BotInfo.SearchEnabledIqdb;
            chkSearch3dIqdbEnabled.Checked = BotInfo.SearchEnabled3dIqdb;
            chkSearchIqdbSendTags.Checked = BotInfo.SearchIqdbSendTags;
            chkSearchIqdbMustSafe.Checked = BotInfo.SearchIqdbMustSafe;
            txbSearchIqdbSimilarity.Text = BotInfo.SearchIqdbSimilarity.ToString();
            txbSearchIqdbSimilarityReply.Text = BotInfo.SearchIqdbSimilarityReply;

            txbSearchModeOnCmd.Text = BotInfo.SearchModeOnCmd;
            txbSearchAnimeModeOnCmd.Text = BotInfo.SearchAnimeModeOnCmd;
            txbSearch3DModeOnCmd.Text = BotInfo.Search3DModeOnCmd;
            txbSearchModeOffCmd.Text = BotInfo.SearchModeOffCmd;
            txbSearchModeTimeOutReply.Text = BotInfo.SearchModeTimeOutReply;
            txbSearchModeOnReply.Text = BotInfo.SearchModeOnReply;
            txbSearchModeAlreadyOnReply.Text = BotInfo.SearchModeAlreadyOnReply;
            txbSearchingReply.Text = BotInfo.SearchingReply;
            txbSearchModeOffReply.Text = BotInfo.SearchModeOffReply;
            txbSearchModeAlreadyOffReply.Text = BotInfo.SearchModeAlreadyOffReply;
            txbSearchNoResultReply.Text = BotInfo.SearchNoResultReply;
            txbSearchErrorReply.Text = BotInfo.SearchErrorReply;
            txbSearchSauceNAOLowSimilarityReply.Text = BotInfo.SearchSauceNAOLowSimilarityReply;
            txbSearchDownloadThuImageFailReply.Text = BotInfo.SearchDownloadThuImageFailReply;

            chkSearchCheckPornEnabled.Checked = BotInfo.SearchCheckPornEnabled;  //是否在搜图启用鉴黄
            txbSearchCheckPornIllegalReply.Text = BotInfo.SearchCheckPornIllegalReply;
            txbSearchCheckPornErrorReply.Text = BotInfo.SearchCheckPornErrorReply;

            chkASCII2DRequestByWebBrowser.Checked = BotInfo.ASCII2DRequestByWebBrowser;
            chkSauceNAORequestByWebBrowser.Checked = BotInfo.SauceNAORequestByWebBrowser;
            chkSearchSendByForward.Checked = BotInfo.SearchSendByForward;
        }

        public void SaveConfig()
        {
            BotInfo.PmAutoSearch = chkPmAutoSearch.Checked;

            BotInfo.SearchEnabledTraceMoe = chkSearchTraceMoeEnabled.Checked;  //是否启用TraceMoe搜番
            int iTraceMoeSendThreshold;
            if (!int.TryParse(txbTraceMoeSendThreshold.Text, out iTraceMoeSendThreshold))
                iTraceMoeSendThreshold = 87;
            BotInfo.TraceMoeSendThreshold = iTraceMoeSendThreshold;
            BotInfo.TraceMoeSendAdultThuImg = chkTraceMoeSendAdultThuImg.Checked;

            BotInfo.SearchEnabledSauceNAO = chkSearchSauceNAOEnabled.Checked;  //是否启用SauceNAO搜图
            BotInfo.SearchSauceNAOSortByDesc = chkSearchSauceNAOSortByDesc.Checked;
            BotInfo.SearchSauceNAOSendPixivOriginalPicture = chkSearchSauceNAOSendPixivOriginalPicture.Checked;
            BotInfo.SauceNAOApiKey = txbSearchSauceNAOApiKey.Text.Split("\r\n").ToList();
            int iLowSauceNAOSimilarity;
            if (!int.TryParse(txbSearchSauceNAOLowSimilarity.Text, out iLowSauceNAOSimilarity))
                iLowSauceNAOSimilarity = 60;
            BotInfo.SearchSauceNAOLowSimilarity = iLowSauceNAOSimilarity;  //低相似度阈值
            BotInfo.SearchSauceNAOLowSimilarityReply = txbSearchSauceNAOLowSimilarityReply.Text;
            int iHighSauceNAOSimilarity;
            if (!int.TryParse(txbSearchSauceNAOHighSimilarity.Text, out iHighSauceNAOSimilarity))
                iHighSauceNAOSimilarity = 90;
            BotInfo.SearchSauceNAOHighSimilarity = iHighSauceNAOSimilarity;  //高相似度阈值
            BotInfo.SauceNAORequestByWebBrowser = chkSauceNAORequestByWebBrowser.Checked;

            BotInfo.SearchEnabledASCII2D = chkSearchASCII2DEnabled.Checked;  //是否启用ASCII2D搜图
            BotInfo.SearchShowASCII2DCount = cboSearchShowAscii2dCount.SelectedIndex + 1;
            BotInfo.ASCII2DRequestByWebBrowser = chkASCII2DRequestByWebBrowser.Checked;

            BotInfo.SearchEnabledIqdb = chkSearchIqdbEnabled.Checked;
            BotInfo.SearchEnabled3dIqdb = chkSearch3dIqdbEnabled.Checked;
            BotInfo.SearchIqdbSendTags = chkSearchIqdbSendTags.Checked;
            BotInfo.SearchIqdbMustSafe = chkSearchIqdbMustSafe.Checked;
            BotInfo.SearchIqdbSimilarity = Convert.ToInt32(txbSearchIqdbSimilarity.Text);
            BotInfo.SearchIqdbSimilarityReply = txbSearchIqdbSimilarityReply.Text;

            BotInfo.SearchModeOnCmd = txbSearchModeOnCmd.Text;
            BotInfo.SearchAnimeModeOnCmd = txbSearchAnimeModeOnCmd.Text;
            BotInfo.Search3DModeOnCmd = txbSearch3DModeOnCmd.Text;
            BotInfo.SearchModeOffCmd = txbSearchModeOffCmd.Text;
            BotInfo.SearchModeTimeOutReply = txbSearchModeTimeOutReply.Text;
            BotInfo.SearchModeOnReply = txbSearchModeOnReply.Text;
            BotInfo.SearchModeAlreadyOnReply = txbSearchModeAlreadyOnReply.Text;
            BotInfo.SearchingReply = txbSearchingReply.Text;
            BotInfo.SearchModeOffReply = txbSearchModeOffReply.Text;
            BotInfo.SearchModeAlreadyOffReply = txbSearchModeAlreadyOffReply.Text;
            BotInfo.SearchNoResultReply = txbSearchNoResultReply.Text;
            BotInfo.SearchErrorReply = txbSearchErrorReply.Text;

            BotInfo.SearchDownloadThuImageFailReply = txbSearchDownloadThuImageFailReply.Text;
            BotInfo.SearchCheckPornEnabled = chkSearchCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.SearchCheckPornIllegalReply = txbSearchCheckPornIllegalReply.Text;
            BotInfo.SearchCheckPornErrorReply = txbSearchCheckPornErrorReply.Text;
            BotInfo.SearchSendByForward = chkSearchSendByForward.Checked;
        }

        public void UpdateCache()
        {
            foreach (string SauceNAOKey in txbSearchSauceNAOApiKey.Text.Split("\r\n"))
                Cache.SetSauceNAOKey(SauceNAOKey);
        }

        private void chkSearchSauceNAOEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchSauceNAO.Enabled = chkSearchSauceNAOEnabled.Checked;
        private void chkSearchASCII2DEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchAscii2d.Enabled = chkSearchASCII2DEnabled.Checked;
        private void chkSearchCheckPornEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchCheckPorn.Enabled = chkSearchCheckPornEnabled.Checked;
        private void chkSearchTraceMoeEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchTraceMoe.Enabled = chkSearchTraceMoeEnabled.Checked;
    }
}
