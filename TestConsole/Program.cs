
using Data.DataConnection;
using Data.Services.Identity;
using Data.Services.Services;
using System;
using System.Linq;
using System.Net.Http;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnitOfWorkContext unitOfWorkContext = new UnitOfWorkContext(new ApplicationDbContext());


            //var res=unitOfWorkContext.Products.GetAll().ToList();

            UserService userService = new UserService(new ApplicationDbContext());

            // userService.Register(new Data.Services.DtoModels.UserRegisterDto() { Username = "dd", Password = "a1+", ConfirmPassword = "a1+" });
            //var t= userService.Login(new Data.Services.DtoModels.UserLoginDto()
            // {
            //     Username = "dd",
            //     Password = "a1+"
            // });
            ProductService productService = new ProductService(new ApplicationDbContext());
            productService.GetTopSellers(1, 1);
           
        }

    }
  
}
