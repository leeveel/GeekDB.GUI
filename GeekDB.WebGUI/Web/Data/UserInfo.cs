using MessagePack;

namespace GeekDB.WebGUI.Web.Data
{
    [MessagePackObject(true)]
    public class UserInfo
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
