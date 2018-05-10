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
      TodoTask task = JsonConvert.DeserializeObject<TodoTask>(message);
      //var result = _client.Process(m);



      Console.WriteLine($"{DateTime.Now.ToShortTimeString()} : {task.Name}");
      System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

      //if (result)
      //  Console.WriteLine($"process success {value}");
      //else
      //  Console.WriteLine("processing error!");

      return true;

    }
  }
}
