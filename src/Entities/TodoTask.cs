using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
  public class TodoTask
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public DateTime Time { get; set; }

    [DefaultValue(false)]
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