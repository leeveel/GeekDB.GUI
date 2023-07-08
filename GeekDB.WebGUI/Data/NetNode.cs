using MessagePack;
using System.Text.Json.Serialization;

namespace GeekDB.WebGUI.Data
{

    public enum NodeType
    {
        Client = 1,
        Login = 2,
        Game = 3,
        Center = 4,
        Gateway = 5,
        Rebalance = 6
    }

    [MessagePackObject(true)]
    public class NetNode
    {
        public int NodeId { get; set; }
        public int ServerId { get; set; }
        public NodeType Type { get; set; }
        public string Ip { get; set; }
        public int TcpPort { get; set; }
        public string InnerIp { get; set; }
        public int InnerTcpPort { get; set; }
        public int HttpPort { get; set; }
        public int RpcPort { get; set; }
        public NetNodeState State { get; set; } = new NetNodeState();
    }

    [MessagePackObject(true)]
    public class NetNodeState
    {
        //承载上限
        public int MaxLoad { get; set; } = int.MaxValue;
        //当前承载
        public int CurrentLoad { get; set; } = 0;
        //连接的逻辑服ids 
        [JsonIgnore]
        public List<long> logicServerList = new List<long>();
        [JsonIgnore]
        public string LogicServerList
        {
            get
            {
                return string.Join(",", logicServerList);
            }
        }
    }
}
