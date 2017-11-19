using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleOop.Configs;

namespace ConsoleOop.Tasks
{
    /// <summary>
    /// 排程備份
    /// </summary>
    class ScheduledTask : AbstractTask
    {
        /// <summary>
        /// 處理時間
        /// </summary>
        private string taskTime = "";

        /// <summary>
        /// 處理排程
        /// </summary>
        private List<Schedule> taskSchedules = new List<Schedule>();

        /// <summary>
        /// 是否處理檔案
        /// </summary>
        /// <param name="config">檔案設定</param>
        /// <returns>是否處理檔案</returns>
        protected override bool IsTask(Config config)
        {
            /// 比對排程時間、檔案類型是否相同
            return (from o in this.taskSchedules
                    where o.Ext.Equals(config.Ext) && o.Time.Equals(this.taskTime)
                    select o).ToList().Count > 0;
        }

        /// <summary>
        /// 執行備份
        /// </summary>
        /// <param name="configs">檔案處理設定</param>
        /// <param name="schedules">自動排程時間</param>
        public override void Execute(List<Config> configs, List<Schedule> schedules)
        {
            this.taskSchedules = schedules;

            while (true)
            {
                this.taskTime = DateTime.Now.ToString("H:mm");

                base.Execute(configs, schedules);

                Thread.Sleep(1000);
            }
        }
    }
}
