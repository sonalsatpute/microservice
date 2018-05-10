using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class TodoController : Controller
  {

    [HttpPost]
    public IActionResult Post([FromBody]TodoTask task)
    {
      Thread.Sleep(10000);
      //task.Id = Guid.NewGuid();
      task.Time = DateTime.Now;

      return Ok(task);
    }
  }
}