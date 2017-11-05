using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
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
            for (int i = 0; i < this.managers.Count; i++)
            {
                this.managers[i].ProcessJsonConfig();
            }
        }

        /// <summary>
        /// 取得所有備份檔案
        /// </summary>
        /// <returns>所有備份檔案資訊</returns>
        private List<Candidate> FindFiles()
        {
            /// 備份檔案
            var candidates = new List<Candidate>();

            /// 取得 ConfigManager 型別物件
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
                      where o.Extension.ToLower() == "." + configManager[i].Ext.ToLower()
                      select o).ToList().ForEach(delegate (FileInfo info)
                      {
                          /// 加入備份檔案
                          candidates.Add(new Candidate(configManager[i], DateTime.Now, info.Name, info.FullName, info.Length));
                      });
                 }
             });

            return candidates;
        }

        /// <summary>
        /// 所有檔案進行備份
        /// </summary>
        public void DoBackup()
        {
            this.FindFiles().ForEach(this.BroadcastToHandlers);
        }

        /// <summary>
        /// 執行檔案備份
        /// </summary>
        /// <param name="candidate">擋案資訊內容</param>
        private void BroadcastToHandlers(Candidate candidate)
        {
            byte[] target = null;

            List<IHandler> handlers = this.FindHandlers(candidate);

            handlers.ForEach(delegate (IHandler handler)
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

            handles.Add(HandlerFactory.Create("file"));

            for (int i = 0; i < candidate.Config.Handlers.Length; i++)
            {
                handles.Add(HandlerFactory.Create(candidate.Config.Handlers[i]));
            }

            if (!string.IsNullOrEmpty(candidate.Config.Destination))
            {
                handles.Add(HandlerFactory.Create("directory"));
            }

            return handles;
        }
    }
}
