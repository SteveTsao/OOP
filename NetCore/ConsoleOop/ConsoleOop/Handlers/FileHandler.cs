using System.IO;
using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 檔案處理
    /// </summary>
    class FileHandler : AbstractHandler
    {
        /// <summary>
        /// 讀取、暫存檔案
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>處理後檔案內容</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            if (target == null)
            {
                /// 轉換成 btyes
                return this.ConvertFileToByteArray(candidate);
            }

            /// 暫存檔案
            this.ConvertByteArrayToFile(this.GenFileName(candidate.Name) + ".tmp", target);

            return target;
        }

        /// <summary>
        /// 讀取檔案轉換成btye型態
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>檔案內容</returns>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            return File.ReadAllBytes(candidate.Name);
        }
    }
}
