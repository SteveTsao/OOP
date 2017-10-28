using System.Collections.Generic;

namespace ConsoleOop
{
    /// <summary>
    /// 備份執行類別
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
        /// 處理JSON檔案執行設定
        /// </summary>
        public void ProcessJsonConfigs()
        {
            for (int i = 0; i < this.managers.Count; i++)
            {
                this.managers[i].ProcessJsonConfig();
            }
        }
    }
}
