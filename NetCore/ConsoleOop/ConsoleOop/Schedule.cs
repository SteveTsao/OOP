using System.Runtime.Serialization;

namespace ConsoleOop
{
    [DataContract]
    class Schedule
    {
        [DataMember]
        private string ext { get; set; }

        [DataMember]
        private string time { get; set; }

        [DataMember]
        private string interval { get; set; }

        public string Ext { get { return this.ext; } }
        public string Time { get { return this.time; } }
        public string Interval { get { return this.interval; } }

        public Schedule(string _ext, string _time, string _interval)
        {
            this.ext = _ext;
            this.time = _time;
            this.interval = _interval;
        }
    }
}
