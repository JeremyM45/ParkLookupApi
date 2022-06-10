using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ParkLookupAPI.Models
{
  public class ParkLookupAPIContext : IdentityDbContext
  {
    public ParkLookupAPIContext(DbContextOptions<ParkLookupAPIContext> options) : base(options) { }
    public DbSet<Park> Parks {get; set;}
  }
}