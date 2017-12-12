using EasyNetQ;
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
      _bus = RabbitHutch.CreateBus(@"host=localhost;virtualHost=/;username=sonal;password=password;publisherConfirms=true;prefetchcount=5;product='microservice-sample-dotnetcore'");
    }

    public void Start(string queueName, MessageHandler handler)
    {
      IQueue queue = new Queue(queueName, false);
      _bus.Advanced.Consume(queue, (body, properties, info) => Task.Factory.StartNew(() =>
      {
        var p = properties;
        var i = info;
        var message = Encoding.UTF8.GetString(body);
        
        handler(message);
        //Console.WriteLine(message);
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