using Data.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration config;

        public IWebHostBuilder WebHostBuilder { get; }
        public ProductController(IConfiguration root)
        {
            this.config = root;
        }

        public IActionResult Get()
        {
            var value=config.GetSection("Test").Value;
            return Ok();
        }
       
    }
}
