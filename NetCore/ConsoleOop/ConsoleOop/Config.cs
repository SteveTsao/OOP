using System.Runtime.Serialization;

namespace ConsoleOop
{
    /// <summary>
    /// 檔案處理設定類別
    /// </summary>
    [DataContract]
    class Config
    {
        /// <summary>
        /// 序列化:備份檔案的目錄
        /// </summary>
        [DataMember]
        private string ext { get; set; }

        /// <summary>
        /// 序列化:備份檔案的目錄
        /// </summary>
        [DataMember]
        private string location { get; set; }

        /// <summary>
        /// 序列化:是否處理子目錄
        /// </summary>
        [DataMember]
        private bool subDirectory { get; set; }

        /// <summary>
        /// 序列化:設定備份單位
        /// </summary>
        [DataMember]
        private string unit { get; set; }

        /// <summary>
        /// 序列化:處理完是否刪除檔案
        /// </summary>
        [DataMember]
        private bool remove { get; set; }

        /// <summary>
        /// 序列化:處理方式
        /// </summary>
        [DataMember]
        private string handler { get; set; }

        /// <summary>
        /// 序列化:處理後儲存目的
        /// </summary>
        [DataMember]
        private string destination { get; set; }

        /// <summary>
        /// 序列化:處理後的目錄
        /// </summary>
        [DataMember]
        private string dir { get; set; }

        /// <summary>
        /// 序列化:資料庫連接字串
        /// </summary>
        [DataMember]
        private string connectionString { get; set; }

        /// <summary>
        /// 備份檔案的目錄
        /// </summary>
        public string Ext { get { return this.ext; } }

        /// <summary>
        /// 備份檔案的目錄
        /// </summary>
        public string Location { get { return this.location; } }

        /// <summary>
        /// 是否處理子目錄
        /// </summary>
        public bool SubDirectory { get { return this.subDirectory; } }

        /// <summary>
        /// 設定備份單位
        /// </summary>
        public string Unit { get { return this.unit; } }

        /// <summary>
        /// 處理完是否刪除檔案
        /// </summary>
        public bool Remove { get { return this.remove; } }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string Handler { get { return this.handler; } }

        /// <summary>
        /// 處理後儲存目的
        /// </summary>
        public string Destination { get { return this.destination; } }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir { get { return this.dir; } }

        /// <summary>
        /// 資料庫連接字串
        /// </summary>
        public string ConnectionString { get { return this.connectionString; } }

        /// <summary>
        /// 建構子 屬性初始設定
        /// </summary>
        /// <param name="_ext">檔案格式</param>
        /// <param name="_location">備份檔案的目錄</param>
        /// <param name="_subDirectory">是否處理子目錄</param>
        /// <param name="_unit">設定備份單位</param>
        /// <param name="_remove">處理完是否刪除檔案</param>
        /// <param name="_handler">處理方式</param>
        /// <param name="_destination">處理後儲存目的</param>
        /// <param name="_dir">處理後的目錄</param>
        /// <param name="_connectionString">資料庫連接字串</param>
        public Config(string _ext, string _location, bool _subDirectory, string _unit, bool _remove, string _handler, string _destination, string _dir, string _connectionString)
        {
            this.ext = _ext;
            this.location = _location;
            this.subDirectory = _subDirectory;
            this.unit = _unit;
            this.remove = _remove;
            this.handler = _handler;
            this.destination = _destination;
            this.dir = _dir;
            this.connectionString = _connectionString;
        }
    }
}
