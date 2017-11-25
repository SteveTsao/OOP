using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 備份處理介面
    /// </summary>
    interface IHandler
    {
        /// <summary>
        /// 處理方式
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>處理後檔案內容</returns>
        byte[] PerForm(Candidate candidate, byte[] target);
    }
}
