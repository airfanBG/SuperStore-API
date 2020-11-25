using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Seed
{
    public class SeedData
    {
        public ModelBuilder Seed(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<SellerProduct>().HasKey(x => new { x.ProductId, x.SellerId });
            List<User> users = new List<User>()
           {
               new User()
               {
                   UserName="Minka",
                   Password="123"
               },
               new User()
               {
                   UserName="Ginka",
                   Password="123"
               },
               new User()
               {
                   UserName="Gosho",
                   Password="123"
               }
           };
            List<Seller> sellers = new List<Seller>()
            {
                new Seller()
                {
                    SellerNumber="1",
                    UserId=users[0].Id
                },
                new Seller()
                {
                    SellerNumber="1",
                    UserId=users[1].Id
                },
                new Seller()
                {
                    SellerNumber="1",
                    UserId=users[2].Id
                }
            };
            List<Product> products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                products.Add(new Product()
                {
                    ProductName = Guid.NewGuid().ToString().Substring(0, 5),
                    ProductPrice = i * 10,
                    MinimumCountAlert = 10,
                    CurrentCountInWarehouse = 100
                });
            }
            List<SellerProduct> sellerProducts = new List<SellerProduct>();

            for (int i = 0; i < 10; i++)
            {
                Random rd = new Random();
                var index = rd.Next(0, 14);
                var sellerIndex = rd.Next(0, 2);
                sellerProducts.Add(new SellerProduct()
                {
                    ProductId = products[index].Id,
                    SellerId = sellers[sellerIndex].Id
                });
            }
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Seller>().HasData(sellers);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<SellerProduct>().HasData(sellerProducts);

            return modelBuilder;
        }
    }
}
