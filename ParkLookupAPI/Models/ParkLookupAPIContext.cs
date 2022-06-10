using Microsoft.EntityFrameworkCore;
namespace ParkLookupAPI.Models
{
  public class ParkLookupAPIContext : DbContext
  {
    public ParkLookupAPIContext(DbContextOptions<ParkLookupAPIContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Yosemite", Location = "Califonria", Jurisdiction = "National"},
          new Park { ParkId = 2, Name = "Bidwell", Location = "Califonria", Jurisdiction = "State"},
          new Park { ParkId = 3, Name = "YellowStone", Location = "Idaho & Wyoming", Jurisdiction = "National"}
        );
    }
    public DbSet<Park> Parks {get; set;}
  }
}