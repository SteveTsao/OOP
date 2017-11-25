using System;
using System.Text;
using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 加密處理
    /// </summary>
    class EncodeHandler : AbstractHandler
    {
        /// <summary>
        /// 檔案加密
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>加密後檔案內容</returns>
        public override byte[] PerForm(Candidate candidate, byte[] target)
        {
            return Encoding.Default.GetBytes(Convert.ToBase64String(target));
        }
    }
}
