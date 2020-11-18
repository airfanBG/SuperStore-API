using Data.DataConnection;
using Data.Services.DtoModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.ApiServices
{
    public class SellerService
    {
        private readonly ApplicationDbContext applicationDb;

        public SellerService(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
        }
        public void GetTopSellers(int year, int month)
        {
            using (applicationDb)
            {
                var sellers = applicationDb.SellerProduct
                    .Include(x => x.Product)
                    .Include(x => x.Seller)
                    .ThenInclude(x => x.User)
                    .Select(x => new TopSellerDto()
                                {
                                    Sellername=x.Seller.User.UserName,
                                    SellerNumber=x.Seller.SellerNumber,
                                   Date=x.CreatedAt
                                }
                            )
                    .Where(x=>x.Date.Month==month && x.Date.Year==year)
                    .GroupBy(x=>new { x.SellerNumber,x.Sellername })
                    .Select(x=>new {UserIdInStore=x.Key.SellerNumber,TotalSellsInMonth=x.Count(),Name=x.Key.Sellername})
                    .OrderByDescending(x=>x.TotalSellsInMonth)
                    
                    .ToList();
            }
        }
    }
}
