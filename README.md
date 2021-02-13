# GreenOnions



### 关于本项目

#### 这是一个依赖于[mirai](https://github.com/mamoe/mirai)的QQ机器人, 使用[Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp)开发, 实现了搜图, 翻译, setu等功能

搜图功能模仿自[cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot), 目前实现了SauceNao和Ascii2D搜图

翻译功能通过[GoogleTranslateFreeApi](https://github.com/wadereye/GoogleTranslateFreeApi)实现

色图功能实现自 https://api.lolicon.app/ 的接口 ~~(自己的接口也建好了, 主要是没图)~~

至于为什么叫葱葱, 一是一开始是给某初音群用的, 叫这个名字可以打压某助手, 二是早期没自己开发的时候使用[cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot)的机器人叫竹竹, 就想找个类似的名字

#### 食用方法

安装[mirai](https://github.com/mamoe/mirai)和[mirai-api-http](https://github.com/project-mirai/mirai-api-http), 配置相关host参数, 运行本软件

win10x64用户建议使用GreenOnions.BotManagerWindow, 带有图形界面, 其他系统使用GreenOnions.BotManagerConsole(理论支持linux但我没试过)

配置config.json修改消息命令、返回消息和功能权限


#### TODO
1.目前只实现了群消息, 下一步先把私聊加上
2.把图片本地缓存加上, 降低网络压力
3.实现[whatanime](https://trace.moe/)搜番
4.研究RSSHUB看看能不能实现文章转发功能
