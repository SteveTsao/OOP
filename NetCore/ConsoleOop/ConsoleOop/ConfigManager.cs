using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleOop
{
    [DataContract]
    class ConfigManager
    {
        [DataMember]
        private List<Config> configs { get; set; }

        public int Count { get { return this.configs.Count; } }

        public Config this[int number]
        {
            get { return this.configs[number]; }
        }

        public ConfigManager()
        {
            this.configs = new List<Config>();
        }

        public void ProcessConfig(string path)
        {
            this.configs = new List<Config>();

            string json = File.ReadAllText(path);

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(ConfigManager));

                ConfigManager arr = ((ConfigManager)deserializer.ReadObject(ms));

                for (int i = 0; i < arr.Count; i++)
                {
                    this.configs.Add(arr[i]);
                }
            }
        }
    }
}
