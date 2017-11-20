using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleOop.Handlers
{
    /// <summary>
    /// 備份檔案處理工廠模式
    /// </summary>
    class HandlerFactory
    {
        /// <summary>
        /// 檔案處理方式類別命名空間
        /// </summary>
        private const string InstanceNamespace = "ConsoleOop.Handlers.";

        /// <summary>
        /// 建立處理方式類別物件
        /// </summary>
        /// <param name="handler">處理方式</param>
        /// <returns>處理方式類別物件</returns>
        public static IHandler Create(string handler)
        {
            /// 讀取處理方式類別設定檔
            string jsonString = File.ReadAllText("handler_mapping.json");

            /// 類別設定檔
            var handlers = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            /// 取得對應處理方式
            var instance = handlers.Where(p => p.Key == handler).Select(p => p.Value).FirstOrDefault<string>();

            /// 建立處理方式類別
            return (IHandler)Activator.CreateInstance(Type.GetType(InstanceNamespace + instance));
        }
    }
}
