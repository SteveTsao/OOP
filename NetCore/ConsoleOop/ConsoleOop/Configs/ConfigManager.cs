﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 封裝Config物件類別
    /// </summary>
    [DataContract]
    class ConfigManager : JsonManager
    {
        /// <summary>
        /// 陣列儲存多筆Config物件
        /// </summary>
        [DataMember]
        private List<Config> configs { get; set; }

        /// <summary>
        /// JSON檔案位置
        /// </summary>
        private const string path = "configs.json";

        /// <summary>
        /// 陣列Config物件總數
        /// </summary>
        public int Count => this.configs.Count;

        /// <summary>
        /// 索引子 indexer
        /// </summary>
        /// <param name="number">索引</param>
        /// <returns>Config物件</returns>
        public Config this[int number] => this.configs[number];

        /// <summary>
        /// 建構子 初始設定
        /// </summary>
        public ConfigManager()
        {
            this.configs = new List<Config>();
        }

        /// <summary>
        /// 解析JSON檔案轉成Config物件陣列
        /// </summary>
        public override void ProcessJsonConfig()
        {
            var obj = this.GetJsonObject<ConfigManager>(path);

            this.configs = new List<Config>();

            for (int i = 0; i < obj.Count; i++)
            {
                this.configs.Add(obj[i]);
            }
        }
    }
}
