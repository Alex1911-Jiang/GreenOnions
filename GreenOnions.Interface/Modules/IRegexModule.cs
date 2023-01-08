using System.Text.RegularExpressions;

namespace GreenOnions.Interface.Modules
{
    /// <summary>
    /// 葱葱本体功能的模块接口，插件不应该实现该接口
    /// </summary>
    public interface IRegexModule
    {
        protected Regex ModuleRegex { get; }
        public void UpdateRegex();
        public Task<bool> HandleMessageAsync(GreenOnionsMessages msgs, long? targetGroupId);
        protected Task SendMessageAsync(long targetId, long? targetGroup, GreenOnionsMessages msgs, int? replyMsgId = null);
    }
}
