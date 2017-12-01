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

namespace Service
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Consumer();
      BuildWebHost(args).Run();
    }

    static void Consumer()
    {
      Consumer consummer = new Consumer();

      consummer.Start("test-queue");

      Console.WriteLine("Running other Thread");
    }

    public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
  }

  
}
