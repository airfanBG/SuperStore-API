using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class Manufacturer:BaseModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
