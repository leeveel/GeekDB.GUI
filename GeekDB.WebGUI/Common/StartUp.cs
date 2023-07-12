using GeekDB.WebGUI.Utils;
using GeekDB.WebGUI.Web;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace GeekDB.WebGUI.Common
{
    internal class StartUp
    {
        static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public static async Task Enter()
        {
            try
            {
                var flag = Start();
                if (!flag) return; //启动服务器失败 

                Log.Info("服务器开始启动...");
                await WebServer.Start(Settings.InsAs<CenterSetting>().WebServerUrl);

                Settings.LauchTime = DateTime.Now;
                Settings.AppRunning = true;

                ////服务节点添加自己
                //ServiceManager.NodeService.Add(new Core.Center.NetNode
                //{
                //    NetId = Settings.ServerId,
                //    ServerId = Settings.ServerId,
                //    Type = Core.Center.NodeType.Center,
                //    RpcPort = Settings.RpcPort,
                //    HttpPort = Settings.HttpPort
                //});

                TimeSpan delay = TimeSpan.FromSeconds(1);
                while (Settings.AppRunning)
                {
                    await Task.Delay(delay);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"服务器执行异常，e:{e}");
                Log.Fatal(e);
            }

            Console.WriteLine($"退出服务器开始");
            await WebServer.Stop();
            Console.WriteLine($"退出服务器成功");
        }

        private static bool Start()
        {
            try
            {
                Console.WriteLine("init NLog config...");
                LayoutRenderer.Register<NLogConfigurationLayoutRender>("logConfiguration");
                LogManager.Configuration = new XmlLoggingConfiguration("Configs/center_log.config");
                LogManager.AutoShutdown = false;
                Settings.Load<CenterSetting>("Configs/webgui_config.json", ServerType.Center);
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"启动服务器失败,异常:{e}");
                return false;
            }
        }
    }
}
