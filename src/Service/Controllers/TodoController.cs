using System;
using Entities;
using MessageBroker;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly IConnection _connection;
    public TodoController(IConnection connection)
    {
      _connection = connection;
    }

    [HttpPost]
    public ActionResult<TodoTask> Post(TodoTask task)
    {
      if (task == null) return BadRequest();

      _connection.Connect();
      task.Id = 1;// Guid.NewGuid();
      task.Time = DateTime.Now;
      _connection.Publish<TodoTask>("#.todo", task);

      return task;
    }

  }
}