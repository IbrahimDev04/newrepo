using AutoMapper;
using EcoCoinUni.Dtos.UserDtos;
using EcoCoinUni.Entities;
using EcoCoinUni.Exceptions.UserExceptions;
using EcoCoinUni.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcoCoinUni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly UserManager<AppUser> _userManager;
        readonly IConfiguration _configuration;
        public AuthController(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration = null)
        {
            _userManager = userManager;
            _configuration = configuration;
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            //var user = _mapper.Map<AppUser>(dto);
            var user = new AppUser
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                UserName = dto.Username
            };
            if (await _userManager.Users.AnyAsync(u => dto.Username == u.UserName || dto.Email == u.Email))
                return NotFound("Register failed for some reasons");
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                return NotFound(sb.ToString().TrimEnd());

            }
            return NoContent();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null) return NotFound("Username or Password is wrong!");
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) return BadRequest("Username or Password is wrong!");

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], 
                _configuration["Jwt:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(60),
                credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token =  handler.WriteToken(jwtSecurity);

            var item = new
            {
                Token = token,
                Expires = jwtSecurity.ValidTo,
                Username = user.UserName,
            };

            return Ok(item);
        }
    }
}
