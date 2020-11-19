using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Models
{
    public class SellerProduct:BaseModel
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
