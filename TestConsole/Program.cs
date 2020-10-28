using Data.DataConnection;
using Data.DataConnection.Repositories.Implementations;
using System;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkContext unitOfWorkContext = new UnitOfWorkContext(new ApplicationDbContext());
            var res=unitOfWorkContext.Products.GetAll().ToList();
        }
    }
}
