using ShopOnline.API.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Services.interfaces
{
    public interface IAccountService
    {
        public Task<Dictionary<string, object>> Login(LoginModel login);
        public Task<string> Register(RegisterModel register);

    }
}
