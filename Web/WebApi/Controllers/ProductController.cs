using Data.Services.Interfaces;
using Data.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment webHost;

        public IWebHostBuilder WebHostBuilder { get; }
        public ProductController(IConfiguration root, ILogger<ProductController> logger, ProductService service, IWebHostEnvironment webHost)
        {
            this.config = root;
            this._logger = logger;
            this.service = service;
            this.webHost = webHost;
        }
        //api/product/get
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    _logger.LogDebug(User.Identity.Name);
        //    _logger.LogInformation(User.Identity.Name);

        //    var value = config.GetSection("DevTest").Value;
        //    service.GetTopSellers(1010, 1);
        //    return Ok(value);
        //}

        [HttpGet]
        [Route("allproducts")]
        //[Route("getall")]
        public IActionResult GetAll()
        {
            var res = service.GetAllProducts();
            return Ok(res);
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file)
        {
            string imageName = file.FileName;
            string path = Path.Combine(webHost.WebRootPath,"Images", imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
               await file.CopyToAsync(stream);
            }
            byte[] arr;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                arr= memoryStream.ToArray();
            }
            return Ok(arr) ;
        }
      
    }
}
