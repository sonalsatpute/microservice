using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MessageBroker;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Service
{
  public class Program
  {
    public static void Main(string[] args)
    {
      IWebHost host = BuildWebHost(args);

      IServiceProvider provider = host.Services;
      IConnection connection = (IConnection)provider.GetService(typeof(IConnection));

      Consumer(connection);
      host.Run();
    }

    static void Consumer(IConnection connection)
    {
      if (!connection.Connect())
      {
        Console.WriteLine("RabbitMQ: Connection fail");
        //Thread.Sleep(TimeSpan.FromSeconds(30));
        Environment.Exit(-1);
      }

      Worker worker = new Worker();
      connection.Subscribe("todo", worker.MessageHandler);
      Console.WriteLine("Consumer is ready.");
    }

    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((context, logging) =>
                  {
                    logging.ClearProviders();
                  })
                .Build();
  }
}
