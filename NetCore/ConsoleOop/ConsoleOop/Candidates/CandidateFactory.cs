using System;
using ConsoleOop.Configs;

namespace MyBackupCandidate
{
    /// <summary>
    /// 備份檔案資訊工廠模式
    /// </summary>
    class CandidateFactory
    {
        /// <summary>
        /// 建立備份檔案資訊物件
        /// </summary>
        /// <param name="config">檔案處理設定</param>
        /// <param name="fileDateTime">檔案日期</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="processName">處理名稱</param>
        /// <param name="size">檔案大小</param>
        /// <returns>備份檔案資訊物件</returns>
        public static Candidate Create(Config config, DateTime fileDateTime, string name, string processName, long size)
        {
            return new Candidate(config, fileDateTime, name, processName, size);
        }
    }
}
