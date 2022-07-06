﻿namespace GreenOnions.Interface
{
    /// <summary>
    /// 插件接口
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 插件描述信息
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// 加载控件成功时触发
        /// </summary>
        /// <param name="pluginPath">传入插件所在目录, 插件配置项尽量存放在此目录, 避免使用机器人目录</param>
        public void OnLoad(string pluginPath);

        /// <summary>
        /// 机器人连接到平台时触发
        /// </summary>
        /// <param name="selfId">登录的机器人QQ号</param>
        /// <param name="SendFriendMessage">发送好友消息方法(好友QQ号, 消息体, 返回发送后的消息id)</param>
        /// <param name="SendGroupMessage">发送群消息方法(群号, 消息体, 返回发送后的消息id)</param>
        /// <param name="SendTempMessage">发送临时消息方法(目标QQ号, 群号, 消息体, 返回发送后的消息id)</param>
        public void OnConnected(long selfId, Func<long, GreenOnionsMessages, Task<int>> SendFriendMessage, Func<long, GreenOnionsMessages, Task<int>> SendGroupMessage, Func<long, long, GreenOnionsMessages, Task<int>> SendTempMessage);

        /// <summary>
        /// 机器人主动断开平台连接时触发
        /// </summary>
        public void OnDisconnected();

        /// <summary>
        /// 接收到消息时触发
        /// </summary>
        /// <param name="msgs">收到的消息</param>
        /// <param name="senderGroup">消息来自的群号, 私聊消息时为空</param>
        /// <param name="Response">回发消息的方法(消息体)</param>
        /// <returns>返回是否中断消息链的向后传递</returns>
        public bool OnMessage(GreenOnionsMessages msgs, long? senderGroup, Action<GreenOnionsMessages> Response);

        /// <summary>
        /// 在Console端设置该插件时触发
        /// </summary>
        public void ConsoleSetting();

        /// <summary>
        /// 在Windows端设置该插件时触发
        /// </summary>
        /// <returns>返回Windows是否已处理设置的调用(当插件有设计Windows设置界面时应当返回True, 如果返回False则会调用Console设置)</returns>
        public bool WindowSetting();
    }
}