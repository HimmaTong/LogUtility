﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.Logs
{

  /// <summary>
  /// 将日志信息输出到控制台的日志记录器
  /// </summary>
  public class ConsoleLogger : AsyncTextLogger
  {


    /// <summary>
    /// 创建 ConsoleLogger 实例
    /// </summary>
    /// <param name="filter">日志筛选器，确定哪些日志需要被记录</param>
    public ConsoleLogger( LogFilter filter = null ) : base( filter ) { }


    private static object _sync = new object();

    /// <summary>
    /// 重写 WriteLogMessage 方法，在控制台输出日志信息
    /// </summary>
    /// <param name="entry">日志条目</param>
    /// <param name="contents">要显示的文本内容</param>
    protected override Task WriteLogMessageAsync( LogEntry entry, string[] contents )
    {
      lock ( _sync )
      {
        foreach ( var line in contents )
          Console.WriteLine( line );
      }

      return Task.Run( () => { } );
    }

    /// <summary>
    /// 重写 GetPadding 方法，返回空字符串，在控制台显示时取消填充
    /// </summary>
    /// <param name="entry">当前要记录的日志条目</param>
    /// <returns>永远返回空字符串</returns>
    protected override string GetPadding( LogEntry entry )
    {
      return "";
    }


  }

}
