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
      _client.BaseAddress = new Uri("http://localhost:61082");
      //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
      //_client.DefaultRequestHeaders.Accept.Add(contentType);
    }


    
    public string Get()
    {
      //Todo: test should be deleted.
      using (HttpClient client = new HttpClient())
      {
        client.BaseAddress = new Uri("http://localhost:61082");
        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        HttpResponseMessage response = client.GetAsync("/api/values").Result;
        string stringData = response.Content.ReadAsStringAsync().Result;
        return stringData;
      }
    }
    public bool AddAsync(Message message)
    {
      HttpContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
      HttpResponseMessage response =  _client.PostAsync("http://localhost:61082/api/values", content).Result;
      return response.IsSuccessStatusCode;
    }
  }
}
