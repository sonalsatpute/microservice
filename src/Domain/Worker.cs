using Entities;
using Newtonsoft.Json;
using System;

namespace Adaptor
{
  public class Worker
  {
    public Worker()
    {
    }

    public bool MessageHandler(string message)
    {
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

      TodoTask task = JsonConvert.DeserializeObject<TodoTask>(message);
      Console.WriteLine($"{DateTime.Now.ToShortTimeString()} : {task.Name}");

      return true;
    }
  }
}
