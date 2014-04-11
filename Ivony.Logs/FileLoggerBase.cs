﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ivony.Logs
{

  /// <summary>
  /// 文件日志记录器
  /// </summary>
  public abstract class FileLoggerBase : TextLogger
  {



    protected FileLoggerBase( ILogFilter filter = null, Encoding encoding = null )
      : base( filter )
    {
      _encoding = encoding ?? Encoding.UTF8;
    }

    protected abstract string GetFilepath( LogEntry entry );


    private Encoding _encoding;

    /// <summary>
    /// 获取写入文件所用的编码
    /// </summary>
    protected virtual Encoding Encoding
    {
      get { return _encoding; }
    }




    protected override void WriteLogeMessage( LogEntry entry, string[] lines )
    {
      var path = GetFilepath( entry );
      Directory.CreateDirectory( Path.GetDirectoryName( path ) );
      File.AppendAllLines( path, lines );
    }


  }
}
