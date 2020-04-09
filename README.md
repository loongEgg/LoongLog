# LoongLog
一个可以在控制台（彩色）、输出（彩色）、文件同时记录的Log日志。   
A log for c#/WPF with colorful output/console and file recorder.   
你可以在提交历史中看到每一步的实现.  
You can learn every step in  history commit.
## 01.控制台的彩色输出和时间格式化<br>Colorfull Console And Time Format

- Colorfull Console
```c#
// 输出一次蓝色
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("This is blue...");
```
- Time Format
```c#
// 获取当前时间
var time = DateTime.Now;
Console.WriteLine($"Normal format: {time.ToString()}");

// 时间的格式化
Console.WriteLine($"Format string: {time.ToString("yyyy-MM-dd hh-mm-ss")}");
```

## 02.获取调用者的文件名、方法名和代码所在行<br>Get [CallerMemberName]/[CallerFilePath]/[CallerLineNumber]
### KeyPoints
- Using
```c#
using System.Runtime.CompilerServices;
```
- Attribute
```c#
public virtual bool WriteLine(
      string message,
      LogType type,
      bool isDetailMode,
      [CallerMemberName] string origin = null,
      [CallerFilePath] string callerFile = null,
      [CallerLineNumber] int codeLine = 0)
```
## 03.任务列表、精简文件名<br>ToDO List & Trimmed File Name
- ToDo List（任务列表）
```c#
// TODO 你要做的任务
```

![03.To Do List](Figures/03.ToDoList.png)

- 精简文件名
```c#
Path.GetFileName(fullLongLongPath);
```
- 指定长度输出，不足补空格
```c#
// 注意: 可以PadRight,补在右侧
//      那个3代表你的字符串要占的长度，设置5等的也是可以的
//      ‘ ’ 中间是一个空格，代表站位符，你可以用别的符号
sth.ToString().PadLeft(3, ' ');
```

## 04.过期代码警告与禁用CS0618<br>[Obsolete] & pragma warning disable 618
- **[Obsolete]** 受到这个Attribute标注的方法会引发CS0618,注意可以定义为警告或者错误

- 禁用CS0618警告
```c#
#pragma warning disable 618
            logger.WriteLine();
#pragma warning restore 618
```

## 05.彩色的Debug输出

- 插件依赖VsColorOutput（可能只有2019能在工具>扩展和更新>联机下面搜索到）
![05.Vs Color Output](Figures/05.VsColorOutput.png)
VS2015和VS2017版的下载地址
https://marketplace.visualstudio.com/items?itemName=MikeWard-AnnArbor.VSColorOutput

- 插件设置(工具>选项>VSColorOutput)
![05.Vs Color Output Setting](Figures/05.VsColorOutput_Setting.png)
![05.Vs Color Output Reg](Figures/05.VsColorOutput_Reg.png)

- Debug输出语法
```c#
 Debug.WriteLine(" Debug ");
 Debug.WriteLine(" Error ");
 Debug.WriteLine(" Fatal ");
 Debug.WriteLine(" Info ");
```