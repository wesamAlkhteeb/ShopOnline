using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<Dictionary<string,object>> Login(LoginModel login)
        {
            return await accountRepository.Login(login);
        }

        public async Task<string> Register(RegisterModel register)
        {
            await accountRepository.IsEmailUseed(register.Email);
            return await accountRepository.Register(register);
        }
    }
}
