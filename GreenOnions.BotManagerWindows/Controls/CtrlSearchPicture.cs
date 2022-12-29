using System.Diagnostics;
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
            chkPmAutoSearch.Checked = BotInfo.Config.PmAutoSearch;

            chkSearchSendThuImage.Checked = BotInfo.Config.SearchSendThuImage;

            chkSearchTraceMoeEnabled.Checked = BotInfo.Config.SearchEnabledTraceMoe;  //是否启用TraceMoe搜番
            txbTraceMoeSendThreshold.Text = BotInfo.Config.TraceMoeSendThreshold.ToString();
            chkTraceMoeSendAdultThuImg.Checked = BotInfo.Config.TraceMoeSendAdultThuImg;

            chkSearchSauceNAOEnabled.Checked = BotInfo.Config.SearchEnabledSauceNAO;  //SauceNAO Api-Key
            chkSearchSauceNAOSortByDesc.Checked = BotInfo.Config.SearchSauceNAOSortByDesc;
            chkSearchSauceNAOSendPixivOriginalPicture.Checked = BotInfo.Config.SearchSauceNAOSendPixivOriginalPicture;
            txbSearchSauceNAOApiKey.Text = string.Join("\r\n", BotInfo.Config.SauceNAOApiKey);
            txbSearchSauceNAOLowSimilarity.Text = BotInfo.Config.SearchSauceNAOLowSimilarity.ToString();
            txbSearchSauceNAOHighSimilarity.Text = BotInfo.Config.SearchSauceNAOHighSimilarity.ToString();

            chkSearchASCII2DEnabled.Checked = BotInfo.Config.SearchEnabledASCII2D;  //是否启用ASCII2D搜图
            cboSearchShowAscii2dCount.SelectedIndex = BotInfo.Config.SearchShowASCII2DCount - 1;

            chkSearchIqdbEnabled.Checked = BotInfo.Config.SearchEnabledIqdb;
            chkSearch3dIqdbEnabled.Checked = BotInfo.Config.SearchEnabled3dIqdb;
            chkSearchIqdbSendTags.Checked = BotInfo.Config.SearchIqdbSendTags;
            chkSearchIqdbMustSafe.Checked = BotInfo.Config.SearchIqdbMustSafe;
            txbSearchIqdbSimilarity.Text = BotInfo.Config.SearchIqdbSimilarity.ToString();
            txbSearchIqdbSimilarityReply.Text = BotInfo.Config.SearchIqdbSimilarityReply;

            txbSearchModeOnCmd.Text = BotInfo.Config.SearchModeOnCmd;
            txbSearchAnimeModeOnCmd.Text = BotInfo.Config.SearchAnimeModeOnCmd;
            txbSearch3DModeOnCmd.Text = BotInfo.Config.Search3DModeOnCmd;
            txbSearchModeOffCmd.Text = BotInfo.Config.SearchModeOffCmd;
            txbSearchModeTimeOutReply.Text = BotInfo.Config.SearchModeTimeOutReply;
            txbSearchModeOnReply.Text = BotInfo.Config.SearchModeOnReply;
            txbSearchModeAlreadyOnReply.Text = BotInfo.Config.SearchModeAlreadyOnReply;
            txbSearchingReply.Text = BotInfo.Config.SearchingReply;
            txbSearchModeOffReply.Text = BotInfo.Config.SearchModeOffReply;
            txbSearchModeAlreadyOffReply.Text = BotInfo.Config.SearchModeAlreadyOffReply;
            txbSearchNoResultReply.Text = BotInfo.Config.SearchNoResultReply;
            txbSearchErrorReply.Text = BotInfo.Config.SearchErrorReply;
            txbSearchSauceNAOLowSimilarityReply.Text = BotInfo.Config.SearchSauceNAOLowSimilarityReply;
            txbSearchDownloadThuImageFailReply.Text = BotInfo.Config.SearchDownloadThuImageFailReply;

            chkSearchCheckPornEnabled.Checked = BotInfo.Config.SearchCheckPornEnabled;  //是否在搜图启用鉴黄
            txbSearchCheckPornIllegalReply.Text = BotInfo.Config.SearchCheckPornIllegalReply;
            txbSearchCheckPornErrorReply.Text = BotInfo.Config.SearchCheckPornErrorReply;

            chkASCII2DRequestByWebBrowser.Checked = BotInfo.Config.ASCII2DRequestByWebBrowser;
            chkSauceNAORequestByWebBrowser.Checked = BotInfo.Config.SauceNAORequestByWebBrowser;
            chkSearchSendByForward.Checked = BotInfo.Config.SearchSendByForward;
        }

        public void SaveConfig()
        {
            BotInfo.Config.PmAutoSearch = chkPmAutoSearch.Checked;

            BotInfo.Config.SearchSendThuImage = chkSearchSendThuImage.Checked;

            BotInfo.Config.SearchEnabledTraceMoe = chkSearchTraceMoeEnabled.Checked;  //是否启用TraceMoe搜番
            int iTraceMoeSendThreshold;
            if (!int.TryParse(txbTraceMoeSendThreshold.Text, out iTraceMoeSendThreshold))
                iTraceMoeSendThreshold = 87;
            BotInfo.Config.TraceMoeSendThreshold = iTraceMoeSendThreshold;
            BotInfo.Config.TraceMoeSendAdultThuImg = chkTraceMoeSendAdultThuImg.Checked;

            BotInfo.Config.SearchEnabledSauceNAO = chkSearchSauceNAOEnabled.Checked;  //是否启用SauceNAO搜图
            BotInfo.Config.SearchSauceNAOSortByDesc = chkSearchSauceNAOSortByDesc.Checked;
            BotInfo.Config.SearchSauceNAOSendPixivOriginalPicture = chkSearchSauceNAOSendPixivOriginalPicture.Checked;
            BotInfo.Config.SauceNAOApiKey = txbSearchSauceNAOApiKey.Text.Split("\r\n").ToHashSet();
            int iLowSauceNAOSimilarity;
            if (!int.TryParse(txbSearchSauceNAOLowSimilarity.Text, out iLowSauceNAOSimilarity))
                iLowSauceNAOSimilarity = 60;
            BotInfo.Config.SearchSauceNAOLowSimilarity = iLowSauceNAOSimilarity;  //低相似度阈值
            BotInfo.Config.SearchSauceNAOLowSimilarityReply = txbSearchSauceNAOLowSimilarityReply.Text;
            int iHighSauceNAOSimilarity;
            if (!int.TryParse(txbSearchSauceNAOHighSimilarity.Text, out iHighSauceNAOSimilarity))
                iHighSauceNAOSimilarity = 90;
            BotInfo.Config.SearchSauceNAOHighSimilarity = iHighSauceNAOSimilarity;  //高相似度阈值
            BotInfo.Config.SauceNAORequestByWebBrowser = chkSauceNAORequestByWebBrowser.Checked;

            BotInfo.Config.SearchEnabledASCII2D = chkSearchASCII2DEnabled.Checked;  //是否启用ASCII2D搜图
            BotInfo.Config.SearchShowASCII2DCount = cboSearchShowAscii2dCount.SelectedIndex + 1;
            BotInfo.Config.ASCII2DRequestByWebBrowser = chkASCII2DRequestByWebBrowser.Checked;

            BotInfo.Config.SearchEnabledIqdb = chkSearchIqdbEnabled.Checked;
            BotInfo.Config.SearchEnabled3dIqdb = chkSearch3dIqdbEnabled.Checked;
            BotInfo.Config.SearchIqdbSendTags = chkSearchIqdbSendTags.Checked;
            BotInfo.Config.SearchIqdbMustSafe = chkSearchIqdbMustSafe.Checked;
            BotInfo.Config.SearchIqdbSimilarity = Convert.ToInt32(txbSearchIqdbSimilarity.Text);
            BotInfo.Config.SearchIqdbSimilarityReply = txbSearchIqdbSimilarityReply.Text;

            BotInfo.Config.SearchModeOnCmd = txbSearchModeOnCmd.Text;
            BotInfo.Config.SearchAnimeModeOnCmd = txbSearchAnimeModeOnCmd.Text;
            BotInfo.Config.Search3DModeOnCmd = txbSearch3DModeOnCmd.Text;
            BotInfo.Config.SearchModeOffCmd = txbSearchModeOffCmd.Text;
            BotInfo.Config.SearchModeTimeOutReply = txbSearchModeTimeOutReply.Text;
            BotInfo.Config.SearchModeOnReply = txbSearchModeOnReply.Text;
            BotInfo.Config.SearchModeAlreadyOnReply = txbSearchModeAlreadyOnReply.Text;
            BotInfo.Config.SearchingReply = txbSearchingReply.Text;
            BotInfo.Config.SearchModeOffReply = txbSearchModeOffReply.Text;
            BotInfo.Config.SearchModeAlreadyOffReply = txbSearchModeAlreadyOffReply.Text;
            BotInfo.Config.SearchNoResultReply = txbSearchNoResultReply.Text;
            BotInfo.Config.SearchErrorReply = txbSearchErrorReply.Text;

            BotInfo.Config.SearchDownloadThuImageFailReply = txbSearchDownloadThuImageFailReply.Text;
            BotInfo.Config.SearchCheckPornEnabled = chkSearchCheckPornEnabled.Checked;  //是否在搜图启用鉴黄
            BotInfo.Config.SearchCheckPornIllegalReply = txbSearchCheckPornIllegalReply.Text;
            BotInfo.Config.SearchCheckPornErrorReply = txbSearchCheckPornErrorReply.Text;
            BotInfo.Config.SearchSendByForward = chkSearchSendByForward.Checked;
        }

        public void UpdateCache()
        {
            foreach (string SauceNAOKey in txbSearchSauceNAOApiKey.Text.Split("\r\n"))
                BotInfo.Cache.SetSauceNAOKey(SauceNAOKey);
        }

        private void SearchSauceNAOEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchSauceNAO.Enabled = chkSearchSauceNAOEnabled.Checked;
        private void SearchASCII2DEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchAscii2d.Enabled = chkSearchASCII2DEnabled.Checked;
        private void SearchCheckPornEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchCheckPorn.Enabled = chkSearchCheckPornEnabled.Checked;
        private void SearchTraceMoeEnabled_CheckedChanged(object sender, EventArgs e) => pnlSearchTraceMoe.Enabled = chkSearchTraceMoeEnabled.Checked;
        private void SearchSauceNAORequestKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("explorer.exe", "https://saucenao.com/user.php?page=search-api");
    }
}
