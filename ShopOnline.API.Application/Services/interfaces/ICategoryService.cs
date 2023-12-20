using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Services.interfaces
{
    public interface ICategoryService
    {
        public Task<Dictionary<string,object>> AddCategory(AddCategoryModel addCategory);

        public Task<Dictionary<string, object>> GetCategory(int page);

        public Task<Dictionary<string, object>> PutCategory(UpdateCategoryModel updateCategory);

        public Task<Dictionary<string, object>> DeleteCategory(int id);
    }
}
