using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Entities;

namespace Service.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody]TodoTask message)
    {
      Thread.Sleep(10000);

      if (message.Name.Equals("error")) return BadRequest();
      return Ok(message.Name);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
