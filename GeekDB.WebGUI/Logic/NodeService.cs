using GeekDB.WebGUI.Data;
using System.Collections.Concurrent;

namespace GeekDB.WebGUI.Logic
{
    public class NodeService
    {
        static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        //服务器节点的id 为自身的serverid
        internal readonly Dictionary<long, NetNode> nodeMap = new();
        public string CacheNodeMapJson { get; private set; } = "";

        public int NodeCount()
        {
            return nodeMap.Count;
        }

        public NetNode Remove(long id)
        {
            lock (nodeMap)
            {
                nodeMap.Remove(id, out var node);
                OnNodeChange();
                return node;
            }
        }


        public List<NetNode> GetAllNodes()
        {
            lock (nodeMap)
            {
                return nodeMap.Values.ToList();
            }
        }

        public NetNode Add(NetNode node)
        {
            Log.Debug($"新的网络节点:{node.NodeId} {node.Type}");
            lock (nodeMap)
            {
                nodeMap.TryGetValue(node.NodeId, out var old);
                nodeMap[node.NodeId] = node;
                OnNodeChange();
                return old != node ? old : null;
            }
        }

        public void SetNodeState(long nodeId, NetNodeState state)
        {
            //Log.Debug($"设置节点{nodeId}状态");
            lock (nodeMap)
            {
                if (nodeMap.TryGetValue(nodeId, out var node))
                {
                    node.State = state;
                }
                OnNodeChange();
            }
        }

        void OnNodeChange()
        {
            CacheNodeMapJson = System.Text.Json.JsonSerializer.Serialize(nodeMap);
        }
    }
}
