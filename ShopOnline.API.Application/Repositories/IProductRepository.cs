using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Models.Product;

namespace ShopOnline.API.Application.Repositories
{
    public interface IProductRepository{
        Task AddProduct(ProductEntity productEntity);
        Task CheckIsProductExsists(string name);
        Task<string> DeleteProduct(int id);
        Task<object> GetProductById(int id);
        Task<List<object>> GetProductByCategoryId(int id, int page);
        Task<List<Object>> GetProducts(int page);
        Task<string> GetOldImagePath(int id);
        Task UpdateProduct(UpdateProductModel productModel);
    }
}