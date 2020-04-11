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

            // 11
            //Console.WriteLine("Hello every one");
            //Console.WriteLine("Hello every one".ToHeader(120));

            // 10.
            FileLoggerTest();

            // 09.
            //LoggerManagerTest();

            // 08.
            //ConsoleLoggerCompleted();

            // 07.
            //DebugOutputLoggerCompleted();

            // 06.
            //InterfaceForEachTest();

            // 05.
            //DebugOutputTest();

            // 02. 03
            //ConsoleLoggerTest();

            // 01.
            // ColorfullConsoleAndTimeFormat();

            Console.ReadKey();// 暂停的一种方法
        }

        // TODO: 01-A 彩色的控制台输出           
        // TODO: 01-B 时间的格式化输出

        /// <summary>
        /// 01. 控制台的彩色输出和时间格式化
        /// </summary>
        static void ColorfullConsoleAndTimeFormat() {
            // 获取当前颜色（默认颜色）
            var oldColor = Console.ForegroundColor;

            // 输出一次蓝色
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("This is blue...");
            
            // 输出一次红色
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is red...");

            // 输出一次黄色
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This is yellow...");
            
            // 将控制台设置为默认
            Console.ForegroundColor = oldColor;
            Console.WriteLine("This is default...");

            // 获取当前时间
            var time = DateTime.Now;
            Console.WriteLine($"Normal format: {time.ToString()}");

            // 时间的格式化
            Console.WriteLine($"Format string: {time.ToString("yyyy-MM-dd hh-mm-ss")}");
        }

        /// <summary>
        ///  03. 02. 代码
        /// </summary>
        static void ConsoleLoggerTest() {
            ConsoleLogger logger = new ConsoleLogger();
            // TODO: 04-B 过期代码CS0618警告的禁用
#pragma warning disable 0618
            logger.WriteLine();
#pragma warning restore 0618
            logger.WriteLine();
        }

        /// <summary>
        /// TODO: 05 彩色的Debug输出
        /// </summary>
        static void DebugOutputTest() {
            Debug.WriteLine(" Debug ");
            Debug.WriteLine(" Error ");
            Debug.WriteLine(" Fatal ");
            Debug.WriteLine(" Info ");
        }

        /// <summary>
        /// TODO: 06 接口与Linq ForEach()
        /// </summary>
        static void InterfaceForEachTest() {
            ConsoleLogger console = new ConsoleLogger();
            DebugLogger debug = new DebugLogger();

            // 不使用接口时
            List<Object> loggers = new List<object>
            {
                console,
                debug
            };

            loggers.ForEach(
                log => 
                {
                    (log as ConsoleLogger)?.WriteLine(MessageType.Infor, "一个新的消息");
                    (log as DebugLogger)?.WriteLine(MessageType.Infor, "一个新的消息");                        
                }
            );

            // 使用接口
            List<ILogger> iloggers = new List<ILogger>
            {
                console,
                debug
            };

            iloggers.ForEach(
                log => log.WriteLine(MessageType.Infor, "一个新的消息", "Method" , "file", 0));
        }

        /// <summary>
        /// TODO: 07-D 完整DebugOutputLogger的使用
        /// </summary>
        static void DebugOutputLoggerCompleted() {
            DebugLogger logger = new DebugLogger();

            logger.WriteLine($" This is a {MessageType.Debug} ...", MessageType.Debug);
            logger.WriteLine($" This is a {MessageType.Infor} ...", MessageType.Infor);
            logger.WriteLine($" This is a {MessageType.Error} ...", MessageType.Error);
            logger.WriteLine($" This is a {MessageType.Fatal} ...", MessageType.Fatal);
        }

        /// <summary>
        /// TODO: 08-C 完整的ConsoleLogger的使用
        /// </summary>
        static void ConsoleLoggerCompleted() {
            ConsoleLogger logger = new ConsoleLogger();

            logger.WriteLine($"This is a Debug message", MessageType.Debug);
            logger.WriteLine($"This is a Info message", MessageType.Infor);
            logger.WriteLine($"This is a Error message", MessageType.Error);
            logger.WriteLine($"This is a Fatal message", MessageType.Fatal);
        }

        /// <summary>
        /// TODO: 09-E Logger调度器的使用
        /// </summary>
        static void LoggerManagerTest() {

            LoggerManager.Enable(LoggerType.Console | LoggerType.Debug , LoggerLevel.Debug);

            LoggerManager.WriteDebug($"this is debug message {(int)LoggerType.Debug}");

            LoggerManager.WriteInfor($"this is infor message {(int)LoggerType.Console}");
            LoggerManager.WriteInfor($"this is infor message ");
            LoggerManager.WriteInfor($"this is infor message "); 

            LoggerManager.WriteError("this is error message");
            LoggerManager.WriteFatal("this is fatal message");
             
            LoggerManager.WriteInfor($"this is infor message ");
            LoggerManager.WriteInfor($"this is infor message "); 

            LoggerManager.Disable();
        }

        /// <summary>
        /// TODO: 10-D FileLogger的使用
        /// </summary>
        static void FileLoggerTest() {

            LoggerManager.Enable(LoggerType.Console | LoggerType.Debug | LoggerType.File, LoggerLevel.Debug);

            LoggerManager.WriteDebug($"this is debug message {(int)LoggerType.Debug}");

            LoggerManager.WriteInfor($"this is infor message {(int)LoggerType.Console}");
            LoggerManager.WriteInfor($"this is infor message ");
            LoggerManager.WriteInfor($"this is infor message "); 

            LoggerManager.WriteError("this is error message");
            LoggerManager.WriteFatal("this is fatal message");
             
            LoggerManager.WriteInfor($"this is infor message ");
            LoggerManager.WriteInfor($"this is infor message "); 

            LoggerManager.Disable();

            LoggerManager.WriteError("Is Logger cleared?");
            LoggerManager.WriteFatal("Is Logger cleared?");
        }
    }
}
