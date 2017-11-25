using ConsoleOop.Handlers.DbHandlers;
using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 資料庫轉換類別
    /// </summary>
    class DBAdapter : AbstractHandler
    {
        /// <summary>
        /// 備份檔案
        /// </summary>
        IDBHandler backupHandler = new DBBackupHandler();

        /// <summary>
        /// 備份記錄檔
        /// </summary>
        IDBHandler logHandler = new DBLogHandler();

        /// <summary>
        /// 資料庫備份處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        /// <returns>檔案</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            this.SaveBackupToDB(candidate, target); /// 備份檔案
            this.SaveLogToDB(candidate, target); /// 備份記錄檔

            return target;
        }

        /// <summary>
        /// 備份檔案
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        private void SaveBackupToDB(Candidate candidate, byte[] target)
        {
            this.backupHandler.OpenConnection(); /// 開啟資料庫連線
            this.backupHandler.Perform(candidate, target); /// 備份檔案
            this.backupHandler.CloseConnection(); /// 關閉資料庫連線
        }

        /// <summary>
        /// 備份記錄檔
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        private void SaveLogToDB(Candidate candidate, byte[] target)
        {
            this.logHandler.OpenConnection(); /// 開啟資料庫連線
            this.logHandler.Perform(candidate, target); /// 備份記錄檔
            this.logHandler.CloseConnection(); /// 關閉資料庫連線
        }
    }
}
