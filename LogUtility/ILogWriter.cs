﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogUtility
{
  public interface ILogWriter
  {
    public void Write( LogEntry entry );
  }
}
