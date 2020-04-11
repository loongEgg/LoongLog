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
    /// <summary>
    /// Logger调度器
    /// </summary>
    public static class LoggerManager
    {
        static List<BaseLogger> Loggers = new List<BaseLogger>();

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
        public static void Enable(LoggerType type, LoggerLevel level = LoggerLevel.Debug) {
            Loggers.Clear();

            if (type.HasFlag(LoggerType.Console))
                Loggers.Add(new ConsoleLogger(level));

            if (type.HasFlag(LoggerType.Debug))
                Loggers.Add(new DebugLogger(level));

            if (type.HasFlag(LoggerType.File))
                throw new NotImplementedException();
        }

        // TODO: 09-C 销毁Logger
        /// <summary>
        /// 销毁所有的Logger
        /// </summary>
        public static void Disable() {
            Loggers.Clear();
        }

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

            string msg = BaseLogger.FormatMessage(type, message, isDetailMode, callerName, fileName, line);
            bool isWrited = true;

            if (Loggers.Any())
                Loggers.ForEach( logger => isWrited &= logger.WriteLine(msg, type) );

            return isWrited;
        }

        public static bool WriteDebug
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            )       => WriteLine(MessageType.Debug, message, isDetailMode, callerName, fileName, line);

        public static bool WriteInfor
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            )       => WriteLine(MessageType.Infor, message, isDetailMode, callerName, fileName, line);

        public static bool WriteError
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
            )       => WriteLine(MessageType.Error, message, isDetailMode, callerName, fileName, line);

         public static bool WriteFatal
            (
                string message,
                bool isDetailMode = true,
                [CallerMemberName] string callerName = null,
                [CallerFilePath] string fileName = null,
                [CallerLineNumber]int line = 0
             )      => WriteLine(MessageType.Fatal, message, isDetailMode, callerName, fileName, line);

    }
}
