using EasyNetQ;
using System;

namespace MessageBroker
{
  public class NullLogger : IEasyNetQLogger
  {
    public void DebugWrite(string format, params object[] args)
    {

    }

    public void ErrorWrite(string format, params object[] args)
    {
      
    }

    public void ErrorWrite(Exception exception)
    {
      
    }

    public void InfoWrite(string format, params object[] args)
    {
      
    }
  }
}
