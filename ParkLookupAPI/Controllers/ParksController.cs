using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookupAPI.Models;

namespace ParkLookupAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkLookupAPIContext _db;
    public ParksController(ParkLookupAPIContext db)
    {
      _db = db;
    }
    /// <summary>
    /// Returns the list of parks
    /// </summary>
    /// <remarks>
    /// Sample Request: Get /api/parks
    /// </remarks>
    ///<response code ="200"> Returns the list of Parks</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string location, string jurisdiction)
    {
      var query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }
      if (location != null)
      {
        query = query.Where(e => e.Location == location);
      }
      if (jurisdiction != null)
      {
        query = query.Where(e => e.Jurisdiction == jurisdiction);
      }
      return await query.ToListAsync();
    }
    /// <summary>
    /// Adds a park to the list of parks
    /// </summary>
    /// <remarks>
    /// Sample Request: Post /api/parks
    /// </remarks>
    ///<response code ="201"> Park Created</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new {id = park.ParkId}, park);
    }
    /// <summary>
    /// Returns a park from the list of parks by id
    /// </summary>
    /// <remarks>
    /// Sample Request: Get /api/parks/2
    /// </remarks>
    ///<response code ="200"> Returns a Park</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if(park == null)
      {
        return NotFound();
      }
      return park;
    }
    /// <summary>
    /// Edits a specific park
    /// </summary>
    /// <remarks>
    /// Sample Request: Get /api/parks/2
    /// </remarks>
    ///<response code ="204"> Park Edited</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if(id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    /// <summary>
    /// Deletes a Park
    /// </summary>
    /// <remarks>
    /// Sample Request: Get /api/parks/2
    /// </remarks>
    ///<response code ="204"> Park Deleted</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if(park == null)
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(p => p.ParkId == id);
    }
  }
}