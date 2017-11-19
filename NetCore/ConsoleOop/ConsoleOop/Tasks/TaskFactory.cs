using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleOop.Tasks
{
    /// <summary>
    /// 執行備份工廠模式
    /// </summary>
    class TaskFactory
    {
        /// <summary>
        /// 執行備份類別命名空間
        /// </summary>
        private const string InstanceNamespace = "ConsoleOop.Tasks.";

        /// <summary>
        /// 執行備份類別物件
        /// </summary>
        /// <param name="instance">執行備份類別</param>
        /// <returns>備份類別物件</returns>
        public static ITask Create(string task)
        {
            /// 讀取備份來源類別設定檔
            string jsonString = File.ReadAllText("task_mapping.json");

            /// 類別設定檔
            var handlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            /// 取得對應執行備份
            var instance = handlerDictionary.Where(p => p.Key == task).Select(p => p.Value).FirstOrDefault<string>();

            /// 建立執行備份類別
            return (ITask)Activator.CreateInstance(Type.GetType(InstanceNamespace + instance));
        }
    }
}
