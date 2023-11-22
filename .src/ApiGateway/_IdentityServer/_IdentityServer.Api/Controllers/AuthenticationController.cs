using _IdentityServer.Business.Managements.Abstract;
using _IdentityServer.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace _IdentityServer.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationOperations authentication;
        public AuthenticationController(IAuthenticationOperations _authentication)
        {
            authentication= _authentication;
        }



        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserForLoginDto _userForLogin)
        {
            var userToLogin =await authentication.Login(_userForLogin.Email, _userForLogin.Password);
            return userToLogin.Success ? Ok(userToLogin): BadRequest(userToLogin); 
        }


        [HttpPost("ForgotMyPassword")]
        public async Task<ActionResult> ForgotMyPassword(UserForLoginDto _userForLogin)
        {
            var userToLogin = await authentication.ForgotMyPassword(_userForLogin.Email);
            return userToLogin.Success ? Ok(userToLogin) : BadRequest(userToLogin);
        }



    }
}
