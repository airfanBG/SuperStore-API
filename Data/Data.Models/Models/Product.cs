using Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Data.Models.Models
{
    public class Product:BaseModel
    {
        private int _minimumCountAlert = 10;

        [StringLength(50,MinimumLength =3)]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
     
        public int CurrentCountInWarehouse { get; set; }
        
        public int MinimumCountAlert
        {
            get
            {
                return _minimumCountAlert;
            }
            set
            {
                if (value!=_minimumCountAlert)
                {
                    _minimumCountAlert = value;
                }
            }
        }
        public ICollection<SellerCustomer> SellerCustomers { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
