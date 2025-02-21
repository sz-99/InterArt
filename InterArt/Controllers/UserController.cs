using Microsoft.AspNetCore.Mvc;
using InterArt_Backend.Models.DTOs;
using InterArt_Backend.Services;

namespace InterArt_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult PostSignUp(UserSignUpDTO signUpDTO)
        {
            var result = _userService.SignUpUser(signUpDTO);
            if(result != null) return Ok(result);
            return BadRequest();
        }
    }
}
