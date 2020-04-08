using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace LoongLogger
{
    /*
	| 
	| WeChat: InnerGeek
	| LoongEgg@163.com 
	| https://github.com/loongEgg/LoongLog
	*/
    public class ConsoleLogger
    { 
        // TODO: 04-A 过期代码警告
        [Obsolete("这是一个演示方法，不要乱用", false)]
        // TODO: 02 获取调用方法名、调用文件名和调用代码所在行
        public bool WriteLine(
            [CallerMemberName] string callerName = null,
            [CallerFilePath] string path = null,
            [CallerLineNumber] int line = 0) {

            string sth = $"{callerName} > {path} > {line}";
            Console.WriteLine(sth);

            // TODO: 03 任务列表、精简文件名、指定长度输出不足补空格
            string msg = $"{Path.GetFileName(path)} > {callerName}() > in line [" + line.ToString().PadLeft(3, ' ') + "]";
            Console.WriteLine(msg);
            return true;
        }

    }
}
