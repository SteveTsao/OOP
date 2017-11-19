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
        /// <param name="config">檔案設定</param>
        public LoadFileFinder(Config config) : base(config)
        {

        }

        /// <summary>
        /// 取得備份來源資訊
        /// </summary>
        /// <param name="configs">檔案設定</param>
        public override void FileFinder(Config configs)
        {
            /// 設定來源位置
            this.config = configs;

            /// 指定目錄
            this.files = Directory.GetFiles(configs.Location, "*." + configs.Ext, SearchOption.AllDirectories);
        }

        /// <summary>
        /// 設定備份檔案
        /// </summary>
        /// <param name="fileName">檔案位置</param>
        /// <returns>備份檔案</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            FileInfo info = new FileInfo(fileName);

            return CandidateFactory.Create(config, info.CreationTime, fileName, info.Name, info.Length);
        }
    }
}
