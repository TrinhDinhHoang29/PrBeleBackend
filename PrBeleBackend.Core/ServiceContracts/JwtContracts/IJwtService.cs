﻿using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.JwtContracts
{
    public interface IJwtService
    {
        public Task<JwtResponse> GenarateJwt(AccountResponse account,List<string> permissions);
        public Task<JwtResponse> GenarateJwtClient(CustomerResponse customer);
        public Task<JwtResponse> GenarateJwtForgotPasswordClient(CustomerResponse customer);


    }
}
