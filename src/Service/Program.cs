using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MessageBroker;
using Service.Client;
using Newtonsoft.Json;
using Service.Controllers;

namespace Service
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Consumer();
      BuildWebHost(args).Run();
    }

    static void MessageHandler(string message)
    {
      Message m = JsonConvert.DeserializeObject<Message>(message);

      ValuesControllerClient client = new ValuesControllerClient();
      var r = client.AddAsync(m);
      if (r) Console.WriteLine($"process success {message}");
      else
      {
        Console.WriteLine("processing error!");
      }
    }

    static void Consumer()
    {
      Consumer consummer = new Consumer();

      consummer.Start("test-queue", MessageHandler);

      Console.WriteLine("Consumer is ready.");
    }

    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
  }

  
}
