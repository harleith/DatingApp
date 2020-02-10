using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.Models;
using DatingApp.API.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;
        public AuthenticateController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO model)
    {
        // validate request 
        if(ModelState.IsValid)
        {
        model.username = model.username.ToLower();

        bool existsUser = await _repo.UserExists(model.username);

        if(existsUser == true)
        {
            return BadRequest("Username Already Exists Dude");
        }
        
        User createUser = new User();

        createUser.username = model.username;

        var createdUser = await _repo.Register(createUser,model. password);

        return StatusCode(201);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto model)
    {
        if(ModelState.IsValid)
        {
            var userLogin =  await _repo.Login(model.username.ToLower(), model.Password);

            if(userLogin == null)
            {
                return Unauthorized();
            }

            // Claim claim = new Claim(ClaimTypes.NameIdentifier, userLogin.id.ToString());

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userLogin.id.ToString()),
                new Claim(ClaimTypes.Name, userLogin.username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var handlerToken = tokenHandler.WriteToken(token);

            return Ok(new { handlerToken });
        }
        else
        {
            return Unauthorized();
        }
    }
    }
}
