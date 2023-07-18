using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.ViewModels;
using api.Interfaces;
using api.Models;
using api.Services;
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
        [Authorize]
        public IActionResult Register(UserViewModel userViewModel)
        {
            try {
                var userIsValid = _userRepository.CheckIfUserIsValidOnRegister(userViewModel);
                
                if(!userIsValid.IsValid) {
                    return NotFound(userIsValid.Message);
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

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel data)
        {
            var userIsValid = _userRepository.CheckIfUserIsValidOnLogin(data);

            if(!userIsValid.IsValid) {
                return NotFound(userIsValid.Message);
            }

            var user = _userRepository.GetUserByEmail(data.Email);
            var decryptPassword = _userRepository.DecryptPassword(user.Password);

            if(data.Password != decryptPassword) {
                return NotFound("Senha incorreta!");
            }
            
            user.Password = "";
            var token = TokenService.GenerateToken(user);
            
            return Ok(new {
                user,
                token
            });
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