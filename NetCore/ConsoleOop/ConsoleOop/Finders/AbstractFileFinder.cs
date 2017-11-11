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

        /// IEnumerator
        public IEnumerator GetEnumerator()
        {
            return new FileFinderEnumerator(this);
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

        /// <summary>
        /// 
        /// </summary>
        private class FileFinderEnumerator : IEnumerator
        {
            /// <summary>
            /// IEnumerator 起始
            /// </summary>
            private int index = -1;

            private AbstractFileFinder abstractFileFinder;

            public FileFinderEnumerator(AbstractFileFinder abstractFileFinders)
            {
                this.abstractFileFinder = abstractFileFinders;
            }

            /// IEnumerator     
            public object Current => this.abstractFileFinder.CreateCandidate(this.abstractFileFinder.files[this.index]);

            /// IEnumerator
            public bool MoveNext()
            {
                return (++this.index < this.abstractFileFinder.files.Length);
            }

            /// IEnumerator
            public void Reset()
            {
                System.Console.WriteLine("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
            }
        }
    }
}
