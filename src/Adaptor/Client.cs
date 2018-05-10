using System;
using System.Net.Http;

namespace Adaptor
{
  public abstract class Client
  {
    protected HttpClient _client = new HttpClient();

    public Client(string url)
    {
      _client.BaseAddress = new Uri(url);
      _client.DefaultRequestHeaders.Accept.Clear();
    }
  }
}
