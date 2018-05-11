using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MessageBroker;
using Adaptor;

namespace Service
{
  public class Program
  {

    public static void Main(string[] args)
    {
      Consumer();
      Console.ReadLine();
      //BuildWebHost(args).RunAsync();
    }

   
    static void Consumer()
    {
      Settings settings = new Settings("localhost")
      {
        AppId = "microservice-sample-dotnetcore",
        ExchangeName = "dev-exchange",
        UserName = "sonal",
        Password = "sonal",
        PrefetchCount = 3,
        Timeout = 10,
        VirtualHost = "/",
        PersistentMessages = true
      };

      Connection connection = new Connection(settings);

      if (!connection.Connect())
      {
        Console.WriteLine("Connection error");
        return;
      }

      Worker worker = new Worker("");
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
