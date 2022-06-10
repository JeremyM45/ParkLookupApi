using Microsoft.EntityFrameworkCore;
namespace ParkLookupAPI.Models
{
  public class ParkLookupAPIContext : DbContext
  {
    public ParkLookupAPIContext(DbContextOptions<ParkLookupAPIContext> options) : base(options) { }
    public DbSet<Park> Parks {get; set;}
  }
}