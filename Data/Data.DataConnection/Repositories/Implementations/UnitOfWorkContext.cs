using Data.DataConnection.Repositories.Interfaces;
using Data.Models.Abstractions;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Implementations
{
    public class UnitOfWorkContext : IUnitOfWorkContext
    {
        private Dictionary<Type, object> repositories;
        public DbContext Context;
        public UnitOfWorkContext(DbContext context)
        {
            Context = context;
            repositories = new Dictionary<Type, object>();
        }
        public IRepository<User> Users
        {
            get
            {
                return this.CreateInstance<User>();
            }
        }
        //public IRepository<Product> Products
        //{
        //    get
        //    {
        //        return this.CreateInstance<Product>();
        //    }
        //}

        public IRepository<Seller> Sellers => throw new NotImplementedException();

        public IRepository<Customer> Customers => throw new NotImplementedException();

        private IRepository<T> CreateInstance<T>() where T:BaseModel, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }
            return (Repository<T>)this.repositories[typeof(T)];
        }

    }
}
