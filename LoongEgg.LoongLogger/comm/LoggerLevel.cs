/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/10 19:48:09
 | 主要用途：定义了Logger的级别
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLogger
{
    // TODO: 07-A Logger的级别定义 
    /// <summary>
    ///     Logger的级别定义 
    /// </summary>
    /// <remarks>
    ///     只有<seealso cref="MessageType"/> >= <seealso cref="LoggerLevel"/> 的时候新的消息才会被记录
    /// </remarks>
    public enum LoggerLevel
    {
       /// <summary>
        /// 调试级
        /// </summary>
        Debug,

        /// <summary>
        /// 一般级
        /// </summary>
        Infor,
        
        /// <summary>
        /// 错误级
        /// </summary>
        Error,

        /// <summary>
        /// 崩溃级
        /// </summary>
        Fatal
    }
}
