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
using System.Net.Http;
using System.Net.Http.Headers;


namespace Service
{
  public class Program
  {
    static ValuesControllerClient _client = new ValuesControllerClient();

    public static void Main(string[] args)
    {
      BuildWebHost(args).RunAsync();
      Consumer();

      Console.ReadKey();
    }

    static bool MessageHandler(string message)
    {
      Message m = JsonConvert.DeserializeObject<Message>(message);

      var r = _client.AddAsync(m);
      if (r) Console.WriteLine($"process success {message}");
      else
      {
        Console.WriteLine("processing error!");
      }

      return r;
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
