using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MessageBroker;


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
        Console.WriteLine("Connection error");
        return;
      }

      Worker worker = new Worker();
      connection.Subscribe("todo", worker.MessageHandler);
      connection.Subscribe("todo-x", worker.MessageHandler);


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
