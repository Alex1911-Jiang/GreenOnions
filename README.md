# GreenOnions

### 关于本项目

#### 这是一个 [mirai](https://github.com/mamoe/mirai) 平台的QQ机器人, 使用 [Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp) 开发, 实现了搜图, 翻译, setu RSS订阅转发等功能<br>
#### 搜图和setu功能设计思路参考自 [cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot) <br>

### 项目优势:

1.带Windows图形界面, 没有开发基础也可以傻瓜式配置<br>
2.多平台兼容, .Net5能装的平台都能运行(当然非Windows就没有图形界面了)<br>
3.搜图功能可配置接入腾讯云鉴黄, 可以有效避免被内鬼炸号炸群, 尤其是Ascii2D乱开车的时候<br>
4.搜图功能会尝试自动下载原图发送<br>
5.支持一句命令多张setu, 支持限制QQ号调用次数和频率, 支持定时撤回, 支持配置返回语等<br>
6.支持配置以合并转发的方式发送消息，防止不可描述的图片炸号

### Windows食用方法(傻瓜版):

#### 一、环境配置:

1.首先确保你的系统是 Windows 10 1607或更高版本/Windows 8.1/Windows7 Sp1并安装了KB2533623补丁<br>
2.(如果你的系统是Win11或者Win10 21H1以上可以跳过这步)到 [.Net5官网](https://dotnet.microsoft.com/download/dotnet/5.0) 找到.NET Desktop Runtime下载对应自己系统架构的Installers版本安装<br>
3.到 [OpenJDK官网](http://jdk.java.net/) 下载 OpenJDK 尽量选择高版本的下<br>
4.将OpenJDK解压到C:\Program Files\Java文件夹下, 呈C:\Program Files\Java\jdk-xx.x路径形式(x为版本号)<br>
5.打开 算机属性-高级系统设置-高级-环境变量 在下方系统变量栏中新建一项 变量"JAVA_HOME" 值"C:\Program Files\Java\jdk-xx.x" (不包括引号,x为版本号)<br>
6.编辑系统变量Path, 添加一项"%JAVA_HOME%\bin"<br>

#### 二、安装机器人框架(注意不能和Go通用)

1.到 [mirai-console-loader/releases](https://github.com/iTXTech/mirai-console-loader/releases) 下载MCL (尽量选择不带beta的最新版, 下载.zip结尾的那个)<br>
2.通过MCL安装 [mirai-api-http](https://github.com/project-mirai/mirai-api-http)<br>
3.打开MCL目录\config\net.mamoe.mirai-api-http\setting.yml文件, 修改 host: '127.0.0.1' port: 33111 verifyKey: Alex1911<br>
4.回到MCL窗口, 输入\login 机器人QQ号 密码 登录<br>

#### 三、安装本项目

1.到 [Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) 下载本项目的发行版本, 找最新的net5.0-windows.zip下<br>
2.解压到任意目录, 运行GreenOnions.BotManagerWindow.exe<br>
3.输入机器人QQ号和和setting.yml对应的ip(host)、端口(port)和VerifyKey, 点击连接到mirai-api-http<br>

#### 大功告成

如果你想部署到其他系统说明你已经不是一个小白了, 那我能告诉你的只有运行命令是"dotnet GreenOnions.BotManagerConsole.dll"<br>

### 功能介绍

- [x] 1.[SauceNao](https://saucenao.com/) 搜图<br>
- [x] 2.[ascii2d](https://ascii2d.net/) 搜图<br>
- [x] 3.[trace.moe](https://trace.moe/) 搜番<br>
- [x] 4.[lolicon](https://api.lolicon.app/#/setu) setu<br>
- [x] 5.群友 [Quan](https://github.com/Quan666) 的 [ELF图库](http://img.shab.fun:5000/) 美图<br>
- [x] 6.[GoogleTranslateFreeApi](https://github.com/wadereye/GoogleTranslateFreeApi) 翻译<br>
- [x] 7.随机复读, 连续复读, 镜像复读图片和倒带gif(可配置触发几率)<br>
- [x] 8.新人入群/退群/被踢提醒(支持定义)<br>
- [x] 9.RSS订阅转发<br>
- [x] 10.下载Pixiv原图(通过[pixiv.cat](https://pixiv.cat/))<br>

###### 至于为什么叫葱葱, 一是一开始是给某初音群用的, 叫这个名字可以打压某助手, 二是早期没自己开发的时候使用 [cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot) 的机器人叫竹竹, 就想找个类似的名字<br>

### 短期计划(TODO):

1.通过消息配置属性<br>
2.为Console端添加命令配置属性和属性中文注释

### 长期计划(GUDO):

1.适配Mirai-Go平台
