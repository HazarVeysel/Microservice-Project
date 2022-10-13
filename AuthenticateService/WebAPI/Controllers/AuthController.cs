using Business.Concrete;
using Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegister)
        {
            var userExists = _authService.UserExists(userForRegister.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            //var entrytypeExists = _authService.EntryTypeExists(userAndEntryTypeRegister.EntryType);
            //if (!entrytypeExists.Success)
            //{
            //    return BadRequest(userExists.Message);
            //}

            var registerResult = _authService.Register(userForRegister, userForRegister.Password);

            //var result = _authService.CreateAccessToken(registerResult.Data, registerResult.Data.EntryTypeId);

            if (registerResult.Success)
            {
                return Ok(registerResult);
            }
            return BadRequest(registerResult.Message);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }


            var result = _authService.CreateAccessToken(userToLogin.Data, 0);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);



        }
    }
}
