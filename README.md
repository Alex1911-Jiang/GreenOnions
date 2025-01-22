# GreenOnions

GreenOnions 是一个基于[Lagrange.Core](https://github.com/LagrangeDev/Lagrange.Core)的QQ机器人

本软件自身只有登录QQ和加载插件能力，不含任何业务功能，支持的业务功能请移步[插件仓库](https://github.com/Alex1911-Jiang/GreenOnions.Plugins)查看

### Windows食用指南：

1. 到[此处](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0)下载并安装符合自己系统的.NET 8.0（.NET 运行时 或 SDK 都可以，但不要一起装）
2. 到[Release](https://github.com/Alex1911-Jiang/GreenOnions/releases)处下载最新的GreenOnions.NT.zip
3. 解压到任意目录并运行start.bat

### Linux食用指南（以Ubuntu为例）：

1. 请确保您的系统版本在20.04或更高，建议22.04起（20.04虽然能安装，但由于源中没有.Net 8.0安装包，所以您需要[手动安装.NET](https://learn.microsoft.com/zh-cn/dotnet/core/install/linux-scripted-manual)）
2. 输入 su root #切换到root用户
3. （22.04或更高版本的系统）输入：sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-9.0 #安装.NET
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
14. 输入：cd .. #退到目录的上一层
15. 输入：sudo chmod -R 777 GreenOnions #给文件夹设为允许低权限用户访问
16. 输入：sudo adduser 用户名 #添加用户
17. 根据指引输入新创建用户的密码
18. 输入：su 用户名 #切换到非root用户
19. 输入：cd GreenOnions #进入文件夹
20. 输入：sh start.sh #启动GreenOnions（到这一步您已经完整的启动了GreenOnions，但退出远程时GreenOnions会被关闭，所以您还需要使用screen托管（如果您安装了桌面并在桌面启动的终端，可以跳过以下所有步骤））
21. 按下：Ctrl+C #退出GreenOnions
22. 输入：screen -S GreenOnions #创建并切换到一个新会话中
23. 输入：sh start.sh #启动GreenOnion
    
大功告成，此时断开远程也不会导致GreenOnions被关闭了，接下来愉快的使用GreenOnions吧（您重新通过SSH连接到服务器后，可以使用：screen -r GreenOnions 切换到GreenOnions进程中）
