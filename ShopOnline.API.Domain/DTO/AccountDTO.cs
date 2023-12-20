using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Helper.Security;
using ShopOnline.API.Domain.Models.Account;

namespace ShopOnline.API.Domain.DTO
{
    public static class AccountDTO
    {
        public static AccountEntity ConvertToAccountEntity(this RegisterModel registerModel)
        {
            return new AccountEntity
            {
                Email = registerModel.Email,
                Password = JwtSecurity.securityData.getHashPassword(registerModel.Password),
                UserName = registerModel.Name,
                Role = Roles.user.ToString()
            };
        }
    }
}
