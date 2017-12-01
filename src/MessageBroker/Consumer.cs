﻿using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker
{
  public class Consumer : IDisposable
  {
    IBus _bus;

    public Consumer()
    {
      _bus = RabbitHutch.CreateBus(@"host=localhost;virtualHost=/;username=sonal;password=password");
    }

    public void Start(string queueName)
    {
      Console.WriteLine("Start method");

      IQueue queue = new Queue(queueName, false);
      _bus.Advanced.Consume(queue, (body, properties, info) => Task.Factory.StartNew(() =>
      {
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine(message);

      }));
    }

    #region "IDisposable"

    private bool _disposed;

    public void Dispose()
    {
      Dispose(true);
    }

    void Dispose(bool disposing)
    {
      if (_disposed) return;

      if (disposing)
      {
        // Free any other managed objects here. 
        if (_bus != null) _bus.Dispose();
      }

      // Free any unmanaged objects here. 
      _disposed = true;
    }

    #endregion
  }

}