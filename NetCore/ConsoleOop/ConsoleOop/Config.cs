using System.Runtime.Serialization;

namespace ConsoleOop
{
    [DataContract]
    class Config
    {
        [DataMember]
        private string ext { get; set; }

        [DataMember]
        private string location { get; set; }

        [DataMember]
        private bool subDirectory { get; set; }

        [DataMember]
        private string unit { get; set; }

        [DataMember]
        private bool remove { get; set; }

        [DataMember]
        private string handler { get; set; }

        [DataMember]
        private string destination { get; set; }

        [DataMember]
        private string dir { get; set; }

        [DataMember]
        private string connectionString { get; set; }

        public string Ext { get { return this.ext; } }
        public string Location { get { return this.location; } }
        public bool SubDirectory { get { return this.subDirectory; } }
        public string Unit { get { return this.unit; } }
        public bool Remove { get { return this.remove; } }
        public string Handler { get { return this.handler; } }
        public string Destination { get { return this.destination; } }
        public string Dir { get { return this.dir; } }
        public string ConnectionString { get { return this.connectionString; } }

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
