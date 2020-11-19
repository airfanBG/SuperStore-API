using Data.DataConnection;
using Data.Services.Identity;
using System;
using Xunit;

namespace Unit_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_User_Register_If_user_Not_Valid()
        {
            //Arange
            //Act
            //Assert

             UserService userService = new UserService(new ApplicationDbContext());
             string result= userService.Register(new Data.Services.DtoModels.UserRegisterDto() 
             {
                 Username = "Minka",
                 Password = "a1+",
                 ConfirmPassword = "a1+"
             });

            Assert.Contains("", result);
           
        }
    }
}
