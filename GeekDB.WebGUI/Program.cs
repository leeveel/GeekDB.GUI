﻿using NLog;
using System.Diagnostics;
using System.Text;
using GeekDB.WebGUI.Common;
using GeekDB.WebGUI.Utils;

namespace GeekDB.WebGUI
{
    /// <summary>
    /// 核心功能:
    /// 1.注册与发现
    /// 2.配置中心
    /// 3.Actor路由
    /// </summary>
    internal class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static volatile bool ExitCalled = false;
        private static volatile Task GameLoopTask = null;
        private static volatile Task ShutDownTask = null;

        static async Task Main(string[] args)
        {
            try
            {
                //启动定时gc

                _ = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        GC.Collect();
                    }
                });

                AppExitHandler.Init(HandleExit);
                GameLoopTask = StartUp.Enter();
                await GameLoopTask;
                if (ShutDownTask != null)
                    await ShutDownTask;
            }
            catch (Exception e)
            {
                string error;
                if (Settings.AppRunning)
                {
                    error = $"服务器运行时异常 e:{e}";
                    Console.WriteLine(error);
                }
                else
                {
                    error = $"启动服务器失败 e:{e}";
                    Console.WriteLine(error);
                }
                File.WriteAllText("server_error.txt", $"{error}", Encoding.UTF8);
            }
        }

        private static void HandleExit()
        {
            if (ExitCalled)
                return;
            ExitCalled = true;
            Log.Info($"监听到退出程序消息");
            ShutDownTask = Task.Run(() =>
            {
                Settings.AppRunning = false;
                GameLoopTask?.Wait();
                LogManager.Shutdown();
                Console.WriteLine($"退出程序");
                Process.GetCurrentProcess().Kill();
            });
            ShutDownTask.Wait();
        }
    }
}