/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/10 23:36:26
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
using System;

namespace LoongEgg.LoongLogger
{
    // TODO: 09-A
    /// <summary>
    /// Logger实例的类型 
    /// </summary>
    /// <remarks>
    ///     // 注意加了[Flags]可以将枚举视为位域（即可以用 | 来OR运算）
    ///     // 示例代码使用的是16进制
    ///     LoggerType.Debug | LoggerType.Console // 表示 0x0001 | 0x0010 = 0x0011 (同时使能Debug和Console版的Logger)
    /// </remarks>
    [Flags]
    public enum LoggerType
    {
         Debug  = 0x0001, // 或者使用1， 即二进制的0001

         Console= 0x0010, // 或者使用2， 即二进制的0010

         File   = 0x0100  // 或者使用4， 即二进制的0100
    }
}
