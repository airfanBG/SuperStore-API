using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Image:BaseModel
    {
        public string ImageUrl { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
