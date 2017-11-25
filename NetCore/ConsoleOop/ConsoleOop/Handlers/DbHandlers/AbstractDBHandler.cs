using MyBackupCandidate;
using MySql.Data.MySqlClient;

namespace ConsoleOop.Handlers.DbHandlers
{
    /// <summary>
    /// 資料庫抽象類別
    /// </summary>
    abstract class AbstractDBHandler : IDBHandler
    {
        /// <summary>
        /// 資料庫連線
        /// </summary>
        protected MySqlConnection conn;

        /// <summary>
        /// 備份到資料庫
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>檔案內容</returns>
        abstract public byte[] Perform(Candidate candidate, byte[] target);

        /// <summary>
        /// 建構子 資料庫連線設定
        /// </summary>
        public AbstractDBHandler()
        {
            this.conn = new MySqlConnection("Server=127.0.0.1;Database=test;Uid=test;Pwd=test;");
        }

        /// <summary>
        /// 資料庫連線開啟
        /// </summary>
        public virtual void OpenConnection()
        {
            this.conn.Open();
        }

        /// <summary>
        /// 資料庫連線關閉
        /// </summary>
        public virtual void CloseConnection()
        {
            this.conn.Close();
            this.conn.Dispose();
        }
    }
}
