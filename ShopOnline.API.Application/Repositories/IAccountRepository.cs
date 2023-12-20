using ShopOnline.API.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<string> Register(RegisterModel registerModel);
        Task<Dictionary<string,object>> Login(LoginModel loginModel);
        Task IsEmailUseed(string email);
    }
}
