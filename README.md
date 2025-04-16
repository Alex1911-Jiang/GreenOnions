# GreenOnions

GreenOnions 是一个基于[Lagrange.Core](https://github.com/LagrangeDev/Lagrange.Core)的QQ机器人

[![QQ群](https://img.shields.io/badge/QQ群-550398174-blue.svg "QQ群")](https://jq.qq.com/?_wv=1027&k=rJ7RA3SF "QQ群")

本软件自身只有登录QQ和加载插件能力，不含任何业务功能，支持的业务功能请移步[插件仓库](https://github.com/Alex1911-Jiang/GreenOnions.Plugins)查看

### Windows食用指南：

1. 到[此处](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)下载并安装符合自己系统的.NET 8.0（.NET 运行时 或 SDK 都可以，但不要一起装）
2. 到[Release](https://github.com/Alex1911-Jiang/GreenOnions/releases)处下载最新的GreenOnions.NT.zip
3. 解压到任意目录并运行start.bat

### Linux食用指南（以Ubuntu为例）：

1. 请确保您的系统版本在20.04或更高，建议22.04起（20.04虽然能安装，但由于源中没有.Net 8.0安装包，所以您需要[手动安装.NET](https://learn.microsoft.com/zh-cn/dotnet/core/install/linux-scripted-manual)）
2. 输入 su root #切换到root用户
3. （22.04或更高版本的系统）输入：sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-8.0 #安装.NET
4. 输入：sudo apt install wget #安装下载器
5. 输入：sudo apt install unzip #安装解压软件
6. 输入：sudo apt install screen #安装命令行会话管理软件（云服务器都有预装这个软件，如果你使用的是云服务器或者安装了桌面，可以跳过这步）
7. 输入：mkdir GreenOnions #创建文件夹
8. 输入：cd GreenOnions #进入刚刚创建的文件夹
9. 到 [Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) 中复制最新版GreenOnions的下载地址
10. 输入：sudo wegt 下载地址 #替换成步骤9复制的地址
11. 输入：sudo unzip GreenOnions.NT.zip #解压
12. 输入：sh start.sh #启动GreenOnions（到这一步已经可以有限程度的运行了，但由于GreenOnions部分业务插件依赖Chromium，而Chromiun又必须在 **非root** 用户运行，所以还需要以下步骤创建并切换到一个低权限用户）
13. 按下：Ctrl+C #退出GreenOnions
14. 输入：sudo apt-get install -y ca-certificates fonts-liberation libappindicator3-1 libasound2 libatk-bridge2.0-0 libatk1.0-0 libc6 libcairo2 libcups2 libdbus-1-3 libexpat1 libfontconfig1 libgbm1 libgcc1 libglib2.0-0 libgtk-3-0 libnspr4 libnss3 libpango-1.0-0 libpangocairo-1.0-0 libstdc++6 libx11-6 libx11-xcb1 libxcb1 libxcomposite1 libxcursor1 libxdamage1 libxext6 libxfixes3 libxi6 libxrandr2 libxrender1 libxss1 libxtst6 lsb-release wget xdg-utils  #安装Chromium所需的依赖
15. 输入：cd .. #退到目录的上一层
16. 输入：chmod -R 777 GreenOnions #给文件夹设为允许低权限用户访问
17. 输入：sudo adduser 用户名 #添加用户
18. 根据指引输入新创建用户的密码
19. 输入：su 用户名 #切换到非root用户
20. 输入：cd GreenOnions #进入文件夹
21. 输入：sh start.sh #启动GreenOnions（到这一步您已经完整的启动了GreenOnions，但退出远程时GreenOnions会被关闭，所以您还需要使用screen托管（如果您安装了桌面并在桌面启动的终端，可以跳过以下所有步骤））
22. 按下：Ctrl+C #退出GreenOnions
23. 输入：screen -S GreenOnions #创建并切换到一个新会话中
24. 输入：sh start.sh #启动GreenOnion
    
大功告成，此时断开远程也不会导致GreenOnions被关闭了，接下来愉快的使用GreenOnions吧（您重新通过SSH连接到服务器后，可以使用：screen -r GreenOnions 切换到GreenOnions进程中）

### 一些在控制台常用的命令：

help：列出GreenOnions支持的命令

list-plugins：列出[插件仓库](https://github.com/Alex1911-Jiang/GreenOnions.Plugins)中所有可下载的插件

install-plugin 插件名称：下载并安装插件

reload-config：重读配置文件（包括插件的配置）

###### 至于为什么叫葱葱, ~~一是一开始是给某初音群用的, 叫这个名字可以打压某助手,~~ 二是早期没自己开发的时候使用 [cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot) 的机器人叫竹竹, 就想找个类似的名字

### TODO:
1. 移植旧GreenOnions的插件
2. 增加连接到OneBot而非内置登录的工作方式
3. 增加基于Avalonia的图形化启动器
4. 增加自动检查本体更新的功能
5. 添加一个Web启动器¿
