using System.Runtime.Serialization;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 自動排程時間類別
    /// </summary>
    [DataContract]
    class Schedule
    {
        /// <summary>
        /// 序列化:處理檔案格式(對應JOSN.ext鍵值)
        /// </summary>
        [DataMember(Name ="ext")]
        public readonly string Ext;

        /// <summary>
        /// 序列化:排程時間(對應JOSN.time鍵值)
        /// </summary>
        [DataMember(Name ="time")]
        public readonly string Time;

        /// <summary>
        /// 序列化:排程間隔(對應JOSN.interval鍵值)
        /// </summary>
        [DataMember(Name ="interval")]
        public readonly string Interval;

        /// <summary>
        /// 建構子 屬性初始設定
        /// </summary>
        /// <param name="ext">處理檔案格式</param>
        /// <param name="time">排程時間</param>
        /// <param name="interval">排程間隔</param>
        public Schedule(string ext, string time, string interval)
        {
            this.Ext = ext;
            this.Time = time;
            this.Interval = interval;
        }
    }
}
