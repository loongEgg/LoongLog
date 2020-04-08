using System;
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
        public bool WriteLine(
            [CallerMemberName] string callerName = null,
            [CallerFilePath] string path = null,
            [CallerLineNumber] int line = 0) {

            string sth = $"{callerName} > {path} > {line}";

            Console.WriteLine(sth);

            return true;
        }
    }
}
