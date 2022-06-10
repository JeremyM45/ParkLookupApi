using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ParkLookupAPI.Configuration;
using Microsoft.Extensions.Options;
using ParkLookupAPI.Models.DTOs.Requests;
using ParkLookupAPI.Models.DTOs.Responses;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ParkLookupAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthManagementController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;
    public AuthManagementController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
    {
      _userManager = userManager;
      _jwtConfig = optionsMonitor.CurrentValue;
    }
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
    {
      if(ModelState.IsValid)
      {
        var existingUser = await _userManager.FindByEmailAsync(user.Email);
        if(existingUser != null)
        {
          return BadRequest(new RegistrationResponse(){
            Errors = new List<string>(){
              "Email Invalid Or Already In Use"
            },
            Success = false
          });
        }
        var newUser = new IdentityUser() {Email = user.Email, UserName = user.Username};
        var isCreated = await _userManager.CreateAsync(newUser, user.Password);
        if(isCreated.Succeeded)
        {
          var jwtToken = GenerateJwtToken(newUser);
          return Ok(new RegistrationResponse() {
            Success = true,
            Token = jwtToken
          });
        }
        else
        {
          return BadRequest(new RegistrationResponse(){
            Errors = isCreated.Errors.Select(e => e.Description).ToList(),
            Success = false
          });
        }
      }
      return BadRequest(new RegistrationResponse(){
        Errors = new List<string>() {
          "Invalid Playload"
        },
        Success = false
      });
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
    {
      if(ModelState.IsValid)
      {
        var existingUser = await _userManager.FindByEmailAsync(user.Email);
        if(existingUser == null)
        {
          return BadRequest(new RegistrationResponse(){
            Errors = new List<string>() {
              "Invalid login request"
            },
            Success = false
          });
        }
        var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
        if(!isCorrect)
        {
          return BadRequest(new RegistrationResponse(){
            Errors = new List<string>() {
              "Invalid login request"
            },
            Success = false
          });
        }
        var jwtToken = GenerateJwtToken(existingUser);
        return Ok(new RegistrationResponse(){
          Success = true,
          Token = jwtToken
        });
      }
      return BadRequest(new RegistrationResponse(){
        Errors = new List<string>() {
          "Invalid Playload"
        },
        Success = false
      });
    }
    private string GenerateJwtToken(IdentityUser user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor{
        Subject = new ClaimsIdentity(new []
        {
          new Claim("Id", user.Id),
          new Claim(JwtRegisteredClaimNames.Email, user.Email),
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var jwtToken = tokenHandler.WriteToken(token);
      return jwtToken;
    }
  }
}