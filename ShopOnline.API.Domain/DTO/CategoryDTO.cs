using ShopOnline.API.Domain.Entities;
using ShopOnline.API.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.DTO
{
    public static class CategoryDTO
    {
        public static CategoryEntity ConvertToCategoryEntity(this AddCategoryModel addCategory)
        {
            return new CategoryEntity
            {
                Name = addCategory.Name,
            };
        }
    }
}
