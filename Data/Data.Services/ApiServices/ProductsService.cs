using Data.DataConnection;
using Data.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.ApiServices
{
    public class ProductsService
    {
        private readonly ApplicationDbContext applicationDb;

        public ProductsService(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }
        public List<ProductDto> GetAll()
        {
            using (applicationDb)
            {
                return applicationDb.Products.Select(x=>new ProductDto() 
                        {
                            ProductName=x.ProductName,
                            MinimumCountAlert=x.MinimumCountAlert,
                            CurrentCountInWarehouse=x.CurrentCountInWarehouse,
                            ProductPrice=x.ProductPrice
                        }).ToList();
            }
        }
    }
}
