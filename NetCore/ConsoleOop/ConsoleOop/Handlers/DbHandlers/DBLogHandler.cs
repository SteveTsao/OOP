using System;
using MySql.Data.MySqlClient;
using MyBackupCandidate;

namespace ConsoleOop.Handlers.DbHandlers
{
    /// <summary>
    /// 備份記錄檔
    /// </summary>
    class DBLogHandler : AbstractDBHandler
    {
        /// <summary>
        /// 備份記錄檔處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        /// <returns>檔案</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Logs (Log_filename, Log_datetime) VALUES (@filename, @datetime)", this.conn))
            {
                cmd.Parameters.Add("@filename", MySqlDbType.VarChar).Value = candidate.Name;
                cmd.Parameters.Add("@datetime", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.ExecuteNonQuery();
            }

            return target;
        }
    }
}
