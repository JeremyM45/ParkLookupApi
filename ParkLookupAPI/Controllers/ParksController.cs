using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkLookupAPI.Models;

namespace ParkLookupAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkLookupAPIContext _db;
    public ParksController(ParkLookupAPIContext db)
    {
      _db = db;
    }
    [HttpGet]
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
  }
}