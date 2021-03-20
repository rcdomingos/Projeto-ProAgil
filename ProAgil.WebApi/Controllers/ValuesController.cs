using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Data;
using ProAgil.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    public DataContext Context { get; }

    public ValuesController(DataContext context)
    {
      this.Context = context;

    }

    // GET api/values
    [HttpGet]
    // public ActionResult<IEnumerable<Evento>> Get()
    // {
    //   return Context.Eventos.ToList();
    // }
    public async Task<IActionResult> Get()
    {
      try
      {
        var results = await Context.Eventos.ToListAsync();

        return Ok(results);
      }
      catch (System.Exception err)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, err.ToString());
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var results = await Context.Eventos.FirstOrDefaultAsync(elemento => elemento.EventoId == id);

        return Ok(results);
      }
      catch (System.Exception err)
      {
        return this.StatusCode(StatusCodes.Status500InternalServerError, err.ToString());
      }
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
