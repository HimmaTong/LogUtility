﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivony.Logs
{
  public static class LogExtensions
  {


    /// <summary>
    /// 记录一个信息性日志
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogInfo( this Logger logger, string message, params object[] args )
    {
      LogWithCustomType( logger, LogType.Info, message, args );
    }

    /// <summary>
    /// 记录一个警告信息
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogWarning( this Logger logger, string message, params object[] args )
    {
      LogWithCustomType( logger, LogType.Warning, message, args );
    }


    /// <summary>
    /// 记录一个错误信息
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogError( this Logger logger, string message, params object[] args )
    {
      LogWithCustomType( logger, LogType.Error, message, args );
    }


    /// <summary>
    /// 记录一个异常信息
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogException( this Logger logger, Exception exception )
    {
      LogWithCustomType( logger, LogType.Exception, exception.ToString() );
    }

    
    /// <summary>
    /// 记录一个致命错误信息
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogFatalError( this Logger logger, string message, params object[] args )
    {
      LogWithCustomType( logger, LogType.FatalError, message, args );
    }


    /// <summary>
    /// 记录一个引起系统崩溃无法恢复的错误信息
    /// </summary>
    /// <param name="logger">日志记录器</param>
    /// <param name="message">日志消息</param>
    /// <param name="args">日志消息参数</param>
    public static void LogCrashError( this Logger logger, string message, params object[] args )
    {
      LogWithCustomType( logger, LogType.CrashError, message, args );
    }



    private static void LogWithCustomType( Logger logger, LogType type, string message, params object[] args )
    {
      var meta = LogMeta.Blank;
      meta.Type = type;

      if ( args.Any() )
        message = string.Format( message, args );

      logger.LogEntry( new LogEntry( message, meta ) );
    }

  }
}
