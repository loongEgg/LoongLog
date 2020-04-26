using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/9 20:11:17
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLogger
{
    /// <summary>
    /// 日志消息类型定义
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        Debug = 0,

        /// <summary>
        /// 一般信息
        /// </summary>
        Infor = 1,
        
        /// <summary>
        /// 关键信息
        /// </summary>
        Crtcl = 2,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 2,
         
        /// <summary>
        /// 崩溃
        /// </summary>
        Fatal = 3
    }
}
