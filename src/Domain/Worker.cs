using System;
using Entities;
using MessageBroker;
using Newtonsoft.Json;

namespace Service
{
  public class Worker
  {
    public bool MessageHandler(string message)
    {
      TodoTask task = JsonConvert.DeserializeObject<TodoTask>(message);

      Console.WriteLine($"{DateTime.Now} : {task.Name}");

      if (task.Name.StartsWith("Error"))
        throw new MessageProcessingException("some error message.");

      //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
      return true;
    }
  }
}
