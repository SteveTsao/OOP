using System.IO;
using ConsoleOop.Configs;
using MyBackupCandidate;

namespace ConsoleOop.Finders
{
    /// <summary>
    /// 備份來源:檔案
    /// </summary>
    class LoadFileFinder : AbstractFileFinder
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="conf">檔案設定</param>
        public LoadFileFinder(Config conf) : base(conf)
        {

        }

        /// <summary>
        /// 取得備份來源資訊
        /// </summary>
        /// <param name="conf">檔案設定</param>
        public override void FileFinder(Config conf)
        {
            /// 指定目錄
            this.files = Directory.GetFiles(conf.Location, "*." + conf.Ext, SearchOption.AllDirectories);
        }

        /// <summary>
        /// 設定備份檔案
        /// </summary>
        /// <param name="fileName">檔案位置</param>
        /// <returns>備份檔案</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            FileInfo info = new FileInfo(fileName);

            return CandidateFactory.Create(this.config, info.CreationTime, fileName, info.Name, info.Length);
        }
    }
}
