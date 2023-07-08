﻿using System.Collections;
using NLog;

namespace GeekDB.WebGUI.Utils
{
    public static class AppExitHandler
    {
        static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
        static Action callBack;
        public static void Init(Action exitCallBack)
        {
            callBack = exitCallBack;
            OnExit(exitCallBack);
            //Fetal异常监听
            AppDomain.CurrentDomain.UnhandledException += (s, e) => { HandleFetalException(e.ExceptionObject); };
        }

        public static void OnExit(Action exitCallBack)
        {
            //退出监听
            AppDomain.CurrentDomain.ProcessExit += (s, e) => { exitCallBack?.Invoke(); };
            //ctrl+c
            Console.CancelKeyPress += (s, e) => { exitCallBack?.Invoke(); };
        }

        private static void HandleFetalException(object e)
        {
            LOGGER.Error("get unhandled exception");
            if (e is IEnumerable arr)
            {
                foreach (var ex in arr)
                    LOGGER.Error($"Unhandled Exception:{ex}");
            }
            else
            {
                LOGGER.Error($"Unhandled Exception:{e}");
            }
            callBack?.Invoke();
        }
    }
}
