using Entities;
using Newtonsoft.Json;
using System;

namespace Adaptor
{
  public class Worker
  {
    TodoControllerClient _client;

    public Worker(string url)
    {
      //_client = new TodoControllerClient(url);
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
