﻿
using Data.DataConnection;
using Data.DataConnection.Repositories.Implementations;
using Data.Services.Identity;
using System;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnitOfWorkContext unitOfWorkContext = new UnitOfWorkContext(new ApplicationDbContext());


            //var res=unitOfWorkContext.Products.GetAll().ToList();

            UserService userService = new UserService(new ApplicationDbContext());
            userService.Register(new Data.Services.DtoModels.UserRegisterDto()
            {
                Username = "airfan",
                Password="a1+",
                ConfirmPassword="a1+"
            });
        }
    }
}
