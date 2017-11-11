using System.Collections;
using ConsoleOop.Configs;

namespace ConsoleOop.Finders
{
    /// <summary>
    /// 備份來源抽象類別
    /// </summary>
    abstract class AbstractFileFinder : IFileFinder
    {
        /// <summary>
        /// 檔案設定
        /// </summary>
        protected Config config;

        /// <summary>
        /// 備份來源
        /// </summary>
        public string[] files;

        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns>備份檔案資訊</returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.files.Length; i++)
            {
                yield return this.CreateCandidate(this.files[i]);
            }
        }

        /// <summary>
        /// 備份來源處理
        /// </summary>
        /// <param name="config">檔案設定</param>
        public abstract void FileFinder(Config config);

        /// <summary>
        /// 建立備份來源檔案抽象函數
        /// </summary>
        /// <param name="fileName">檔案位置</param>
        /// <returns>備份檔案資訊</returns>
        protected abstract Candidate CreateCandidate(string fileName);
    }
}
