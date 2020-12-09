using Data.Services.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")] //localhost:5001/api/products/getfirst
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;
        private IConfiguration _configuration;
        public ProductsController(IWebHostEnvironment env, IConfiguration configuration)
        {
            webHostEnvironment = env;
           
            _configuration = configuration;
        }
       
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(id);
        }
        //" " 
        [HttpGet]
        [Route("")]
        [Route("idd/{id}")]
        [Route("getproducts/{id}")]
        
        public IActionResult GetProductById(int id)
        {
            return Ok(id);
        }
        [HttpPost]
        [Route("upload")]
        public async Task<string> UploadImage([FromForm]IFormFile file)
        {
            string fileName = file.FileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath,"Images",fileName);
            using (var stream=new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
        
    }
}
