using MessagePack;
using MessagePack.Resolvers;

namespace Geek.DB.Core
{
    public class Serializer
    {
        static MessagePackSerializerOptions opt;
        static void InitOpt()
        {
            if (MessagePackSerializer.DefaultOptions != opt)
            {
                opt = new MessagePackSerializerOptions(StandardResolver.Instance).WithCompression(MessagePackCompression.Lz4Block);
                MessagePackSerializer.DefaultOptions = opt;
            }
        }
        public static byte[] Serialize<T>(T value)
        {
            InitOpt();
            return MessagePackSerializer.Serialize(value);
        }
        public static T Deserialize<T>(byte[] data)
        {
            InitOpt();
            return MessagePackSerializer.Deserialize<T>(data);
        }
    }
}