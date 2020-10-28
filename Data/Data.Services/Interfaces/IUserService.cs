﻿using Data.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Interfaces
{
    public interface IUserService
    {
        public void Register(UserRegisterDto model);
        public void Login(UserLoginDto model);
    }
}
