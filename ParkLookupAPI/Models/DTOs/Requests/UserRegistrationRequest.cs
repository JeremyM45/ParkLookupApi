using System.ComponentModel.DataAnnotations;

namespace ParkLookupAPI.Models.DTOs.Requests
{
  public class UserRegistrationRequest
  {
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    [Required]
    public string Username {get; set;}
    [Required]
    public string Password { get; set; }
  }
}