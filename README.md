# GreenOnions

### 关于本项目

#### 这是一个 [mirai](https://github.com/mamoe/mirai) 平台的QQ机器人, 支持OneBot(使用[Sora](https://github.com/DeepOceanSoft/Sora))和Mirai-Api-Http(使用[Mirai-CSharp](https://github.com/Executor-Cheng/Mirai-CSharp))双协议, 实现了搜图, 翻译, setu RSS订阅转发等功能<br>
#### 搜图和setu功能设计思路参考自 [cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot) <br>

### 效果预览
[到mirai社区查看](https://mirai.mamoe.net/topic/1020/%E7%83%82%E5%A4%A7%E8%A1%97%E7%9A%84%E6%90%9C%E5%9B%BE-rss%E8%BD%AC%E5%8F%91%E7%AD%89%E5%8A%9F%E8%83%BD%E6%8F%92%E4%BB%B6-%E5%B8%A6windows%E7%95%8C%E9%9D%A2)

[![QQ群](https://img.shields.io/badge/QQ群-550398174-blue.svg "QQ群")](https://jq.qq.com/?_wv=1027&k=rJ7RA3SF "QQ群")

### 功能介绍

- [x] 1. [SauceNao](https://saucenao.com/) 搜图<br>
- [x] 2. [ascii2d](https://ascii2d.net/) 搜图<br>
- [x] 3. [trace.moe](https://trace.moe/) 搜番<br>
- [x] 4. [lolicon](https://api.lolicon.app/#/setu) setu<br>
- [x] 5. 群友 [Quan](https://github.com/Quan666) 的 [ELF图库](http://img.shab.fun:5000/) 美图<br>
- [x] 6. 有道网页翻译和[GoogleTranslateFreeApi](https://github.com/wadereye/GoogleTranslateFreeApi) 翻译<br>
- [x] 7. 随机复读, 连续复读, 镜像复读图片和倒带gif(可配置触发几率)<br>
- [x] 8. 新人入群/退群/被踢提醒(支持定义)<br>
- [x] 9. RSS订阅转发<br>
- [x] 10. 下载Pixiv原图(通过[pixiv.cat](https://pixiv.cat/))<br>
- [x] 11. 使用表情涂鸦游玩的井字棋功能 (其实是自己学习[OpenCVsharp](https://github.com/shimat/opencvsharp)过程中搞出来的, 随手搬上了bot上, 但实际由于涂鸦完还要转发, 步骤太多所以下棋体验极差, 而且仅限64位系统可用)<br>

### 项目优势:

1. 带Windows图形界面, 没有开发基础也可以傻瓜式配置<br>
2. 多平台兼容, .Net6能装的平台都能运行(当然非Windows就没有图形界面了)<br>
3. 搜图功能可配置接入腾讯云鉴黄, 可以有效避免被内鬼炸号炸群, 尤其是Ascii2D乱开车的时候<br>
4. 搜图功能会尝试自动下载原图发送<br>
5. 支持一句命令多张setu, 支持限制QQ号调用次数和频率, 支持定时撤回, 支持配置返回语等<br>
6. 支持配置以合并转发的方式发送消息，防止不可描述的图片炸号<br>
7. RSS转发功能有控件配置，可方便添加删除和设置翻译<br>
8. 可使用QQ消息配置机器人属性<br>

## Windows食用方法(傻瓜版):

#### 首先, 这里有两个平台, 先选择一个顺眼的, 别两个都弄

### OneBot(Cq-Http)平台：

#### 一、环境配置:

1. 首先确保你的系统是 Windows 10 1607 或更高版本/Windows 8.1/Windows7 Sp1 并安装了 KB3063858 ( [x64](https://www.microsoft.com/zh-CN/download/details.aspx?id=47442) | [x86](https://www.microsoft.com/zh-CN/download/details.aspx?id=47409) ) 和 [KB2533623](https://support.microsoft.com/zh-cn/topic/microsoft-%E5%AE%89%E5%85%A8%E5%85%AC%E5%91%8A-%E4%B8%8D%E5%AE%89%E5%85%A8%E7%9A%84%E5%BA%93%E5%8A%A0%E8%BD%BD%E5%8F%AF%E8%83%BD%E5%85%81%E8%AE%B8%E8%BF%9C%E7%A8%8B%E6%89%A7%E8%A1%8C%E4%BB%A3%E7%A0%81-486ea436-2d47-27e5-6cb9-26ab7230c704) 补丁<br>
2. 下载并安装 Microsoft Visual C++ 2015-2019 Redistributable ( [x64](https://aka.ms/vs/16/release/vc_redist.x64.exe) | [x86](https://aka.ms/vs/16/release/vc_redist.x86.exe) )<br>
3. 到 [.Net6官网](https://dotnet.microsoft.com/download/dotnet/6.0) 找到.NET Desktop Runtime下载对应自己系统架构的 Installers 版本安装<br>

#### 二、安装机器人框架([go-cqhttp](https://github.com/Mrs4s/go-cqhttp))

1. 到 [go-cqhttp/Release](https://github.com/Mrs4s/go-cqhttp/releases) 下载 go-cqhttp (注意选对系统)<br>
2. 双击运行 go-cqhttp.exe 点击"是", 创建启动脚本<br>
3. 双击运行 go-cqhttp.bat<br>
4. 选择 2 正向 Websocket 通信 并回车, 随后关闭 cmd 窗口<br>
5. 打开生成的 config.yml 文件, 修改以下内容:<br>
  uin: QQ号<br>
  password: QQ密码<br>
  post-format: array<br>
  access-token: 'Alex1911'<br>
  address: 127.0.0.1:33111<br>
6. 保存并关闭 config.yml , 随后重新双击运行 go-cqhttp.bat<br>

#### 三、安装本项目

1. 到 [Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) 下载本项目的发行版本, 找最新的 win-x86x64arm-windows.zip 下<br>
2. 解压到任意目录, 运行 GreenOnions.BotManagerWindow.exe<br>
3. 输入机器人QQ号和 config.yml 对应的 ip(127.0.0.1)、端口 (33111) 和 access-token, 点击连接到 cq-http<br>

#### 大功告成


### Mirai-Api-Http平台：

#### 一、环境配置:

1. 首先确保你的系统是 Windows 10 1607 或更高版本/Windows 8.1/Windows7 Sp1 并安装了 KB3063858 ( [x64](https://www.microsoft.com/zh-CN/download/details.aspx?id=47442) | [x86](https://www.microsoft.com/zh-CN/download/details.aspx?id=47409) ) 和 [KB2533623](https://support.microsoft.com/zh-cn/topic/microsoft-%E5%AE%89%E5%85%A8%E5%85%AC%E5%91%8A-%E4%B8%8D%E5%AE%89%E5%85%A8%E7%9A%84%E5%BA%93%E5%8A%A0%E8%BD%BD%E5%8F%AF%E8%83%BD%E5%85%81%E8%AE%B8%E8%BF%9C%E7%A8%8B%E6%89%A7%E8%A1%8C%E4%BB%A3%E7%A0%81-486ea436-2d47-27e5-6cb9-26ab7230c704) 补丁<br>
2. 下载并安装 Microsoft Visual C++ 2015-2019 Redistributable ( [x64](https://aka.ms/vs/16/release/vc_redist.x64.exe) | [x86](https://aka.ms/vs/16/release/vc_redist.x86.exe) )<br>
3. 到 [.Net6官网](https://dotnet.microsoft.com/download/dotnet/6.0) 找到.NET Desktop Runtime下载对应自己系统架构的Installers版本安装<br>
4. 到 [OpenJDK官网](http://jdk.java.net/) 下载 OpenJDK 尽量选择高版本的下<br>
5. 将OpenJDK解压到C:\Program Files\Java文件夹下, 呈C:\Program Files\Java\jdk-xx.x路径形式(x为版本号)<br>
6. 打开 算机属性-高级系统设置-高级-环境变量 在下方系统变量栏中新建一项 变量"JAVA_HOME" 值"C:\Program Files\Java\jdk-xx.x" (不包括引号,x为版本号)<br>
7. 编辑系统变量Path, 添加一项"%JAVA_HOME%\bin"<br>

#### 二、安装机器人框架([mirai-console-loader](https://github.com/iTXTech/mirai-console-loader))

1. 到 [mirai-console-loader/releases](https://github.com/iTXTech/mirai-console-loader/releases) 下载MCL (尽量选择不带beta的最新版, .zip结尾的那个)<br>
2. 通过MCL安装 [mirai-api-http](https://github.com/project-mirai/mirai-api-http)<br>
3. 在MCL上运行一次 .\mcl 以确保配置文件成功创建, 随后按Ctrl+C退出
4. 拷贝 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 底下的setting.yml模板到 MCL目录\config\net.mamoe.mirai-api-http\setting.yml 文件中
5. 打开 MCL目录\config\net.mamoe.mirai-api-http\setting.yml 文件, 修改 http 和 ws 下的 host: 127.0.0.1 port: 33111 verifyKey: Alex1911<br>
6. 回到MCL窗口, 重新输入一次.\mcl 再输入/login 机器人QQ号 密码 登录<br>

#### 三、安装本项目

1. 到 [Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) 下载本项目的发行版本, 找最新的 win-x86x64arm-windows.zip 下<br>
2. 解压到任意目录, 运行 GreenOnions.BotManagerWindow.exe<br>
3. 输入机器人QQ号和 setting.yml 对应的 ip(host)、端口 (port) 和 VerifyKey, 点击连接到 mirai-api-http<br>

#### 大功告成

### Linux食用方法(仅提供mirai-api-http教程)
<details>
<summary>(点击查看)</summary>

 ### Ubuntu为例:
1. 输入 sudo apt install unzip #安装解压zip的库<br>
2. 输入 sudo apt install openjdk-17-jdk-headless #安装Java依赖<br>
3. 安装 .Net 依赖<br>
3.1. 输入 wget https://packages.microsoft.com/config/ubuntu/00.00/packages-microsoft-prod.deb -O packages-microsoft-prod.deb #下载 .Net 包目录(00.00替换为自己系统的版本)<br>
3.2. 输入 sudo dpkg -i packages-microsoft-prod.deb <br>  #解压包目录<br>
3.3. (可选)输入 rm packages-microsoft-prod.deb #删除压缩包<br>
3.4. 输入 sudo apt-get update; \\ <br>
 sudo apt-get install -y apt-transport-https && \\ <br>
 sudo apt-get update && \\ <br>
 sudo apt-get install -y aspnetcore-runtime-6.0  #安装 <br>
#其他发行版详见: [在 Linux 上安装.Net](https://docs.microsoft.com/zh-cn/dotnet/core/install/)<br>
#### 如果你不使用图片镜像, Gif倒放, 可以跳过步骤4、5(建议直接跳过, 准备砍掉了)
4. 安装Mono图形库:<br>
4.1. 输入 sudo apt install gnupg ca-certificates<br>
4.2. 输入 sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF<br>
4.3. 输入 echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list<br>
4.4. 输入 sudo apt update<br>
4.5. 输入 sudo apt install mono-complete<br>
#其他Linux发行版详见: [Mono](https://www.mono-project.com/download/stable/#download-lin)<br>
5. 安装libgdiplus图形增强库:<br>
5.1. 输入 sudo apt update<br>
5.2. 输入 sudo apt install -y libgdiplus<br>
5.3. 输入 cd /usr/lib<br>
5.4. 输入 sudo chmod 777 libgdiplus.so<br>
5.5. 输入 ln -s libgdiplus.so gdiplus.dll<br>
5.6. 输入 sudo apt update<br>
5.7. 输入 sudo apt install -y --no-install-recommends libgdiplus libc6-dev<br>
6. 安装 [mirai](https://github.com/mamoe/mirai) (这里的例子为 [Mirai Console Loader](https://github.com/iTXTech/mirai-console-loader))<br>
6.1. 到 [mcl/Release](https://github.com/iTXTech/mirai-console-loader/releases) 里复制最新的zip包下载地址<br>
6.2. 输入 wget 地址 #下载mcl 例如: wget https://github.com/iTXTech/mirai-console-loader/releases/download/v2.1.0/mcl-2.1.0.zip<br>
6.3. 输入 unzip mcl-1.2.2.zip #解压(文件名按下载到的来写)<br>
6.4. (可选:如果步骤7提示 Permission denied 请回来执行一次该步骤) 输入 sudo chmod 777 mcl #设置权限再重新执行步骤7<br>
7. 安装 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 通信插件<br>
7.1. 输入 ./mcl --update-package net.mamoe:mirai-api-http --channel stable-v2 --type plugin #(地址可能会随着更新改变, 以 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 中的说明为准)<br>
7.2. 输入 ./mcl #首次启动 [mirai](https://github.com/mamoe/mirai) 创建配置文件<br>
7.3. 当配置完成后, 按Ctrl+C停止运行<br>
7.5. 到 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 复制setting.yml模板<br>
7.4. 输入 sudo vim config/net.mamoe.mirai-api-http/setting.yml #使用Vim(或其他工具)编辑配置文件<br>
7.5. 粘贴复制的模板并修改 http 和 ws 下的 host: 127.0.0.1 port: 33111 verifyKey: Alex1911<br>
7.6. 按Esc退出编辑模式并输入 :wq! 保存配置文件<br>
8. 登录机器人QQ:<br>
8.1. 输入 ./mcl 启动 [mirai](https://github.com/mamoe/mirai)<br>
8.2. 输入 /login QQ号 密码 #登录机器人QQ<br>
9. 下载并安装本项目<br>
9.1. 到 [GreenOnions/Release](https://github.com/Alex1911-Jiang/GreenOnions/releases) #复制对应自己系统的本项目下载链接<br>
9.2. 输入 wget 地址 #下载本项目压缩包<br>
9.3. 输入 unzip linux-x64.zip #解压本项目(文件名按下载到的来写)<br>
9.4. 输入 cd linux-x64 #进入解压后的目录<br>
10. 启动本项目并连接到 [mirai](https://github.com/mamoe/mirai)<br>
10.5. 输入 dotnet GreenOnions.BotManagerConsole.dll #启动本项目<br>
10.6. 输入QQ号<br>
10.7. 输入IP: 127.0.0.1<br>
10.8. 输入端口: 33111<br>
10.9. 输入verifyKey: Alex1911<br>
 
#### 大功告成
 </details>


### 命令说明:

所有命令均以"<机器人名称>命令+空格"开头, 尖括号中代表要替换的值(不含尖括号, 带有问号的代表可选参数), 修改集合类型属性时多个元素以分号分隔<br>
1. 　--list #列出所有的属性功能分组名称<br>
2. 　--list <分组名> #列出该分组下的所有属性名称和中文别名<br>
3. 　--get <属性名/别名> #获取属性的值和描述<br>
4. 　--set <属性名/别名> <值> #修改改属性的值<br>
5. 　--bDescription <属性名/别名> #获取改属性的描述信息, 如果是枚举还会列出允许设置的值<br>
6. 　--rss #列出所有的RSS订阅项<br>
7. 　--addrss Url="<订阅地址>" remark="<?备注名>" ForwardGroups=<?转发群> ForwardQQs=<?转发好友> Translate=<?是否翻译> TranslateFromTo=<?是否指定翻译语言> TranslateFrom=<?从什么语言翻译> TranslateTo=<?翻译到什么语言> AtAll=<?是否@所有人> SendByForward=<?是否以合并转发方式发送> FilterMode=<?过滤模式*> FilterKeyWords=<?过滤词> #添加一个RSS订阅项<br>
8. 　--removerss <备注名/Url> #移除一个RSS订阅项<br>
*过滤模式: 0=不过滤, 1=包含任一, 2=包含所有, 3=不包含


###### 至于为什么叫葱葱, 一是一开始是给某初音群用的, 叫这个名字可以打压某助手, 二是早期没自己开发的时候使用 [cq-picsearcher-bot](https://github.com/Tsuk1ko/cq-picsearcher-bot) 的机器人叫竹竹, 就想找个类似的名字<br>

### 短期计划(TODO):

1.E-Hentai关键词色图<br>
2.群友要求萌娘百科语音报时(应该会做成插件)<br>

### 长期计划(GUDO):
1.把System.Drawing替换为其他~~更轻量~~的跨平台图形库(准备暂时先用CV), 取消Linux系统下对Mono的依赖<br>
2.把内嵌浏览器([CefSharp](https://github.com/cefsharp/CefSharp))和井字棋([OpenCVsharp](https://github.com/shimat/opencvsharp))分别搬出到独立的仓库里, 改为插件式加载, 取消强制依赖(毕竟没什么人用的功能占了500MB大小我自己也是多少带点...)<br>
3.添加一个RSS监控功能(沙雕群友自己网络有问题整天怪在我头上)<br>
4.部分功能使用代理(而不需要全局代理?)<br>
5.添加一个网站管理端?<br>
