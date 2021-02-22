using System;
using System.Linq;

namespace GreenOnions.Utility.Helper
{
    public static class ConfigHelper
    {
        public static void ReadConfig()
        {
			#region -- 公共属性 --

			string strQQId = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.QQId));
			if (!string.IsNullOrWhiteSpace(strQQId))
				BotInfo.QQId = Convert.ToInt64(strQQId);
			string strIP = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.IP));
			if (!string.IsNullOrWhiteSpace(strIP))
				BotInfo.IP = strIP;
			string strPort = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.Port));
			if (!string.IsNullOrWhiteSpace(strPort))
				BotInfo.Port = strPort;
			string strAutoKey = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.AutoKey));
			if (!string.IsNullOrWhiteSpace(strAutoKey))
				BotInfo.AutoKey = strAutoKey;

			string strBotName = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.BotName));
			if (!string.IsNullOrWhiteSpace(strBotName))
				BotInfo.BotName = strBotName;
			string strAdmin = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.AdminQQ));
			if (!string.IsNullOrEmpty(strAdmin))
				BotInfo.AdminQQ = strAdmin.Split(';').Select(long.Parse).ToList();
			string strBannedGroup = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.BannedGroup));
			if (!string.IsNullOrEmpty(strBannedGroup))
				BotInfo.BannedGroup = strBannedGroup.Split(';').Select(long.Parse).ToList();
			string strBannedUser = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.BannedUser));
			if (!string.IsNullOrEmpty(strBannedUser))
				BotInfo.BannedUser = strBannedUser.Split(';').Select(long.Parse).ToList();
			string strImageCache = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameBot, nameof(BotInfo.ImageCache));
			if (!string.IsNullOrWhiteSpace(strImageCache))
				BotInfo.ImageCache = Convert.ToBoolean(strImageCache);
			#endregion -- 公共属性 --

			#region -- 搜图属性 --
			string strSearchEnabled = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchEnabled));
			if (!string.IsNullOrEmpty(strSearchEnabled))
				BotInfo.SearchEnabled = Convert.ToBoolean(strSearchEnabled);
			string strSearchEnabledSauceNao = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchEnabledSauceNao));
			if (!string.IsNullOrEmpty(strSearchEnabledSauceNao))
				BotInfo.SearchEnabledSauceNao = Convert.ToBoolean(strSearchEnabledSauceNao);
			string strSauceNAOApiKey = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SauceNAOApiKey));
			if (!string.IsNullOrEmpty(strSauceNAOApiKey))
				BotInfo.SauceNAOApiKey = strSauceNAOApiKey;
			string strSearchEnabledASCII2D = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchEnabledASCII2D));
			if (!string.IsNullOrEmpty(strSearchEnabledASCII2D))
				BotInfo.SearchEnabledASCII2D = Convert.ToBoolean(strSearchEnabledASCII2D);
			string strShabHPictureEndCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.ShabHPictureEndCmd));
			if (!string.IsNullOrEmpty(strShabHPictureEndCmd))
				BotInfo.ShabHPictureEndCmd = strShabHPictureEndCmd;
			string strShabHPictureEndCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.ShabHPictureEndCmdNull));
			if (!string.IsNullOrEmpty(strShabHPictureEndCmdNull))
				BotInfo.ShabHPictureEndCmdNull = Convert.ToBoolean(strShabHPictureEndCmdNull);
			string strSearchModeOnCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeOnCmd));
			if (!string.IsNullOrEmpty(strSearchModeOnCmd))
				BotInfo.SearchModeOnCmd = strSearchModeOnCmd;
			string strSearchModeOffCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeOffCmd));
			if (!string.IsNullOrEmpty(strSearchModeOffCmd))
				BotInfo.SearchModeOffCmd = strSearchModeOffCmd;
			string strSearchModeTimeOutReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeTimeOutReply));
			if (!string.IsNullOrEmpty(strSearchModeTimeOutReply))
				BotInfo.SearchModeTimeOutReply = strSearchModeTimeOutReply;
			string strSearchModeOnReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeOnReply));
			if (!string.IsNullOrEmpty(strSearchModeOnReply))
				BotInfo.SearchModeOnReply = strSearchModeOnReply;
			string strSearchModeAlreadyOnReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeAlreadyOnReply));
			if (!string.IsNullOrEmpty(strSearchModeAlreadyOnReply))
				BotInfo.SearchModeAlreadyOnReply = strSearchModeAlreadyOnReply;
			string strSearchModeOffReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeOffReply));
			if (!string.IsNullOrEmpty(strSearchModeOffReply))
				BotInfo.SearchModeOffReply = strSearchModeOffReply;
			string strSearchModeAlreadyOffReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchModeAlreadyOffReply));
			if (!string.IsNullOrEmpty(strSearchModeAlreadyOffReply))
				BotInfo.SearchModeAlreadyOffReply = strSearchModeAlreadyOffReply;
			string strSearchNoResultReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchNoResultReply));
			if (!string.IsNullOrEmpty(strSearchNoResultReply))
				BotInfo.SearchNoResultReply = strSearchNoResultReply;
			string strSearchErrorReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchErrorReply));
			if (!string.IsNullOrEmpty(strSearchErrorReply))
				BotInfo.SearchErrorReply = strSearchErrorReply;
			string strSearchLowSimilarity = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchLowSimilarity));
			if (!string.IsNullOrEmpty(strSearchLowSimilarity))
				BotInfo.SearchLowSimilarity = Convert.ToInt32(strSearchLowSimilarity);
			string strSearchLowSimilarityReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchLowSimilarityReply));
			if (!string.IsNullOrEmpty(strSearchLowSimilarityReply))
				BotInfo.SearchLowSimilarityReply = strSearchLowSimilarityReply;
			string strSearchCheckPornEnabled = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchCheckPornEnabled));
			if (!string.IsNullOrEmpty(strSearchCheckPornEnabled))
				BotInfo.SearchCheckPornEnabled = Convert.ToBoolean(strSearchCheckPornEnabled);
			string strSearchCheckPornIllegalReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchCheckPornIllegalReply));
			if (!string.IsNullOrEmpty(strSearchCheckPornIllegalReply))
				BotInfo.SearchCheckPornIllegalReply = strSearchCheckPornIllegalReply;
			string strSearchCheckPornErrorReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.SearchCheckPornErrorReply));
			if (!string.IsNullOrEmpty(strSearchCheckPornErrorReply))
				BotInfo.SearchCheckPornErrorReply = strSearchCheckPornErrorReply;

			#region -- 腾讯云相关属性 --
			string strTencentCloudAPPID = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.TencentCloudAPPID));
			if (!string.IsNullOrEmpty(strTencentCloudAPPID))
				BotInfo.TencentCloudAPPID = strTencentCloudAPPID;
			string strTencentCloudRegion = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.TencentCloudRegion));
			if (!string.IsNullOrEmpty(strTencentCloudRegion))
				BotInfo.TencentCloudRegion = strTencentCloudRegion;
			string strTencentCloudSecretId = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.TencentCloudSecretId));
			if (!string.IsNullOrEmpty(strTencentCloudSecretId))
				BotInfo.TencentCloudSecretId = strTencentCloudSecretId;
			string strTencentCloudSecretKey = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.TencentCloudSecretKey));
			if (!string.IsNullOrEmpty(strTencentCloudSecretKey))
				BotInfo.TencentCloudSecretKey = strTencentCloudSecretKey;
			string strTencentCloudBucket = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNamePictureSearcher, nameof(BotInfo.TencentCloudBucket));
			if (!string.IsNullOrEmpty(strTencentCloudBucket))
				BotInfo.TencentCloudBucket = strTencentCloudBucket;
			#endregion -- 腾讯云相关属性 --

			#endregion -- 搜图属性 --

			#region -- 色图属性 --
			string strHPictureEnabled = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureEnabled));
			if (!string.IsNullOrEmpty(strHPictureEnabled))
				BotInfo.HPictureEnabled = Convert.ToBoolean(strHPictureEnabled);
			string strEnabledLoliconDataBase = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.EnabledLoliconDataBase));
			if (!string.IsNullOrEmpty(strEnabledLoliconDataBase))
				BotInfo.EnabledLoliconDataBase = Convert.ToBoolean(strEnabledLoliconDataBase);
			string strEnabledShabDataBase = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.EnabledShabDataBase));
			if (!string.IsNullOrEmpty(strEnabledShabDataBase))
				BotInfo.EnabledShabDataBase = Convert.ToBoolean(strEnabledShabDataBase);
			string strHPictureApiKey = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureApiKey));
			if (!string.IsNullOrEmpty(strHPictureApiKey))
				BotInfo.HPictureApiKey = @strHPictureApiKey;
			string strHPictureBeginCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureBeginCmd));
			if (!string.IsNullOrEmpty(strHPictureBeginCmd))
				BotInfo.HPictureBeginCmd = strHPictureBeginCmd;
			string strHPictureCountCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureCountCmd));
			if (!string.IsNullOrEmpty(strHPictureCountCmd))
				BotInfo.HPictureCountCmd = @strHPictureCountCmd;
			string strHPictureUnitCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureUnitCmd));
			if (!string.IsNullOrEmpty(strHPictureUnitCmd))
				BotInfo.HPictureUnitCmd = @strHPictureUnitCmd;
			string strHPictureR18Cmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureR18Cmd));
			if (!string.IsNullOrEmpty(strHPictureR18Cmd))
				BotInfo.HPictureR18Cmd = @strHPictureR18Cmd;
			string strHPictureKeywordCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureKeywordCmd));
			if (!string.IsNullOrEmpty(strHPictureKeywordCmd))
				BotInfo.HPictureKeywordCmd = @strHPictureKeywordCmd;
			string strHPictureEndCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureEndCmd));
			if (!string.IsNullOrEmpty(strHPictureEndCmd))
				BotInfo.HPictureEndCmd = @strHPictureEndCmd;
			string strHPictureBeginCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureBeginCmdNull));
			if (!string.IsNullOrEmpty(strHPictureBeginCmdNull))
				BotInfo.HPictureBeginCmdNull = Convert.ToBoolean(strHPictureBeginCmdNull);
			string strHPictureCountCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureCountCmdNull));
			if (!string.IsNullOrEmpty(strHPictureCountCmdNull))
				BotInfo.HPictureCountCmdNull = Convert.ToBoolean(strHPictureCountCmdNull);
			string strUnitCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureUnitCmdNull));
			if (!string.IsNullOrEmpty(strUnitCmdNull))
				BotInfo.HPictureUnitCmdNull = Convert.ToBoolean(strUnitCmdNull);
			string strHPictureR18CmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureR18CmdNull));
			if (!string.IsNullOrEmpty(strHPictureR18CmdNull))
				BotInfo.HPictureR18CmdNull = Convert.ToBoolean(strHPictureR18CmdNull);
			string strHPictureKeywordCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureKeywordCmdNull));
			if (!string.IsNullOrEmpty(strHPictureKeywordCmdNull))
				BotInfo.HPictureKeywordCmdNull = Convert.ToBoolean(strHPictureKeywordCmdNull);
			string strHPictureEndCmdNull = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureEndCmdNull));
			if (!string.IsNullOrEmpty(strHPictureEndCmdNull))
				BotInfo.HPictureEndCmdNull = Convert.ToBoolean(strHPictureEndCmdNull);
			string strHPictureUserCmd = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureUserCmd));
			if (!string.IsNullOrEmpty(strHPictureUserCmd))
				BotInfo.HPictureUserCmd = strHPictureUserCmd.Split(';').ToList();
			string strHPictureWhiteGroup = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureWhiteGroup));
			if (!string.IsNullOrEmpty(strHPictureWhiteGroup))
				BotInfo.HPictureWhiteGroup = strHPictureWhiteGroup.Split(';').Select(long.Parse).ToList();
			string strHPictureWhiteOnly = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureWhiteOnly));
			if (!string.IsNullOrEmpty(strHPictureWhiteOnly))
				BotInfo.HPictureWhiteOnly = Convert.ToBoolean(strHPictureWhiteOnly);
			string strHPictureR18 = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureAllowR18));
			if (!string.IsNullOrEmpty(strHPictureR18))
				BotInfo.HPictureAllowR18 = Convert.ToBoolean(strHPictureR18);
			string strHPictureR18WhiteOnly = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureR18WhiteOnly));
			if (!string.IsNullOrEmpty(strHPictureR18WhiteOnly))
				BotInfo.HPictureR18WhiteOnly = Convert.ToBoolean(strHPictureR18WhiteOnly);
			string strHPictureAllowPM = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureAllowPM));
			if (!string.IsNullOrEmpty(strHPictureAllowPM))
				BotInfo.HPictureAllowPM = Convert.ToBoolean(strHPictureAllowPM);
			string strHPictureAntiShielding = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureAntiShielding));
			if (!string.IsNullOrEmpty(strHPictureAntiShielding))
				BotInfo.HPictureAntiShielding = Convert.ToBoolean(strHPictureAntiShielding);
			string strHPictureSize1200 = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureSize1200));
			if (!string.IsNullOrEmpty(strHPictureSize1200))
				BotInfo.HPictureSize1200 = Convert.ToBoolean(strHPictureSize1200);
			string strHPictureAccelerate = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.EnabledAccelerate));
			if (!string.IsNullOrEmpty(strHPictureAccelerate))
				BotInfo.EnabledAccelerate = Convert.ToBoolean(strHPictureAccelerate);
			string strHPictureAccelerateUrl = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.AccelerateUrl));
			if (!string.IsNullOrEmpty(strHPictureAccelerateUrl))
				BotInfo.AccelerateUrl = strHPictureAccelerateUrl;
			string strHPictureCD = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureCD));
			if (!string.IsNullOrEmpty(strHPictureCD))
				BotInfo.HPictureCD = Convert.ToInt32(strHPictureCD);
			string strHPictureRevoke = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureRevoke));
			if (!string.IsNullOrEmpty(strHPictureRevoke))
				BotInfo.HPictureRevoke = Convert.ToInt32(strHPictureRevoke);
			string strHPictureWhiteCD = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureWhiteCD));
			if (!string.IsNullOrEmpty(strHPictureWhiteCD))
				BotInfo.HPictureWhiteCD = Convert.ToInt32(strHPictureWhiteCD);
			string strHPictureWhiteRevoke = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureWhiteRevoke));
			if (!string.IsNullOrEmpty(strHPictureWhiteRevoke))
				BotInfo.HPictureWhiteRevoke = Convert.ToInt32(strHPictureWhiteRevoke);
			string strHPicturePMCD = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPicturePMCD));
			if (!string.IsNullOrEmpty(strHPicturePMCD))
				BotInfo.HPicturePMCD = Convert.ToInt32(strHPicturePMCD);
			string strHPicturePMRevoke = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPicturePMRevoke));
			if (!string.IsNullOrEmpty(strHPicturePMRevoke))
				BotInfo.HPicturePMRevoke = Convert.ToInt32(strHPicturePMRevoke);
			string strHPicturePMNoLimit = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPicturePMNoLimit));
			if (!string.IsNullOrEmpty(strHPicturePMNoLimit))
				BotInfo.HPicturePMNoLimit = Convert.ToBoolean(strHPicturePMNoLimit);
			string strHPictureAdminNoLimit = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureAdminNoLimit));
			if (!string.IsNullOrEmpty(strHPictureAdminNoLimit))
				BotInfo.HPictureAdminNoLimit = Convert.ToBoolean(strHPictureAdminNoLimit);
			string strHPictureManageNoLimit = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureManageNoLimit));
			if (!string.IsNullOrEmpty(strHPictureManageNoLimit))
				BotInfo.HPictureManageNoLimit = Convert.ToBoolean(strHPictureManageNoLimit);
			string strHPictureLimit = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureLimit));
			if (!string.IsNullOrEmpty(strHPictureLimit))
				BotInfo.HPictureLimit = Convert.ToInt32(strHPictureLimit);
			string strHPictureCDUnreadyReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureCDUnreadyReply));
			if (!string.IsNullOrEmpty(strHPictureCDUnreadyReply))
				BotInfo.HPictureCDUnreadyReply = strHPictureCDUnreadyReply;
			string strHPictureOutOfLimitReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureOutOfLimitReply));
			if (!string.IsNullOrEmpty(strHPictureOutOfLimitReply))
				BotInfo.HPictureOutOfLimitReply = strHPictureOutOfLimitReply;
			string strHPictureErrorReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureErrorReply));
			if (!string.IsNullOrEmpty(strHPictureErrorReply))
				BotInfo.HPictureErrorReply = strHPictureErrorReply;
			string strHPictureNoResultReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureNoResultReply));
			if (!string.IsNullOrEmpty(strHPictureNoResultReply))
				BotInfo.HPictureNoResultReply = strHPictureNoResultReply;
			string strHPictureDownloadFailReply = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureDownloadFailReply));
			if (!string.IsNullOrEmpty(strHPictureDownloadFailReply))
				BotInfo.HPictureDownloadFailReply = strHPictureDownloadFailReply;
			string strHPictureLimitType = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureLimitType));
			if (!string.IsNullOrEmpty(strHPictureLimitType))
				BotInfo.HPictureLimitType = (LimitType)Enum.Parse(typeof(LimitType), strHPictureLimitType);
			string strHPictureWhiteNoLimit = JsonHelper.GetSerializationValue(Cache.JsonConfigFileName, BotInfo.JsonNodeNameHPicture, nameof(BotInfo.HPictureWhiteNoLimit));
			if (!string.IsNullOrEmpty(strHPictureWhiteNoLimit))
				BotInfo.HPictureWhiteNoLimit = Convert.ToBoolean(strHPictureWhiteNoLimit);
			#endregion -- 色图属性 --

		}
	}
}
