using System.IO;
using ConsoleOop.Configs;

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
        /// <param name="target">檔案</param>
        /// <returns>處理後檔案</returns>
        public virtual byte[] PerForm(Candidate candidate, byte[] target)
        {
            return target;
        }

        /// <summary>
        /// 儲存檔案
        /// </summary>
        /// <param name="path">儲存位置</param>
        /// <param name="target">檔案</param>
        protected void ConvertByteArrayToFile(string path, byte[] target)
        {
            File.WriteAllBytes(path, target);
        }
    }
}
