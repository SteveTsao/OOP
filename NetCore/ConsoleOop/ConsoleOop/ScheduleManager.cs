using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleOop
{
    [DataContract]
    class ScheduleManager
    {
        [DataMember]
        private List<Schedule> schedules { get; set; }

        public int Count { get { return this.schedules.Count; } }

        public Schedule this[int number]
        {
            get { return this.schedules[number]; }
        }

        public ScheduleManager()
        {
            this.schedules = new List<Schedule>();
        }

        public void ProcessSchedule(string path)
        {
            this.schedules = new List<Schedule>();

            string json = File.ReadAllText(path);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(ScheduleManager));

                ScheduleManager arr = ((ScheduleManager)deserializer.ReadObject(ms));

                for (int i = 0; i < arr.Count; i++)
                {
                    this.schedules.Add(arr[i]);
                }
            }
        }
    }
}
