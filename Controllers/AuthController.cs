using System.Threading.Tasks;
using AuthNetCore.Models;
using AuthNetCore.Repository;
using AuthNetCore.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AuthNetCore.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}