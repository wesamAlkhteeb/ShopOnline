using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.Helper
{
    public enum Roles
    {
        user = 1, admin = 2
    }
    public static class ConstantsService{
        public const string USER = "user";
        public const string ADMIN = "admin";

        public const int pageCount = 10;
    }
}
