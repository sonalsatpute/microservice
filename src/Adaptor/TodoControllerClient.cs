using Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Adaptor
{
  public class TodoControllerClient : Client
  {
    public TodoControllerClient(string url) : base(url)
    {
    }

    public bool Process(TodoTask task)
    {
      HttpContent content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
      HttpResponseMessage response = _client.PostAsync("/api/todo", content).Result;
      return response.IsSuccessStatusCode;
    }
  }
}
