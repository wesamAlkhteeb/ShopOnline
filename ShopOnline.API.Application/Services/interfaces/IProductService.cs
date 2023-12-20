using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Application.Services.interfaces
{
    public interface IProductService
    {
        public Task<Dictionary<string, object>> AddProduct(AddProductModel productModel);

        public Task<Dictionary<string, object>> GetProduct(int page);

        public Task<Dictionary<string, object>> GetProductById(int id);

        public Task<Dictionary<string, object>> GetProductByCategoryId(int categoryId,int page);

        public Task<Dictionary<string, object>> PutProduct(UpdateProductModel updateProduct);

        public Task<Dictionary<string, object>> DeleteProduct(int id);

        public Task<Dictionary<string, object>> PutImage(PutImageProduct putImage);
    }
}
