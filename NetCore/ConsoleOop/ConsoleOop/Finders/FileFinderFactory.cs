﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleOop.Finders
{
    /// <summary>
    /// 備份來源工廠模式
    /// </summary>
    class FileFinderFactory
    {
        /// <summary>
        /// 備份來源類別命名空間
        /// </summary>
        private const string InstanceNamespace = "ConsoleOop.Finders.";

        /// <summary>
        /// 建立備份來源類別物件
        /// </summary>
        /// <param name="handler">備份來源</param>
        /// <returns>處理備份來源類別物件</returns>
        public static IFileFinder Create(string handler)
        {
            /// 讀取處理方式類別設定檔
            string jsonString = File.ReadAllText("finder_mapping.json");

            /// 類別設定檔
            var handlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            /// 取得對應處理方式
            var instance = handlerDictionary.Where(p => p.Key == handler).Select(p => p.Value).FirstOrDefault<string>();

            /// 建立處理方式類別
            return (IFileFinder)Activator.CreateInstance(Type.GetType(InstanceNamespace + instance));
        }
    }
}
