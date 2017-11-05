using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 物件Manager抽象類別
    /// </summary>
    [DataContract]
    abstract class JsonManager
    {
        /// <summary>
        /// 實作解析JSON轉換物件
        /// </summary>
        abstract public void ProcessJsonConfig();

        /// <summary>
        /// 解析JSON檔案轉換Manager型別物件
        /// </summary>
        /// <typeparam name="T">Manager泛型</typeparam>
        /// <param name="path">JSON檔案位置</param>
        /// <returns>轉換Manager型別物件</returns>
        protected T GetJsonObject<T>(string path)
        {
            T obj = default(T);

            // 讀取 JSON 檔案內容
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(File.ReadAllText(path))))
            {
                // Deserialization from JSON
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));

                // 反解序列化物件
                obj = (T)deserializer.ReadObject(ms);
            }

            return obj;
        }
    }
}
