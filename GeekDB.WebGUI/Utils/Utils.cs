using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace GeekDB.WebGUI.Utils
{
    public static class Utils
    {
        public static string FormatJson(string str)
        {
            //格式化json字符串
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }
                else
                {
                    return str;
                }
            }
            catch (Exception e)
            {
                return str;
            }
        }

        public static bool CheckJson(string str)
        {
            //格式化json字符串 
            try
            {
                if (str == null)
                {
                    return false;
                }
                str = str.Trim();
                if (str.StartsWith("{") && str.EndsWith("}") || str.StartsWith("[") && str.EndsWith("]"))
                {
                    var data = MessagePack.MessagePackSerializer.ConvertFromJson(str);
                    return data != null && data.Length > 0;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string GetSizeStr(ulong numBytes)
        {
            if (numBytes < 1024)
                return $"{numBytes} B";

            if (numBytes < 1048576)
                return $"{numBytes / 1024d:0.##} KB";

            if (numBytes < 1073741824)
                return $"{numBytes / 1048576d:0.##} MB";

            if (numBytes < 1099511627776)
                return $"{numBytes / 1073741824d:0.##} GB";

            if (numBytes < 1125899906842624)
                return $"{numBytes / 1099511627776d:0.##} TB";

            if (numBytes < 1152921504606846976)
                return $"{numBytes / 1125899906842624d:0.##} PB";

            return $"{numBytes / 1152921504606846976d:0.##} EB";
        }
    }
}
