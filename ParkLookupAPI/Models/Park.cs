using System.ComponentModel.DataAnnotations;

namespace ParkLookupAPI.Models
{
  public class Park
  {
    public int ParkId {get; set;}
    [Required]
    [StringLength(30)]
    public string Name {get; set;}
    [Required]
    public string Location {get; set;}
    [Required]
    public string Jurisdiction {get; set;}
  }
}