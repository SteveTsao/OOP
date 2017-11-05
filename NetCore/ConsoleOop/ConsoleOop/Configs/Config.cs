using System.Runtime.Serialization;

namespace ConsoleOop.Configs
{
    /// <summary>
    /// 檔案處理設定類別
    /// </summary>
    [DataContract]
    class Config
    {
        /// <summary>
        /// 序列化:備份檔案的目錄(對應JOSN.ext鍵值)
        /// </summary>
        [DataMember(Name = "ext")]
        public readonly string Ext;

        /// <summary>
        /// 序列化:備份檔案的目錄(對應JOSN.location鍵值)
        /// </summary>
        [DataMember(Name ="location")]
        public readonly string Location;

        /// <summary>
        /// 序列化:是否處理子目錄(對應JOSN.subDirectory鍵值)
        /// </summary>
        [DataMember(Name = "subDirectory")]
        public readonly bool SubDirectory;

        /// <summary>
        /// 序列化:設定備份單位(對應JOSN.unit鍵值)
        /// </summary>
        [DataMember(Name = "unit")]
        public readonly string Unit;

        /// <summary>
        /// 序列化:處理完是否刪除檔案(對應JOSN.remove鍵值)
        /// </summary>
        [DataMember(Name = "remove")]
        public readonly bool Remove;

        /// <summary>
        /// 序列化:處理方式(對應JOSN.handlers鍵值)
        /// </summary>
        [DataMember(Name = "handlers")]
        public readonly string[] Handlers;

        /// <summary>
        /// 序列化:處理後儲存目的(對應JOSN.destination鍵值)
        /// </summary>
        [DataMember(Name = "destination")]
        public readonly string Destination;

        /// <summary>
        /// 序列化:處理後的目錄(對應JOSN.dir鍵值)
        /// </summary>
        [DataMember(Name ="dir")]
        public readonly string Dir;

        /// <summary>
        /// 序列化:資料庫連接字串(對應JOSN.connectionString鍵值)
        /// </summary>
        [DataMember(Name = "connectionString")]
        public readonly string ConnectionString;
        
        /// <summary>
        /// 建構子 屬性初始設定
        /// </summary>
        /// <param name="ext">檔案格式</param>
        /// <param name="location">備份檔案的目錄</param>
        /// <param name="subDirectory">是否處理子目錄</param>
        /// <param name="unit">設定備份單位</param>
        /// <param name="remove">處理完是否刪除檔案</param>
        /// <param name="handlers">處理方式</param>
        /// <param name="destination">處理後儲存目的</param>
        /// <param name="dir">處理後的目錄</param>
        /// <param name="connectionString">資料庫連接字串</param>
        public Config(string ext, string location, bool subDirectory, string unit, bool remove, string[] handlers, string destination, string dir, string connectionString)
        {
            this.Ext = ext;
            this.Location = location;
            this.SubDirectory = subDirectory;
            this.Unit = unit;
            this.Remove = remove;
            this.Handlers = handlers;
            this.Destination = destination;
            this.Dir = dir;
            this.ConnectionString = connectionString;
        }
    }
}
