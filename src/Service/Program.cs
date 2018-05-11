﻿using System;
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
        Console.WriteLine("Enable to connect to RabbitMQ.");
        Environment.Exit(-1);
      }

      Worker worker = new Worker();
      connection.Subscribe("todo", worker.MessageHandler);
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
