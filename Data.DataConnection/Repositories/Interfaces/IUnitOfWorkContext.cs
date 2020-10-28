using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IUnitOfWorkContext
    {
        public IRepository<User> Users { get; }
        public IRepository<Product> Products { get; }
    }
}
