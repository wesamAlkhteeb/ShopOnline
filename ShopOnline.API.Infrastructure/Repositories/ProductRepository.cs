using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Application.Repositories;
using ShopOnline.API.Domain.DTO;
using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Product;
using ShopOnline.API.Infrastructure.DatabaseContextApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextShop database;
        public ProductRepository(DbContextShop database)
        {
            this.database = database;
        }
        public async Task AddProduct(ProductEntity productEntity)
        {
            await database.AddAsync(productEntity);
            await database.SaveChangesAsync();
        }

        public async Task CheckIsProductExsists(string name)
        {
            ProductEntity? product = await database.Products
                   .Where(product => product.Name == name)
                   .FirstOrDefaultAsync();
            if(product != null)
            {
                throw new BadHttpRequestException("Cannot add because this name is exists.");
            }
        }

        private async Task<ProductEntity> CheckIsProductExsitsById(int id)
        {
            ProductEntity? product = await database.Products
                    .Where(product => product.Id == id)
                    .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new BadHttpRequestException("Product not found.");
            }
            return product;
        }
        
        public async Task<string> DeleteProduct(int id)
        {
            ProductEntity product= await CheckIsProductExsitsById(id);
            database.Products.Remove(product);
            await database.SaveChangesAsync();
            return product.imageUrl;
        }

        public async Task<string> GetOldImagePath(int id)
        {
            string? path = await database.Products
                    .Where(product => product.Id == id)
                    .Select(product => product.imageUrl)
                    .FirstOrDefaultAsync();
            if (path == null)
            {
                throw new BadHttpRequestException("Product not found.");
            }
            return path;
        }

        public async Task<List<object>> GetProductByCategoryId(int id,int page)
        {
            
            
            return await database.Products
                    .Where(product => product.CategoryId == id)
                    .Skip((page - 1) * ConstantsService.pageCount)
                    .Take(page)
                    .Select(product => product.AssignFromProductEntity())
                    .ToListAsync(); 
        }

        public async Task<object> GetProductById(int id)
        {
            object? product = await database.Products
                    .Where(product => product.Id == id)
                    .Select(product => product.AssignFromProductEntity())
                    .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new BadHttpRequestException("Product not found.");
            }
            return product;
        }

        public async Task<List<Object>> GetProducts(int page)
        {
            return await database.Products
                .Skip((page - 1) * ConstantsService.pageCount)
                .Take(page).Select(product => product.AssignFromProductEntity()).ToListAsync();
        }

        public async Task UpdateProduct(UpdateProductModel productModel)
        {
            ProductEntity product = await CheckIsProductExsitsById(productModel.Id);
            productModel.AssigntoProductEntity(product);
            await database.SaveChangesAsync();
        }
    }
}
