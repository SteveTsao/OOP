using System.Collections.Generic;
using ConsoleOop.Handlers;
using ConsoleOop.Finders;
using ConsoleOop.Configs;
using MyBackupCandidate;

namespace ConsoleOop.Tasks
{
    /// <summary>
    /// 執行備份抽象類別
    /// </summary>
    abstract class AbstractTask : ITask
    {
        private IFileFinder fileFinder;

        /// <summary>
        /// 是否處理檔案
        /// </summary>
        /// <param name="config">檔案設定</param>
        /// <returns>是否處理檔案</returns>
        protected virtual bool IsTask(Config config)
        {
            return true;
        }

        /// <summary>
        /// 執行備份
        /// </summary>
        /// <param name="configs">檔案處理設定</param>
        /// <param name="schedules">自動排程時間</param>
        public virtual void Execute(List<Config> configs, List<Schedule> schedules)
        {
            configs.ForEach(delegate (Config config)
            {
                if (!this.IsTask(config))
                {
                    return;
                }

                /// 建立 FileFinder 物件
                this.fileFinder = FileFinderFactory.Create("file", config);

                foreach (Candidate candidate in this.fileFinder)
                {
                    this.BroadcastToHandlers(candidate);
                }
            });
        }

        /// <summary>
        /// 執行檔案備份
        /// </summary>
        /// <param name="candidate">擋案資訊內容</param>
        private void BroadcastToHandlers(Candidate candidate)
        {
            byte[] target = null;

            this.FindHandlers(candidate).ForEach(delegate (IHandler handler)
            {
                target = handler.PerForm(candidate, target);
            });
        }

        /// <summary>
        /// 根據檔案類型，建立處理方式
        /// </summary>
        /// <param name="candidate">檔案資訊</param>
        /// <returns>檔案將進行的處理方式</returns>
        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handles = new List<IHandler>();

            /// 讀取檔案
            handles.Add(HandlerFactory.Create("file"));

            /// 檔案處理
            for (int i = 0; i < candidate.Config.Handlers.Length; i++)
            {
                handles.Add(HandlerFactory.Create(candidate.Config.Handlers[i]));
            }

            /// 目錄備份
            if (!string.IsNullOrEmpty(candidate.Config.Destination))
            {
                handles.Add(HandlerFactory.Create("directory"));
            }

            return handles;
        }
    }
}
