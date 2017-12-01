using MessageBroker;
using System;
using System.Threading;

namespace Service
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.ReadKey();
    }

    private static void Service()
    {
      Console.WriteLine("");
    }

    static void Consumer()
    {
      Consumer consummer = new Consumer();
      consummer.Start("test-queue");

      Console.WriteLine("Running other Thread");
    }
  }
}
