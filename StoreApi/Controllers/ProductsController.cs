using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")] //localhost:5001/api/products/getfirst
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;
        private IApplicationBuilder applicationBuilder;
        public ProductsController(IWebHostEnvironment env, IApplicationBuilder app)
        {
            webHostEnvironment = env;
            applicationBuilder = app;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
          
            return Ok();
        }
       [Route("getfirst")]
       [HttpGet]
        public IActionResult GetFirst()
        {
            return Ok("first");
        }
    }
}
