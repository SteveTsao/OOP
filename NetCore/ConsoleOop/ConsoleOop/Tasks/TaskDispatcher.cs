using System.Collections.Generic;
using System.Linq;
using ConsoleOop.Configs;

namespace ConsoleOop.Tasks
{
    /// <summary>
    /// 備份執行方式
    /// </summary>
    class TaskDispatcher
    {
        /// <summary>
        /// 執行備份物件
        /// </summary>
        private ITask task;

        /// <summary>
        /// 取得特定的JsonManager物件
        /// </summary>
        /// <typeparam name="T">JsonManager泛型</typeparam>
        /// <param name="managers">JsonManager物件</param>
        /// <returns>回傳JsonManager物件</returns>
        private List<JsonManager> GetManagers<T>(List<JsonManager> managers)
        {
            return (from o in managers
                    where o.GetType().Equals(typeof(T))
                    select o).ToList();
        }

        /// <summary>
        /// 取得所有的檔案處理設定物件
        /// </summary>
        /// <param name="managers">JsonManager物件</param>
        /// <returns>回傳檔案處理設定物件</returns>
        private List<Config> GetConfigs(List<JsonManager> managers)
        {
            var configs = new List<Config>();

            this.GetManagers<ConfigManager>(managers).ForEach(delegate (JsonManager jsonManager)
            {
                var configManager = (ConfigManager)jsonManager;

                for (int i = 0; i < configManager.Count; i++)
                {
                    configs.Add(configManager[i]);
                }
            });

            return configs;
        }

        /// <summary>
        /// 取得所有的自動排程時間物件
        /// </summary>
        /// <param name="managers">JsonManager物件</param>
        /// <returns>回傳自動排程時間物件</returns>
        private List<Schedule> GetSchedules(List<JsonManager> managers)
        {
            var schedules = new List<Schedule>();

            this.GetManagers<ScheduleManager>(managers).ForEach(delegate (JsonManager jsonManager)
            {
                var scheduleManager = (ScheduleManager)jsonManager;

                for (int i = 0; i < scheduleManager.Count; i++)
                {
                    schedules.Add(scheduleManager[i]);
                }
            });

            return schedules;
        }

        /// <summary>
        /// 簡單備份
        /// </summary>
        /// <param name="managers">Manager抽象類別</param>
        public void SimpleTask(List<JsonManager> managers)
        {
            this.task = TaskFactory.Create("simple");

            task.Execute(this.GetConfigs(managers), new List<Schedule>());
        }

        /// <summary>
        /// 排程備份
        /// </summary>
        /// <param name="managers">Manager抽象類別</param>
        public void ScheduledTask(List<JsonManager> managers)
        {
            this.task = TaskFactory.Create("schedule");

            task.Execute(this.GetConfigs(managers), this.GetSchedules(managers));
        }
    }
}
