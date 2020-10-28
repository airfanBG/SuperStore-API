using Data.DataConnection;
using Data.Services.DtoModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Identity
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;
        private readonly TokenModel _tokenManagement;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Login(UserLoginDto model)
        {
            throw new NotImplementedException();
        }

        public void Register(UserRegisterDto model)
        {
            try
            {
                bool passwordValidation = CheckUserPassword(model);

                if (passwordValidation==true)
                {
                    string hashedPassword = Hash(model.Password);

                    using (_dbContext)
                    {
                        _dbContext.Users.Add(new Models.Models.User()
                        {
                            UserName=model.Username,
                            Password=hashedPassword
                        });
                        _dbContext.SaveChanges();
                    }
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
           //1.Get info from model
           //2.Check if user exist in Db
             //2.1 If exists
                //-return user exists
            //2.2 If not exists
                //2.2.1 Register user Password-hashing (algo)
                //2.2.2 Save user
                //2.2.3 Generate token
                //2.2.4 Return token


        }
        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        private bool CheckUserPassword(UserRegisterDto model)
        {
            bool result =
                           model.Password.Any(c => char.IsLetter(c)) &&
                           model.Password.Any(c => char.IsDigit(c)) &&
                           model.Password.Any(c => char.IsSymbol(c));
            if (result==true)
            {
                if (model.Password==model.ConfirmPassword)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
