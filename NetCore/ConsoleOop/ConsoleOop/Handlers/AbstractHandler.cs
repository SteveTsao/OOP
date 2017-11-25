using System.IO;
using MyBackupCandidate;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 備份檔案處理抽象類別
    /// </summary>
    abstract class AbstractHandler : IHandler
    {
        /// <summary>
        /// 處理方式
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <param name="target">檔案內容</param>
        /// <returns>處理後檔案內容</returns>
        abstract public byte[] PerForm(Candidate candidate, byte[] target);

        /// <summary>
        /// 儲存檔案
        /// </summary>
        /// <param name="path">儲存位置</param>
        /// <param name="target">檔案內容</param>
        protected void ConvertByteArrayToFile(string path, byte[] target)
        {
            File.WriteAllBytes(path, target);
        }

        /// <summary>
        /// 產生檔案名稱
        /// </summary>
        /// <param name="fileName">原檔案名稱</param>
        /// <returns>新檔案名稱</returns>
        protected string GenFileName(string fileName)
        {
            return fileName.Replace("%", "%25").Replace(":", "%3A").Replace("/", "%2F").Replace("\\", "%5C");
        }
    }
}
