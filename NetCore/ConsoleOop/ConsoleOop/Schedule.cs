using System.Runtime.Serialization;

namespace ConsoleOop
{
    /// <summary>
    /// 自動排程時間類別
    /// </summary>
    [DataContract]
    class Schedule
    {
        /// <summary>
        /// 序列化:處理檔案格式
        /// </summary>
        [DataMember]
        private string ext { get; set; }

        /// <summary>
        /// 序列化:排程時間
        /// </summary>
        [DataMember]
        private string time { get; set; }

        /// <summary>
        /// 序列化:排程間隔
        /// </summary>
        [DataMember]
        private string interval { get; set; }

        /// <summary>
        /// 處理檔案格式
        /// </summary>
        public string Ext { get { return this.ext; } }

        /// <summary>
        /// 排程時間
        /// </summary>
        public string Time { get { return this.time; } }

        /// <summary>
        /// 排程間隔
        /// </summary>
        public string Interval { get { return this.interval; } }

        /// <summary>
        /// 建構子 屬性初始設定
        /// </summary>
        /// <param name="_ext">處理檔案格式</param>
        /// <param name="_time">排程時間</param>
        /// <param name="_interval">排程間隔</param>
        public Schedule(string _ext, string _time, string _interval)
        {
            this.ext = _ext;
            this.time = _time;
            this.interval = _interval;
        }
    }
}
