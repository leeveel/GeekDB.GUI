using MessagePack;

namespace GeekDB.WebGUI.Data
{
    [MessagePackObject(true)]
    public class HistoryItem
    {
        public string path;
    }
}
