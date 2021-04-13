using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _business;

        public AuthController(ILoginBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Nullable user");
            var token = _business.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null) return BadRequest("Nullable user");
            var token = _business.ValidateCredentials(tokenVO);
            if (token == null) return Unauthorized();
            return Ok(token);
        }


        [HttpGet]
        [Route("logout")]
        [Authorize("Bearer")]
        public IActionResult Logout()
        {
            var userName = User.Identity.Name;
            bool result = _business.RevokeToken(userName);
            if (result != true) return BadRequest("Invalid client!");
            return NoContent();
        }
    }
}
