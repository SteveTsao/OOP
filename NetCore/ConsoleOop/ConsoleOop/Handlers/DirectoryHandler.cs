using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 備份目錄
    /// </summary>
    class DirectoryHandler : AbstractHandler
    {
        /// <summary>
        /// 處理檔案目錄備份
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        /// <returns>備份後檔案</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            byte[] result = target;

            if (target != null)
            {
                result = this.CopyToDirectory(candidate, target);
            }

            return result;
        }

        /// <summary>
        /// 備份檔案到目錄
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案</param>
        /// <returns>備份後檔案</returns>
        private byte[] CopyToDirectory(Candidate candidate, byte[] target)
        {
            this.ConvertByteArrayToFile(candidate.Config.Dir + this.GenFileName(candidate.Name) + ".bak", target);

            return target;
        }
    }
}
