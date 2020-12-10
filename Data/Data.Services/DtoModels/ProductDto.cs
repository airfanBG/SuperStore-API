using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels
{
    public class ProductDto
    {
      
        public string ProductName { get; set; }
      
        public decimal ProductPrice { get; set; }

        public int CurrentCountInWarehouse { get; set; }

        public int MinimumCountAlert { get; set; }
    }
}
