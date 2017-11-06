using System.Collections.Generic;
using System.Linq;
using System.IO;
using ConsoleOop.Configs;
using ConsoleOop.Handlers;

namespace ConsoleOop
{
    /// <summary>
    /// 備份類別
    /// </summary>
    class MyBackupService
    {
        /// <summary>
        /// 存放JsonManager物件陣列
        /// </summary>
        private List<JsonManager> managers = new List<JsonManager>();

        /// <summary>
        /// 建構子 依賴注入
        /// </summary>
        /// <param name="configManager">封裝Config物件類別</param>
        /// <param name="scheduleManager">封裝Schedule物件類別</param>
        public MyBackupService(ConfigManager configManager, ScheduleManager scheduleManager)
        {
            this.managers.Add(configManager);
            this.managers.Add(scheduleManager);
        }

        /// <summary>
        /// 處理JSON檔案
        /// </summary>
        public void ProcessJsonConfigs()
        {
            this.managers.ForEach(delegate (JsonManager jsonManager)
            {
                jsonManager.ProcessJsonConfig();
            });
        }

        /// <summary>
        /// 所有檔案進行備份
        /// </summary>
        public void DoBackup()
        {
            this.FindFiles().ForEach(this.BroadcastToHandlers);
        }

        /// <summary>
        /// 取得所有備份檔案
        /// </summary>
        /// <returns>所有備份檔案資訊</returns>
        private List<Candidate> FindFiles()
        {
            /// 備份檔案
            var candidates = new List<Candidate>();

            /// 找到 ConfigManager 型別物件
            (from o in this.managers
             where o.GetType().Equals(typeof(ConfigManager))
             select o).ToList().ForEach(delegate (JsonManager jsonManager)
             {
                 var configManager = (ConfigManager)jsonManager;

                 /// 讀取Config設定
                 for (int i = 0; i < configManager.Count; i++)
                 {
                     /// 指定目錄
                     DirectoryInfo dirInfo = new DirectoryInfo(configManager[i].Location);

                     /// 取得目錄下所有檔案並過濾類型
                     (from o in dirInfo.GetFiles()
                      where o.Extension == "." + configManager[i].Ext
                      select o).ToList().ForEach(delegate (FileInfo info)
                      {
                          /// 加入備份檔案
                          candidates.Add(new Candidate(configManager[i], info.LastWriteTime, info.Name, info.FullName, info.Length));
                      });
                 }
             });

            return candidates;
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
