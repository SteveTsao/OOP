using System.Collections;
using ConsoleOop.Configs;

namespace ConsoleOop.Finders
{
    /// <summary>
    /// 備份來源介面
    /// </summary>
    interface IFileFinder : IEnumerable, IEnumerator
    {
        /// <summary>
        /// 來源讀取
        /// </summary>
        /// <param name="config">檔案設定</param>
        void FileFinder(Config config);
    }
}
