using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Models.Category;


namespace ShopOnline.API.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<Dictionary<string, object>> AddCategory(AddCategoryModel addCategory)
        {
            return new Dictionary<string, object>{
                { "message",await categoryRepository.AddCategory(addCategory) }
            };
        }

        public async Task<Dictionary<string, object>> DeleteCategory(int id)
        {
            return new Dictionary<string, object>{
                { "message",await categoryRepository.DeleteCategory(id) }
            };
        }

        public async Task<Dictionary<string, object>> GetCategory(int page)
        {
            return new Dictionary<string, object>{
                { "categories",await categoryRepository.GetCategories(page) }
            };
        }

        public async Task<Dictionary<string, object>> PutCategory(UpdateCategoryModel updateCategory)
        {
            return new Dictionary<string, object>{
                { "message",await categoryRepository.PutCategory(updateCategory) }
            };
        }
    }
}
