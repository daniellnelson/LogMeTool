using log4net;
using log4net.Core;
using LogMeTool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogMeTool
{
    public class Logging
    {
        #region declarations
        private static readonly ILog log = LogManager.GetLogger(typeof(Logging));
        #endregion


        public static void ChangeLogLevel(LogType type)
        {
            switch (type)
            {
                case LogType.Debug:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    Debug("Logger changed to Debug");

                    break;
                case LogType.On:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.All;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    Debug("Logger turned on.");
                    break;

                case LogType.Off:
                    Debug("Logger is turning off.");
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Off;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
                case LogType.Info:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Info;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
                case LogType.Error:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Error;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
                case LogType.All:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.All;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
                case LogType.Failure:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Fatal;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
                case LogType.Success:
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Warn;
                    ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
                    break;
            }
        }

        public static void Debug(string message)
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
        public static void Error(string message)
        {
            if (log.IsErrorEnabled)
            {
                log.Logger.Log(new LoggingEvent(new LoggingEventData
                {
                    Level = Level.Error,
                    Message = $"\"Error {message} \"",
                    TimeStamp = DateTime.Now

                }));
            }
        }
        public static void Info(string message)
        {
            if (log.IsInfoEnabled)
            {
                log.Logger.Log(new LoggingEvent(new LoggingEventData
                {
                    Level = Level.Info,
                    Message = $"\"Info: {message} \"",
                    TimeStamp = DateTime.Now

                }));
            }
        }
        public static void Failure(string message)
        {
            if (log.IsDebugEnabled)
            {
                log.Logger.Log(new LoggingEvent(new LoggingEventData
                {
                    Level = Level.Fatal,
                    Message = $"\"Failure: {message} \"",
                    TimeStamp = DateTime.Now

                }));
            }
        }
        public static void Success(string message)
        {
            if (log.IsDebugEnabled)
            {
                log.Logger.Log(new LoggingEvent(new LoggingEventData
                {
                    Level = Level.Warn,
                    Message = $"\"Success: {message} \"",
                    TimeStamp = DateTime.Now

                }));
            }
        }
    }
}
