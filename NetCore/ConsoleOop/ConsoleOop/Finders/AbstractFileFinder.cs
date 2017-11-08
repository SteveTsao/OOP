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
        /// IEnumerator 起始
        /// </summary>
        private int index = -1;

        /// <summary>
        /// 檔案設定
        /// </summary>
        protected Config config;

        /// <summary>
        /// 備份來源
        /// </summary>
        protected string[] files;

        /// IEnumerator
        public IEnumerator GetEnumerator()
        {
            this.Reset();

            return (IEnumerator)this;
        }

        /// IEnumerator     
        public object Current => this.CreateCandidate(files[this.index]);

        /// IEnumerator
        public bool MoveNext()
        {
            return (++this.index < this.files.Length);
        }

        /// IEnumerator
        public void Reset()
        {
            this.index = -1;
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
