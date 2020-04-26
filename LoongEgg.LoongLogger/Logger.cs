using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/10 23:37:38
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLogger
{
    // TODO: 编译的时候不要Release不然不会有Debug版本
    /// <summary>
    /// Logger调度器，编译的时候不要Release不然不会有Debug版本
    /// </summary>
    public static class Logger
    {
        static List<BaseLogger> Loggers = new List<BaseLogger>();

        /// <summary>
        /// 打开所有的Logger记录器
        /// </summary>
        /// <param name="level"><see cref="LoggerType"/></param>
        public static void EnableAll(LoggerLevel level = LoggerLevel.Debug) {
            Enable(LoggerType.Console | LoggerType.Debug | LoggerType.File, level);
        }

        // TODO: 09-B 注册Logger
        /// <summary>
        /// 使能各个Logger
        /// </summary>
        /// <param name="type">需要开启的Logger类型，可以使用“|”位域操作</param>
        /// <param name="level">开启的Logger的级别</param> 
        /// <example>
        ///     // 开启调试输出和控制台的Logger，消息级别为Error
        ///     LoggerManager.Enable(LoggerType.Debug | LoggerType.Console,  LoggerLevel.Error);
        /// </example>
        /// <code>
        ///     LoggerManager.Enable(LoggerType.Debug | LoggerType.Console,  LoggerLevel.Error);
        /// </code>
        public static void Enable(LoggerType type, LoggerLevel level = LoggerLevel.Debug) {
            Loggers.Clear();

            if (type.HasFlag(LoggerType.Console))
                Loggers.Add(new ConsoleLogger(level));

            if (type.HasFlag(LoggerType.Debug))
                Loggers.Add(new DebugLogger(level));

            if (type.HasFlag(LoggerType.File)) { 
                Loggers.Add(new FileLogger(level: level));
                WriteCritical("Logger File is Created... Check at this path: [ROOT_of_Your_Application]/log/", false);
            }

            WriteInfor(
                Environment.NewLine
                + "".ToHeader(120)
                + "  ".ToContent(120)
                + "Logger is CREATED by LoongLogger".ToContent(120)
                + "An OpenSource Project Released @ https://github.com/loongEgg/LoongLog".ToContent(120)
                + "You can Contact ME by Wechat:InnerGeeker or Email:LoongEgg@163.com".ToContent(120)
                + "  ".ToContent(120)
                + "".ToHeader(120),
                false);
        }

        // TODO: 09-C 销毁Logger
        /// <summary>
        /// 销毁所有的Logger
        /// </summary>
        public static void Disable() {
            Loggers.ForEach( 
                log => {
                    if (log.GetType() == typeof(FileLogger)) {
                        WriteInfor("", false);
                        WriteCritical("Logger File is Saved... Check at this path: [ROOT_of_Your_Application]/log/", false);
                    }

                }
            );
            WriteInfor(
                Environment.NewLine
                + "".ToHeader(120)
                + "  ".ToContent(120)
                + "Logger is CLEARED by LoongLogger".ToContent(120)
                + "An OpenSource Project Released @ https://github.com/loongEgg/LoongLog".ToContent(120)
                + "Thanks for Your Using!".ToContent(120)
                + "  ".ToContent(120)
                + " Good  Luck ".ToHeader(120),
                false);
            Loggers.Clear();
        }

        private static readonly object _Lock = new object();

        // TODO: 09-D 打印日志 WriteDebug, WriteInfo, WriteError, WriteFatal
        /// <summary>
        /// 打印一条新的日志消息
        /// </summary>
        ///     <param name="type">消息类型</param>
        ///     <param name="message">消息的具体内容</param>
        ///     <param name="isDetailMode">详细模式？</param>
        ///     <param name="callerName">调用的方法的名字</param>
        ///     <param name="fileName">调用方法所在的文件名</param>
        ///     <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        private static bool WriteLine
            (
                MessageType type,
                string message,
                bool isDetailMode,
                string callerName,
                string fileName,
                int line
            ) {
            bool isWrited = false;

            // TODO: 2020-04-26 增加了线程锁
            lock (_Lock) {
                string msg = BaseLogger.FormatMessage(type, message, isDetailMode, callerName, fileName, line);
                 
                if (Loggers.Any()) {
                    isWrited = true;
                    Loggers.ForEach(logger => isWrited &= logger.WriteLine(msg, type));
                }
            }
            return isWrited;
        }

        /// <summary>
        /// 打印一条新的调试信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="isDetailMode">详细模式？</param>
        /// <param name="callerName">调用的方法的名字</param>
        /// <param name="fileName">调用方法所在的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        public static bool WriteDebug
            (
                string message,
                bool isDetailMode = false,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            ) => WriteLine(MessageType.Debug, message, isDetailMode, callerName, fileName, line);

        /// <summary>
        /// 打印一条新的一般信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="isDetailMode">详细模式？</param>
        /// <param name="callerName">调用的方法的名字</param>
        /// <param name="fileName">调用方法所在的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        public static bool WriteInfor
            (
                string message,
                bool isDetailMode = false,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            ) => WriteLine(MessageType.Infor, message, isDetailMode, callerName, fileName, line);

        /// <summary>
        /// 打印一条新的故障信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="isDetailMode">详细模式？</param>
        /// <param name="callerName">调用的方法的名字</param>
        /// <param name="fileName">调用方法所在的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        public static bool WriteError
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            ) => WriteLine(MessageType.Error, message, isDetailMode, callerName, fileName, line);

        /// <summary>
        /// 打印一条新的关键信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="isDetailMode">详细模式？</param>
        /// <param name="callerName">调用的方法的名字</param>
        /// <param name="fileName">调用方法所在的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        public static bool WriteCritical
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            )  => WriteLine(MessageType.Crtcl, message, isDetailMode, callerName, fileName, line);

        /// <summary>
        /// 打印一条新的崩溃信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="isDetailMode">详细模式？</param>
        /// <param name="callerName">调用的方法的名字</param>
        /// <param name="fileName">调用方法所在的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns>[true]->打印成功</returns>
        public static bool WriteFatal
           (
               string message,
               bool isDetailMode = true,
               [CallerMemberName] string callerName = null,
               [CallerFilePath] string fileName = null,
               [CallerLineNumber]int line = 0
            ) => WriteLine(MessageType.Fatal, message, isDetailMode, callerName, fileName, line);

    }
}
