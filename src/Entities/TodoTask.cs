using System;

namespace Entities
{
  public class TodoTask
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public bool IsComplited { get; set; }
  }
}
/*
{
  'Id': '1',
  'Name': 'Connect to vm from host',
  'Time': '5/01/2018',
  'IsComplited': 'false',
}
*/