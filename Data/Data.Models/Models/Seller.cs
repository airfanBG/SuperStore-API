﻿using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models.Models
{
    public class Seller:BaseModel
    {
        [Required]
        public string SellerNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<SellerCustomer> SellerCustomers { get; set; }
        public ICollection<SellerProduct> SellerProducts { get; set; }
    }
}
