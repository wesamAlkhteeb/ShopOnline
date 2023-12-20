using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Models.Product;
using ShopOnline.API.Domain.ImageHelper;

namespace ShopOnline.API.Domain.DTO
{
    public static class ProductDTO
    {
        public static ProductEntity ConvertToProductEntity (this AddProductModel productModel , string path)
        {
            return new ProductEntity
            {
                CategoryId = productModel.CategoryId,
                Description = productModel.Description,
                imageUrl = path,
                Name = productModel.Name,
                price = productModel.Price,
                quantity = productModel.Quantity
            };
        }

        public static void AssigntoProductEntity(this UpdateProductModel productModel , ProductEntity product )
        {
            product.quantity = productModel.Quantity;
            product.price = productModel.Price;
            product.Description = productModel.Description;
            product.Name = productModel.Name;
            product.CategoryId = productModel.CategoryId;
        }

        public static Object AssignFromProductEntity(this ProductEntity product)
        {
            return new
            {
                id = product.Id,
                name = product.Name,
                description = product.Description,
                price = product.price,
                quantity = product.quantity,
                categoryId = product.CategoryId,
                image = ImageHelper.ImageHelper.Instance.GetPathesImage(product.imageUrl)
            };
        }
    }
}
