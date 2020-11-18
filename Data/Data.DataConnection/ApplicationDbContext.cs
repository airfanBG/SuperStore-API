using Data.Models.Interfaces;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataConnection
{
    public class ApplicationDbContext : DbContext
    {
        private IConfigurationRoot configurationRoot;

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerCustomer> SellerCustomers { get; set; }
        public DbSet<SellerProduct> SellerProduct { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(Path.Combine(@"C:\Users\airfan\AppData\Roaming\Microsoft\UserSecrets\b29dfa07-5f68-4e34-bf6c-4672b02a0080")).AddJsonFile("secrets.json").Build();
            dbContextOptionsBuilder.UseSqlServer(configurationRoot.GetSection("DefaultConnection:ConnectionString").Value);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<SellerProduct>().HasKey(x => new { x.ProductId, x.SellerId });
            //Добавено 18.11
            
            Manufacturer manufacturer = new Manufacturer()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test",
                CreatedAt = DateTime.Now
            };
            List<User> users = new List<User>()
            {
                new User()
                {
                    Id=Guid.NewGuid().ToString(),
                    UserName="Minka",
                    Password="123"
                },
                new User()
                {
                    Id=Guid.NewGuid().ToString(),
                    UserName="Pesho",
                     Password="123"
                },
                new User()
                {
                    Id=Guid.NewGuid().ToString(),
                    UserName="Gosho",
                     Password="123"
                }
            };
            List<Seller> sellers = new List<Seller>()
            {
                new Seller()
                {
                    SellerNumber="1",
                    UserId=users[0].Id,
                    
                },
                new Seller()
                {
                    SellerNumber="2",
                    UserId=users[1].Id,

                },
                new Seller()
                {
                    SellerNumber="3",
                    UserId=users[2].Id,

                }
            };

            List<Product> products = new List<Product>()
             {
                 new Product()
                 {
                      Id=Guid.NewGuid().ToString(),
                     ProductName="Ball",
                     ProductPrice=1,
                     CurrentCountInWarehouse=10,
                     CreatedAt=DateTime.Now,
                     ManufacturerId=manufacturer.Id
                 },
                  new Product()
                 {
                       Id=Guid.NewGuid().ToString(),
                     ProductName="Bat",
                     ProductPrice=11,
                     CurrentCountInWarehouse=10,
                     CreatedAt=DateTime.Now,
                      ManufacturerId=manufacturer.Id
                 }, new Product()
                 {
                      Id=Guid.NewGuid().ToString(),
                     ProductName="Bike",
                     ProductPrice=100,
                     CurrentCountInWarehouse=10,
                     CreatedAt=DateTime.Now,
                      ManufacturerId=manufacturer.Id
                 }, new Product()
                 {
                     Id=Guid.NewGuid().ToString(),
                     ProductName="T-shirt",
                     ProductPrice=15,
                     CurrentCountInWarehouse=10,
                     CreatedAt=DateTime.Now,
                      ManufacturerId=manufacturer.Id
                 }
             };
            List<SellerProduct> sellerProducts = new List<SellerProduct>();
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                var indexUser = random.Next(0, 2);
                var indexProduct = random.Next(0, 3);
                sellerProducts.Add(new SellerProduct()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = products[indexProduct].Id,
                    SellerId = sellers[indexUser].Id,
                    CreatedAt=DateTime.Now
                });
            }

            modelBuilder.Entity<Manufacturer>().HasData(manufacturer);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Seller>().HasData(sellers);

            modelBuilder.Entity<SellerProduct>().HasData(sellerProducts);

            modelBuilder.Entity<Product>().HasData(products);
            base.OnModelCreating(modelBuilder);
        }
        private void ApplyChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IAuditInfo).ToList();

            foreach (var entry in entries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
                else
                {
                    entity.DeletedAt = DateTime.UtcNow;
                }
            }
        }
        public override int SaveChanges()
        {
            return SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}
