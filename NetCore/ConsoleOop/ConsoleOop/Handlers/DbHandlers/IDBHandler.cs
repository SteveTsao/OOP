using MyBackupCandidate;

namespace ConsoleOop.Handlers.DbHandlers
{
    /// <summary>
    /// 資料庫介面
    /// </summary>
    interface IDBHandler
    {
        /// <summary>
        /// 開啟資料庫連線
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// 關閉資料庫連線
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// 備份到資料庫處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>檔案內容</returns>
        byte[] Perform(Candidate candidate, byte[] target);
    }
}
