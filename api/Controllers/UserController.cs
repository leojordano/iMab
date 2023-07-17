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
                var userIsValid = _userRepository.CheckIfUserIsValid(userViewModel.Name, userViewModel.Email); 
                
                if(!userIsValid.IsValid) {
                    return NotFound(userIsValid.Message);
                }

                if(userViewModel.Password == "") {
                    return NotFound("O campo de senha não pode ser vazio!");
                }

                string HashPassword = _userRepository.EncryptPassword(userViewModel.Password);

                var user = new User(
                    userViewModel.Name, 
                    userViewModel.Email,
                    HashPassword,
                    userViewModel.AccessLevel
                );

                _userRepository.Register(user);

                return Ok(new {
                    message = userIsValid.Message,
                    user
                });
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