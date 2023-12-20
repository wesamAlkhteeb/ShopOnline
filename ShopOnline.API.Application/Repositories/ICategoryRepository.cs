using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<string> AddCategory(AddCategoryModel addCategory);
        Task<List<CategoryEntity>> GetCategories(int page);
        Task<string> PutCategory(UpdateCategoryModel updateCategory);
        Task<string> DeleteCategory(int id);
    }
}
