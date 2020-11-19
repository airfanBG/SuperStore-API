using Data.Models.Interfaces;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public DbSet<Image> Images { get; set; }
        public DbSet<SellerCustomer> SellerCustomers { get; set; }
        public DbSet<SellerProduct> SellerProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //configurationRoot = new ConfigurationBuilder().SetBasePath(Path.Combine(@"C:\Users\airfan\AppData\Roaming\Microsoft\UserSecrets\b29dfa07-5f68-4e34-bf6c-4672b02a0080")).AddJsonFile("secrets.json").Build();
            dbContextOptionsBuilder.UseSqlServer("Server=AIRFAN\\SQLEXPRESS;Initial Catalog=SuperStore;Trusted_Connection=true;");
            //  configurationRoot = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build();
            //dbContextOptionsBuilder.UseSqlServer(configurationRoot.GetSection("DefaultConnection:ConnectionString").Value);
            // dbContextOptionsBuilder.UseSqlServer(configurationRoot.GetSection("ConnectionString").Value);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
                    CurrentCountInWarehouse=100
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
                    ProductId=products[index].Id,
                    SellerId=sellers[sellerIndex].Id
                });
            }
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Seller>().HasData(sellers);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<SellerProduct>().HasData(sellerProducts);
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
