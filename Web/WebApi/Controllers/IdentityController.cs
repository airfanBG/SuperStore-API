using Data.Services.DtoModels;
using Data.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserService userService;

        public IdentityController(UserService userService)
        {
            this.userService = userService;
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(UserRegisterDto model)
        {
            var res = userService.Register(model);
            if (!string.IsNullOrEmpty(res))
            {
                return Ok(res);
            }
            return BadRequest();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Register(UserLoginDto model)
        {
            var res = userService.Login(model);
            if (!string.IsNullOrEmpty(res))
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
