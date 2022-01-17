﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public ActionResult<UserVO> Create([FromBody] UserVO user)
        {
            if(user == null) return BadRequest("Invalid user request");
            if (!_userBusiness.Create(user)) return BadRequest("Failed to register the user");
            return Ok();
        }
    }
}
