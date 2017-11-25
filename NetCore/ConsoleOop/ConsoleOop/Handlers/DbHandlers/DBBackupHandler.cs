using MyBackupCandidate;
using MySql.Data.MySqlClient;

namespace ConsoleOop.Handlers.DbHandlers
{
    /// <summary>
    /// 備份檔案
    /// </summary>
    class DBBackupHandler : AbstractDBHandler
    {
        /// <summary>
        /// 備份檔案處理
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>檔案內容</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Backups (Backup_filename, Backup_filedatetime, Backup_filesize, Backup_blob) VALUES (@filename, @filedatetime, @filesize, @blob)", this.conn))
            {
                cmd.Parameters.Add("@filename", MySqlDbType.VarChar).Value = candidate.Name;
                cmd.Parameters.Add("@filedatetime", MySqlDbType.DateTime).Value = candidate.FileDateTime;
                cmd.Parameters.Add("@filesize", MySqlDbType.Int64).Value = candidate.Size;
                cmd.Parameters.Add("@blob", MySqlDbType.LongBlob).Value = target;
                cmd.ExecuteNonQuery();
            }

            return target;
        }
    }
}
