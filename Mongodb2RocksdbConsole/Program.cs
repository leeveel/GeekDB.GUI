using CommandLine.Text;
using CommandLine;
using GeekDB;
using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using MongoDB.Driver;
using System.Xml.Linq;
using System.IO;

namespace Mongodb2RocksdbConsole
{
    internal class Program
    {
        public class Options
        {
            [Option('m', "mongodburl", Required = true, HelpText = "mongodb url")]
            public string MongodbUrl { get; set; }
            [Option('n', "mongodbdbname", Required = true, HelpText = "mongodb库名字")]
            public string MongodbDBName { get; set; }
            [Option('o', "output", Required = true, HelpText = "输出路径")]
            public string OutputPath { get; set; }
        }

        static void AddLog(LogType t, string s)
        {
            if (t == LogType.Info)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(s);
            }
            else if (t == LogType.Err)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(s);
            }
            Console.ResetColor();
        }

        static void RunOptions(Options opts)
        {
            var settings = MongoClientSettings.FromConnectionString(opts.MongodbUrl);
            var curMongoDbClient = new MongoClient(settings);
            if (curMongoDbClient.ListDatabaseNames().ToList().IndexOf(opts.MongodbDBName) < 0)
            {
                AddLog(LogType.Err, $"不能发现数据库:{opts.MongodbDBName}");
                return;
            }

            if (!Directory.Exists(opts.OutputPath))
            {
                Directory.CreateDirectory(opts.OutputPath);
            }

            var dataBase = curMongoDbClient.GetDatabase(opts.MongodbDBName);
            if (Directory.GetDirectories(opts.OutputPath).Length > 0 || Directory.GetFiles(opts.OutputPath).Length > 0)
            {
                AddLog(LogType.Err, $"导出失败,目录不为空:{opts.OutputPath}");
                return;
            }

            new MongoDbConvertToRocksdb().Run(dataBase, opts.OutputPath, AddLog, null).Wait();
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }
    }
}