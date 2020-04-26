using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/10 19:39:58
 | 主要用途：所有Logger的基类，提供了格式化输出log日志的基本方法
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLogger
{
    // TODO: 07-B BaseLogger
    /// <summary>
    /// 所有Logger的基类，提供了格式化输出log日志的基本方法
    /// </summary>
    internal abstract class BaseLogger
    {
        /// <summary>
        /// Logger的级别定义，默认为<see cref="LoggerLevel.Debug"/>
        /// </summary>
        public LoggerLevel Level { get; private set; } = LoggerLevel.Debug;

        /// <summary>
        /// 默认构造器
        /// </summary>
        public BaseLogger(LoggerLevel level) {
            this.Level = level;
        }

        /// <summary>
        /// 格式化并返回日志消息
        /// </summary>
        ///     <param name="type">消息类型</param>
        ///     <param name="message">消息的具体内容</param>
        ///     <param name="isDetailMode">详细模式？</param>
        ///     <param name="callerName">调用方法的名字</param>
        ///     <param name="fileName">调用的文件名</param>
        ///     <param name="line">调用代码所在行</param>
        /// <returns>格式化后的日志消息</returns>
        public static string FormatMessage(
            MessageType type,
            string message,
            bool isDetailMode,
            string callerName,
            string fileName,
            int line) {

            StringBuilder msg = new StringBuilder();
            msg.Append(DateTime.Now.ToString() + " ");
            msg.Append($"[ {type.ToString()} ] -> ");

            if (isDetailMode)  
                msg.Append($"{Path.GetFileName(fileName)} > {callerName}() > in line[{line.ToString().PadLeft(3, ' ')}]: "); 

            msg.Append(message); 
            return msg.ToString();
        }

        /// <summary>
        ///     让子类实现这个打印log的方法
        /// </summary>
        ///     <param name="fullMessage">完整的消息</param>
        ///     <param name="type">消息类型</param>
        /// <returns>[true]->打印成功</returns>
        public abstract bool WriteLine(string fullMessage, MessageType type);

    }
}
