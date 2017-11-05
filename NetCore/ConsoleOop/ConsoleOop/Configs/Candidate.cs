using System;
using System.Runtime.Serialization;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 備份檔案資訊
    /// </summary>
    [DataContract]
    class Candidate
    {
        /// <summary>
        /// 檔案處理設定
        /// </summary>
        public readonly Config Config;

        /// <summary>
        /// 檔案日期
        /// </summary>
        public readonly DateTime FileDateTime;

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 處理名稱
        /// </summary>
        public readonly string ProcessName;

        /// <summary>
        /// 檔案大小
        /// </summary>
        public readonly long Size;

        /// <summary>
        /// 建構子 屬性初始設定
        /// </summary>
        /// <param name="config">檔案處理設定</param>
        /// <param name="fileDateTime">檔案日期</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="processName">處理名稱</param>
        /// <param name="size">檔案大小</param>
        public Candidate(Config config, DateTime fileDateTime, string name, string processName, long size)
        {
            this.Config = config;
            this.FileDateTime = fileDateTime;
            this.Name = name;
            this.ProcessName = processName;
            this.Size = size;
        }
    }
}
