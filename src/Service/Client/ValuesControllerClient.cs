using Newtonsoft.Json;
using Service.Controllers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Service.Client
{
  public class ValuesControllerClient
  {
    HttpClient _client = new HttpClient();

    public ValuesControllerClient()
    {
      _client.BaseAddress = new Uri("http://localhost:61082/");
      _client.DefaultRequestHeaders.Accept.Clear();
      //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public bool AddAsync(Message message)
    {
      HttpContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
      HttpResponseMessage response =  _client.PostAsync("/api/values", content).Result;
      return response.IsSuccessStatusCode;
    }
  }
}
