using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker
{
  public class Connection : IDisposable, IConnection
  {
    private readonly IExchange _exchange;
    private readonly ConnectionConfiguration _connection;
    private readonly MessageProperties _properties;

    private IBus _bus;

    public Connection(Settings settings)
    {
      _exchange = new Exchange(settings.ExchangeName);
      _properties = new MessageProperties { AppId = settings.AppId };

      _connection = new ConnectionConfiguration
      {
        VirtualHost = settings.VirtualHost,
        UserName = settings.UserName,
        Password = settings.Password,
        PrefetchCount = settings.PrefetchCount,
        Timeout = settings.Timeout,
        PersistentMessages = settings.PersistentMessages,
        Hosts = settings.HostNames.Select(hostName => new HostConfiguration { Host = hostName }).ToList(),
        PublisherConfirms = true
      };
    }

    public bool Connect()
    {
      _bus = RabbitHutch.CreateBus(_connection, registerService => registerService.Register(_ => new NullLogger()));
      return _bus.IsConnected;
    }

    public void Subscribe(string queueName, MessageHandler handler)
    {
      IQueue queue = new Queue(queueName, false);
      _bus.Advanced.Consume(queue, (body, properties, info) => Task.Factory.StartNew(() => OnMessage(body, handler)));
    }

    public void Publish<T>(string routingKey, T message) where T : class
    {
      var m = new Message<T>(message, _properties);
      _bus.Advanced.Publish(_exchange, routingKey, true, m);
    }

    private void OnMessage(byte[] body, MessageHandler handler)
    {
      var message = Encoding.UTF8.GetString(body);
      handler(message);
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
