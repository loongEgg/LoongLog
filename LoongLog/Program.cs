using LoongEgg.LoongLogger;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LoongLog
{
    class Program
    {
        // https://github.com/loongEgg/LoongLog
        static void Main(string[] args) {

            // 激活Logger
            Logger.Enable(LoggerType.Console | LoggerType.Debug | LoggerType.File, LoggerLevel.Debug);


            Logger.WriteDebug("this is a debug ...");
            Logger.WriteInfor("this is a infor ...");

            Logger.WriteError("this is a error ...");
            Logger.WriteFatal("this is a fatal ...");

            // 注销logger
            Logger.Disable();

            Console.ReadKey();// 暂停的一种方法
        }

    }
}
