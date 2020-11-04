using Data.DataConnection;
using Data.Services.DtoModels;
using Data.Services.Interfaces;
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

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Login(UserLoginDto model)
        {
            throw new NotImplementedException();
        }

        public string Register(UserRegisterDto model)
        {
            try
            {
                bool passwordValidation = CheckUserPassword(model);

                if (passwordValidation == true)
                {
                    string hashedPassword = Hash(model.Password);

                    using (_dbContext)
                    {
                        _dbContext.Users.Add(new Models.Models.User()
                        {
                            UserName = model.Username,
                            Password = hashedPassword
                        });
                        //_dbContext.SaveChanges();
                    }
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string file = Path.Combine(path, "tokenconfig.json");
                    string salt;
                    string issuer;
                    string audience;
                    double accessExpiration;

                    using (StreamReader sr = new StreamReader(file))
                    {
                        string content = sr.ReadToEnd();
                        JObject jsonObject = (JObject)JsonConvert.DeserializeObject(content);
                        salt = jsonObject["secret"].Value<string>();
                        issuer = jsonObject["Issuer"].Value<string>();
                        audience = jsonObject["audience"].Value<string>();
                        accessExpiration = jsonObject["AccessExpiration"].Value<double>();

                    }
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
                return string.Empty;
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
            if (result == true)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
