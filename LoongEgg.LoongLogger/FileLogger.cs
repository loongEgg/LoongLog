using System;
using System.IO;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/4/11 9:56:55
 | 主要用途：
 | 更改记录：
 |			 时间		版本		更改
 */
namespace LoongEgg.LoongLogger
{
    /// <summary>
    /// File版的<see cref="BaseLogger"/>
    /// </summary>
    public class FileLogger : BaseLogger
    { 
        /*-------------------------------------- Properties -------------------------------------*/
        // Logger文件所在的路径
        public string FilePath { get; private set ;} 

        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// FileLogger的构造器
        /// </summary>
        ///     <param name="filePath">文件完整路径，可以不填，默认生成在当前根目录/log/下</param>
        ///     <param name="level">logger记录的最低级别</param>
        public FileLogger(string filePath = null, LoggerLevel level = LoggerLevel.Debug) : base(level) {

            if (filePath == null) {

                // TODO: 10-A 获取程序运行的根目录
                string root = Environment.CurrentDirectory;

                // TODO: 10-B 创建Log文件夹
                if (! Directory.Exists(root + @"/log/")) {
                    Directory.CreateDirectory(root + @"/log/");
                }

                this.FilePath = root + @"/log/" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".log";
            }
            else {
                this.FilePath = filePath;       
            }

            // TODO: 10-C 创建log文件
            using (StreamWriter writer = new StreamWriter(this.FilePath)) {
                writer.WriteLineAsync(BaseLogger.FormatMessage(MessageType.Infor, "Logger File is Created...", true, nameof(FileLogger), "Created by Constructor", 46));
            }
        }

        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// <see cref="BaseLogger.WriteLine(string, MessageType)"/>
        /// </summary> 
        public override bool WriteLine(string fullMessage, MessageType type) {

            using (StreamWriter writer = new StreamWriter(this.FilePath, true)) {
                writer.WriteLineAsync(fullMessage);
            }

            return true;
        }
    }
}
