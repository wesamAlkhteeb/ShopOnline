
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Domain.DTO;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Helper.Security;
using ShopOnline.API.Domain.Models.Account;
using ShopOnline.API.Infrastructure.DatabaseContextApplication;

namespace ShopOnline.API.Domain.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbContextShop database;
        private readonly JwtOption _jwt;
        public AccountRepository(DbContextShop database ,IOptions<JwtOption> jwt)
        {
            this.database = database;
            _jwt = jwt.Value;
        }

        public async Task IsEmailUseed(string email)
        {
            AccountEntity? account = await database.Accounts
                .Where(account => account.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();
            if(account != null)
            {
                throw new BadHttpRequestException("Email is used.");
            }
        }

        public async Task<Dictionary<string, object>> Login(LoginModel loginModel)
        {
            AccountEntity? account = await database.Accounts
                .Where(account =>account.Email == loginModel.Email &&
                        account.Password == JwtSecurity.securityData.getHashPassword(loginModel.Password)
                )
                .FirstOrDefaultAsync();
            

            if(account == null)
            {
                throw new Exception("Account not found. you can register new account.");
            }
            return JwtSecurity.securityData.GenerateToken(account.UserName , account.Id ,account.Role,_jwt);
        }

        public async Task<string> Register(RegisterModel registerModel)
        {
            await database.Accounts.AddAsync(registerModel.ConvertToAccountEntity());
            database.SaveChanges();
            return "Register has successfully"; 
        }
    }
}
