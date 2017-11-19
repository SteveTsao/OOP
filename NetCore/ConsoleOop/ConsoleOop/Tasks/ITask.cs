using System.Collections.Generic;
using ConsoleOop.Configs;

namespace ConsoleOop.Tasks
{
    /// <summary>
    /// 執行備份類別
    /// </summary>
    interface ITask
    {
        /// <summary>
        /// 執行備份
        /// </summary>
        /// <param name="configs">檔案處理設定</param>
        /// <param name="schedules">自動排程時間</param>
        void Execute(List<Config> configs, List<Schedule> schedules);
    }
}
