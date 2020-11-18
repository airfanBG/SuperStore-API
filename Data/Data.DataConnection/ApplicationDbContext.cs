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

            modelBuilder.Entity<Manufacturer>().HasData(manufacturer);


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
