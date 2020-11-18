using Data.DataConnection;
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
        public void GetTopSellers()
        {
            using (applicationDb)
            {
                //var sellers = applicationDb.Sellers.Include(x => x.SellerProducts).Select(x => new
                //{
                //    SellerNumber = x.SellerNumber,
                //    SoldProducts = x.SellerProducts.Count
                //}).gro.ToList();
            }
        }
    }
}
