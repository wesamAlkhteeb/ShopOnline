using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Domain.DTO;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Category;
using ShopOnline.API.Infrastructure.DatabaseContextApplication;

namespace ShopOnline.API.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContextShop database;

        public CategoryRepository(DbContextShop database)
        {
            this.database = database;
        }

        public async Task<string> AddCategory(AddCategoryModel addCategory)
        {
            await database.Categories.AddAsync(addCategory.ConvertToCategoryEntity());
            database.SaveChanges();
            return "Add Category successfully.";
        }

        private async Task<CategoryEntity?> GetCategoryById(int id)
        {
            return await database.Categories.Where(category => category.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> DeleteCategory(int id)
        {
            CategoryEntity? category = await GetCategoryById(id);
            if(category == null)
            {
                throw new BadHttpRequestException("Category not found");
            }
            database.Categories.Remove(category);
            await database.SaveChangesAsync();
            return "Deleted successfully.";
        }

        public async Task<List<CategoryEntity>> GetCategories(int page)
        {
            return await database.Categories
                .Skip((page - 1) * ConstantsService.pageCount)
                .Take(ConstantsService.pageCount)
                .ToListAsync();
        }

        public async Task<string> PutCategory(UpdateCategoryModel updateCategory)
        {
            CategoryEntity? category = await GetCategoryById(updateCategory.Id);
            if (category == null)
            {
                throw new BadHttpRequestException("Category not found");
            }
            category.Name = updateCategory.Name;
            await database.SaveChangesAsync();
            return "Updated successfully";
        }
    }
}
