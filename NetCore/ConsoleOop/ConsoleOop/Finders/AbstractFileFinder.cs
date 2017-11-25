using System.Collections;
using ConsoleOop.Configs;
using MyBackupCandidate;

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
        /// IEnumerator 實作 Iterator 迭代器
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
        /// 建構子
        /// </summary>
        /// <param name="conf">檔案設定</param>
        public AbstractFileFinder(Config conf)
        {
            /// 設定來源位置
            this.config = conf;

            /// 備份來源處理
            this.FileFinder(conf);
        }

        /// <summary>
        /// 備份來源處理
        /// </summary>
        /// <param name="conf">檔案設定</param>
        abstract public void FileFinder(Config conf);

        /// <summary>
        /// 建立備份來源檔案抽象函數
        /// </summary>
        /// <param name="fileName">檔案位置</param>
        /// <returns>檔案資訊</returns>
        abstract protected Candidate CreateCandidate(string fileName);
    }
}
