using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthNetCore.Models;
using AuthNetCore.Repository;
using AuthNetCore.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthNetCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AuthController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserResource userResource)
        {
            userResource.Username = userResource.Username.ToLower();

            if (await _unitOfWork.AuthRepository.UserExists(userResource.Username))
            {
                return BadRequest("Username is alredy taken.");
            }

            var userToCreate = new User
            {
                Username = userResource.Username,
                Email = userResource.Email
            };

            var createUser = await _unitOfWork.AuthRepository.Register(userToCreate, userResource.Password);

            _unitOfWork.Complete();

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var userFromRepo = await _unitOfWork.AuthRepository.Login(userLogin.Username.ToLower(), userLogin.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            //token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unitOfWork.Dispose();
        }
    }
}