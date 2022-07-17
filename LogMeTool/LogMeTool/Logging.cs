using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMeTool
{
    public static class Logging
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logging));

        public static void ChangeLogLevel(LogType type)
        {
            switch (type)
            {
                case LogType.Debug:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    LogPrint("Logger changed to Debug");

                    break;
                case LogType.On:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.All;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    LogPrint("Logger turned on.");
                    break;

                case LogType.Off:
                    LogPrint("Logger is turning off.");
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Off;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;


            }
        }

        public static void LogPrint(string message)
        {
            if(log.IsDebugEnabled)
            {
                log.Logger.Log(new LoggingEvent(new LoggingEventData
                {
                    Level = Level.Debug,
                    Message = $"\"Debug {message} \"",
                    TimeStamp = DateTime.Now

                }));
            }
        }
    }
}
