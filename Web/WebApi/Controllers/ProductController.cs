using Data.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductController> _logger;
        public IWebHostBuilder WebHostBuilder { get; }
        public ProductController(IConfiguration root,ILogger<ProductController> logger)
        {
            this.config = root;
            this._logger = logger;
        }

        public IActionResult Get()
        {
            _logger.LogDebug(User.Identity.Name);
            _logger.LogInformation(User.Identity.Name);

            var value=config.GetSection("DevTest").Value;
            return Ok(value);
        }
       
    }
}
