using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.ViewModels;
using api.Interfaces;
using api.Models;
using api.Enums;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public IActionResult Register(UserViewModel userViewModel)
        {
            try {
                if(_userRepository.CheckIfUserIsValid(userViewModel.Name, userViewModel.Email)) {
                    return NotFound("Usuario já cadastrado!");
                }

                string HashPassword = _userRepository.EncryptPassword(userViewModel.Password);

                var user = new User(
                    userViewModel.Name, 
                    userViewModel.Email,
                    HashPassword,
                    userViewModel.AccessLevel,
                    userViewModel.UserProfile
                );

                _userRepository.Register(user);

                return Ok();
            } catch(ArgumentException err) {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("AAA");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}