using LAZADAKS.DATA.ICONFIGURATION;
using LAZADAKS.DATA.JWT.AUTHENTICATION;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLazaDaks.Controllers.LOGIN_CONTROLLER
{

    public class LoginController : BaseApiController
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = " Email or Password is incorrect!" });

            return Ok(response);


        }



    }
}
