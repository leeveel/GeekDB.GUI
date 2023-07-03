using MongoDB.Bson;
using Newtonsoft.Json.Bson;

namespace Geek.Server.RemoteBackup.Logic
{
    public class MongoTimestampState
    {
        public const string UniqueId = nameof(Id);
        public const string TimestampName = nameof(Timestamp);

        public string Id { get; set; }

        /// <summary>
        /// 回存时间戳
        /// </summary>
        public long Timestamp { get; set; }
        public byte[] Data { get; set; }
    }

    public class MongoFile
    {
        public long length { get; set; }
        public int chunkSize { get; set; }
        public DateTime uploadDate { get; set; }
        public string md5 { get; set; }
        public string filename { get; set; }
        public ObjectId Id { get; set; }
        public string RocksdbId { get; set; }
        public byte[] Datas { get; set; }
    }
}
