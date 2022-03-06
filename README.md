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
7.RSS转发功能有控件配置，可方便添加删除和设置翻译

### Windows食用方法(傻瓜版):

#### 一、环境配置:

1.首先确保你的系统是 Windows 10 1607或更高版本/Windows 8.1/Windows7 Sp1并安装了KB2533623补丁<br>
2.(如果你的系统是Win11或者Win10 21H1以上可以跳过这步)到 [.Net5官网](https://dotnet.microsoft.com/download/dotnet/5.0) 找到.NET Desktop Runtime下载对应自己系统架构的Installers版本安装<br>
3.到 [OpenJDK官网](http://jdk.java.net/) 下载 OpenJDK 尽量选择高版本的下<br>
4.将OpenJDK解压到C:\Program Files\Java文件夹下, 呈C:\Program Files\Java\jdk-xx.x路径形式(x为版本号)<br>
5.打开 算机属性-高级系统设置-高级-环境变量 在下方系统变量栏中新建一项 变量"JAVA_HOME" 值"C:\Program Files\Java\jdk-xx.x" (不包括引号,x为版本号)<br>
6.编辑系统变量Path, 添加一项"%JAVA_HOME%\bin"<br>

#### 二、安装机器人框架(注意不能和Go通用)

1.到 [mirai-console-loader/releases](https://github.com/iTXTech/mirai-console-loader/releases) 下载MCL (尽量选择不带beta的最新版, .zip结尾的那个)<br>
2.通过MCL安装 [mirai-api-http](https://github.com/project-mirai/mirai-api-http)<br>
3.在MCL上运行一次 .\mcl 以确保配置文件成功创建, 随后按Ctrl+C退出
4.拷贝 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 底下的setting.yml模板到 MCL目录\config\net.mamoe.mirai-api-http\setting.yml 文件中
5.打开 MCL目录\config\net.mamoe.mirai-api-http\setting.yml 文件, 修改 http和ws: 下的 host: 127.0.0.1 port: 33111 verifyKey: Alex1911<br>
6.回到MCL窗口, 重新输入一次.\mcl 再输入\login 机器人QQ号 密码 登录<br>

#### 三、安装本项目

1.到 [Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) 下载本项目的发行版本, 找最新的 win-x86x64-windows.zip 下<br>
2.解压到任意目录, 运行 GreenOnions.BotManagerWindow.exe<br>
3.输入机器人QQ号和和 setting.yml 对应 的ip(host)、端口(port)和 VerifyKey, 点击连接到 mirai-api-http<br>

#### 大功告成

### Linux食用方法(Ubuntu为例):
0.(可选)建议先更换服务器所在地区的源并 sudo apt update<br>
1.输入 sudo apt install openjdk-17-jdk-headless #安装Java依赖<br>
2.输入 sudo apt install unzip #安装解压zip的库<br>
3.输入 wget https://packages.microsoft.com/config/ubuntu/00.00/packages-microsoft-prod.deb -O packages-microsoft-prod.deb #下载 .Net 依赖包(00.00替换为自己系统的版本, 详见:[在 Linux 上安装.Net](https://docs.microsoft.com/zh-cn/dotnet/core/install/))<br>
4.输入 sudo dpkg -i packages-microsoft-prod.deb #安装 .Net 依赖<br>
　4.1.(可选)输入 rm packages-microsoft-prod.deb #删除已经安装完的依赖包<br>
5.安装Mono图形库:<br>
　5.1.输入 sudo apt install gnupg ca-certificates<br>
　5.2.输入 sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF<br>
　5.3.输入 echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list<br>
　5.4.输入 sudo apt update (其他Linux发行版详见: [Mono](https://www.mono-project.com/download/stable/#download-lin))<br>
6.安装 [mirai](https://github.com/mamoe/mirai) (这里的例子为 [Mirai Console Loader](https://github.com/iTXTech/mirai-console-loader))<br>
　6.1.到 [mcl/Release](https://github.com/iTXTech/mirai-console-loader/releases) 里复制最新的zip包下载地址<br>
　6.2.输入 wget 地址 #下载mcl 例如: wget https://github.com/iTXTech/mirai-console-loader/releases/download/v1.2.2/mcl-1.2.2.zip<br>
　6.3.输入 unzip mcl-1.2.2.zip #解压(文件名按下载到的来写)<br>
　6.4.(可选:如果步骤7提示 Permission denied 请回来执行一次该步骤) 输入 sudo chmod 777 mcl #设置权限再重新执行步骤7<br>
7.安装 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 通信插件<br>
　7.1.输入 ./mcl --update-package net.mamoe:mirai-api-http --channel stable-v2 --type plugin #(地址可能会随着更新改变, 以 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 中的说明为准)<br>
　7.2.输入 ./mcl #首次启动 [mirai](https://github.com/mamoe/mirai) 创建配置文件<br>
　7.3.当配置完成后, 按Ctrl+C停止运行<br>
　7.5.到 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 复制setting.yml模板<br>
　7.4.输入 sudo vim config/net.mamoe.mirai-api-http/setting.yml #使用Vim(或其他工具)编辑配置文件<br>
　7.5.粘贴复制的模板并修改 ws: 下的 host: '127.0.0.1' port: 33111 verifyKey: Alex1911<br>
　7.6.按Esc退出编辑模式并输入 :wq! 保存配置文件<br>
8.登录机器人QQ:<br>
　8.1.输入 ./mcl 启动 [mirai](https://github.com/mamoe/mirai)<br>
　8.2.输入 /login QQ号 密码 #登录机器人QQ<br>
9.下载并安装本项目<br>
　9.1.到 [GreenOnions/Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) #复制对应自己系统的本项目下载链接<br>
　9.2 输入 wget 地址 #下载本项目压缩包<br>
　9.3 输入 unzip linux-x64.zip #解压本项目(文件名按下载到的来写)<br>
　9.4 输入 cd linux-x64 #进入解压后的目录<br>
10.启动本项目并连接到 [mirai](https://github.com/mamoe/mirai)<br>
　10.5 输入 dotnet GreenOnions.BotManagerConsole.dll #启动本项目<br>
　10.6 输入QQ号<br>
　10.7 输入IP: 127.0.0.1<br>
　10.8 输入端口: 33111<br>
　10.9 输入authKey: Alex1911<br>
 
#### 大功告成

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
