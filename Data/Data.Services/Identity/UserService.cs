
using Data.DataConnection;
using Data.Services.DtoModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
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
        public string Login(UserLoginDto model)
        {
            try
            {
                using (_dbContext)
                {
                    var checkUser = _dbContext.Users.FirstOrDefault(x => x.UserName == model.Username);
                    if (checkUser!=null)
                    {
                        var hashInputPass = Hash(model.Password);
                        if (hashInputPass==checkUser.Password)
                        {


                            return "token";
                        }
                        return "";
                    }
                    return "";
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public string Register(UserRegisterDto model)
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
                    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var file = Path.Combine(path, "secrets.json");

                    using (StreamReader sr = new StreamReader(file))
                    {
                        var res = sr.ReadToEnd();
                        var jsonSalt = (JObject)JsonConvert.DeserializeObject(res);
                        var salt = jsonSalt["secret"].Value<string>();
                        var issuer = jsonSalt["Issuer"].Value<string>();
                        var audience = jsonSalt["audience"].Value<string>();
                        var accessExpiration =jsonSalt["AccessExpiration"].Value<double>();

                        var claim = new List<Claim>()
                                {
                                  new Claim(ClaimTypes.Name,model.Username),

                                };
                        string token = string.Empty;

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(salt));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var jwtToken = new JwtSecurityToken(
                            issuer,
                            audience,
                            claim,
                            expires: DateTime.Now.AddMinutes(accessExpiration),
                            signingCredentials: credentials
                        );

                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                        return token;
                    }
                    
                }
                return "";
            }
            catch (Exception e)
            {

                throw e;
            }
          
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
