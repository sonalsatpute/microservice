using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using MessageBroker;
using Microsoft.AspNetCore.Http;
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

    /// <summary>
    /// TodoController Constructor
    /// </summary>
    /// <param name="connection"></param>
    public TodoController(IConnection connection)
    {
      _connection = connection;
    }

    /// <summary>
    /// Add new message in Queue
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <param name="task"></param>
    /// <returns></returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>  
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