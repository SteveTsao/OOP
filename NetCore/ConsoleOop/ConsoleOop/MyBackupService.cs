using System.Collections.Generic;
using ConsoleOop.Configs;
using ConsoleOop.Tasks;

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
        /// 備份執行方式
        /// </summary>
        private TaskDispatcher taskDispatcher;

        /// <summary>
        /// 建構子 依賴注入
        /// </summary>
        public MyBackupService()
        {
            this.managers.Add(new ConfigManager());
            this.managers.Add(new ScheduleManager());
            this.taskDispatcher = new TaskDispatcher();

            this.Init();
        }

        /// <summary>
        /// 物件初始化
        /// </summary>
        private void Init()
        {
            this.ProcessJsonConfigs();
        }

        /// <summary>
        /// 簡單備份
        /// </summary>
        public void SimpleTask()
        {
            this.taskDispatcher.SimpleTask(this.managers);
        }

        /// <summary>
        /// 排程備份
        /// </summary>
        public void ScheduledTask()
        {
            this.taskDispatcher.ScheduledTask(this.managers);
        }

        /// <summary>
        /// 處理JSON檔案
        /// </summary>
        private void ProcessJsonConfigs()
        {
            this.managers.ForEach(delegate (JsonManager jsonManager)
            {
                jsonManager.ProcessJsonConfig();
            });
        }
    }
}
