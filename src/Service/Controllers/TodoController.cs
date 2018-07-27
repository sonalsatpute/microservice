using System;
using Entities;
using MessageBroker;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
  /// <summary>
  /// Todo controller
  /// </summary>
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class TodoController : Controller
  {
    private readonly IConnection _connection;

    public TodoController(IConnection connection)
    {
      _connection = connection;
    }

    [HttpPost]
    public IActionResult Post([FromBody]TodoTask task)
    {
      if (task == null) return BadRequest();

      _connection.Connect();
      task.Id = 1;// Guid.NewGuid();
      task.Time = DateTime.Now;
      _connection.Publish<TodoTask>("#.todo", task);

      return Ok(task);
    }
  }
}