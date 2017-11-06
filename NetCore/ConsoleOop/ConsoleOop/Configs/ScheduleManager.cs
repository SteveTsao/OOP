using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 封裝Schedule物件類別
    /// </summary>
    [DataContract]
    class ScheduleManager : JsonManager
    {
        /// <summary>
        /// 陣列儲存多筆Schedule物件
        /// </summary>
        [DataMember]
        private List<Schedule> schedules { get; set; }

        /// <summary>
        /// JSON檔案位置
        /// </summary>
        private const string path = "schedules.json";

        /// <summary>
        /// 陣列Schedule物件總數
        /// </summary>
        public int Count => this.schedules.Count;

        /// <summary>
        /// 索引子 indexer
        /// </summary>
        /// <param name="number">索引</param>
        /// <returns>Schedule物件</returns>
        public Schedule this[int number] => this.schedules[number];

        /// <summary>
        /// 建構子 初始設定
        /// </summary>
        public ScheduleManager()
        {
            this.schedules = new List<Schedule>();
        }

        /// <summary>
        /// 解析JSON檔案轉成Schedule物件陣列
        /// </summary>
        public override void ProcessJsonConfig()
        {
            var obj = this.GetJsonObject<ScheduleManager>(path);

            this.schedules = new List<Schedule>();

            for (int i = 0; i < obj.Count; i++)
            {
                this.schedules.Add(obj[i]);
            }
        }
    }
}
