using Data.Services.Interfaces;
using Data.Services.Services;
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
        private readonly ProductService service;

        public IWebHostBuilder WebHostBuilder { get; }
        public ProductController(IConfiguration root,ILogger<ProductController> logger, ProductService service)
        {
            this.config = root;
            this._logger = logger;
            this.service = service;
        }
        //api/product/get
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug(User.Identity.Name);
            _logger.LogInformation(User.Identity.Name);
           
            var value=config.GetSection("DevTest").Value;
            service.GetTopSellers(1010, 1);
            return Ok(value);
        }
        //api/product/getall/a HttpGet Action:GetAll(int a)

        //api/product  HttpGet Action: GetAll()
        //api/product  HttpPost Action: GetAllSecond()

        //api/product/1 HttpGet Action:GetAll(int a)

        //api/product/getall HttpGet Action:GetAllSecond()
        [HttpGet("{a}")]
        //[Route("getall")]
        public IActionResult GetAll(int a)
        {
            return Ok();
        }
        //[HttpGet]
        //[Route("getall")]
        //public IActionResult GetAllSecond()
        //{
        //    return Ok();
        //}
    }
}
