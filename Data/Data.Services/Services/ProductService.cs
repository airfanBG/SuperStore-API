using Data.DataConnection;
using Data.Services.DtoModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext applicationDb;

        public ProductService(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }
        public void GetTopSellers(int year, int month)
        {
            using (applicationDb)
            {
                var res = applicationDb.SellerProduct
                    .Include(x => x.Product)
                    .Include(x => x.Seller)
                    .ThenInclude(x => x.User)
                    .Where(x => x.CreatedAt.Year == year && x.CreatedAt.Month == month)
                    .Select(x => new TopSellerDto()
                    {
                        SellerName = x.Seller.User.UserName,
                        SellerNumber = x.Seller.SellerNumber,
                        Date = x.CreatedAt
                    })
                    .GroupBy(x => new { x.SellerNumber, x.SellerName })
                    //.Select(x => new { UserIdInStore = x.Key.SellerNumber, TotalSoldProducts = x.Count(), Name = x.Key.SellerName })
                    .OrderByDescending(x => x.Count())
                    .ToList();
            }
        }
    }
}
