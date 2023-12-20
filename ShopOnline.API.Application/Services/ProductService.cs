using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.DTO;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.ImageHelper;
using ShopOnline.API.Domain.Models.Product;

namespace ShopOnline.API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Dictionary<string, object>> AddProduct(AddProductModel productModel)
        {
            string path = await ImageHelper.Instance.StoreImageWithManyDemonission(productModel.File);
            try
            {
                await this.productRepository.CheckIsProductExsists(productModel.Name);
                ProductEntity productEntity = productModel.ConvertToProductEntity(path);
                await this.productRepository.AddProduct(productEntity);
            }
            catch (Exception)
            {
                ImageHelper.Instance.DeleteImageProcees(path);
                throw;
            }
            return new Dictionary<string, object>
            {
                { "message","Product Add successfully."}
            };
        }

        public async Task<Dictionary<string, object>> DeleteProduct(int id)
        {
            string path = await productRepository.DeleteProduct(id);
            ImageHelper.Instance.DeleteImageProcees(path);
            return new Dictionary<string, object>
            {
                {"message","Product has delelted"}
            };
        }

        public async Task<Dictionary<string, object>> GetProduct(int page)
        {
            List<object> products = await this.productRepository.GetProducts(page);
            return new Dictionary<string, object>
            {
                { "products" , products }
            };
        }

        public async Task<Dictionary<string, object>> GetProductByCategoryId(int categoryId, int page)
        {

            object product = await this.productRepository.GetProductByCategoryId(categoryId,page);
            return new Dictionary<string, object>
            {
                {"product",product }
            };
        }

        public async Task<Dictionary<string, object>> GetProductById(int id)
        {
            object product = await this.productRepository.GetProductById(id);
            return new Dictionary<string, object>
            {
                {"product",product }
            };
        }

        public async Task<Dictionary<string, object>> PutImage(PutImageProduct putImage)
        {
            string oldPath = await this.productRepository.GetOldImagePath(putImage.Id);
            await ImageHelper.Instance.UpdateImageProcess(oldPath, putImage.File);
            return new Dictionary<string, object>
            {
                {"message","Product Image has changed."}
            };
        }

        public async Task<Dictionary<string, object>> PutProduct(UpdateProductModel updateProduct)
        {
            await this.productRepository.UpdateProduct(updateProduct);
            return new Dictionary<string, object>
            {
                {"message","Product has updated." }
            };
        }
    }
}
