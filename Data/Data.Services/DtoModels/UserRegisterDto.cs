using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.DtoModels
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
