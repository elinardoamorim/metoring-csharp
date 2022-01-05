using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:ApiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if(user == null) return BadRequest("Invalid user request");
            var token = _loginBusiness.ValidateCredentials(user);
            if(token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenRefreshVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Invalid token request");
            var token = _loginBusiness.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest("Invalid token request");
            return Ok(token);
        }

        [HttpPatch("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var login = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(login);
            if (!result) return BadRequest("Invalid token request");
            return Ok();
        }
    }
}
