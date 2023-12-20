using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestImagewebapi.Validation;

namespace ShopOnline.API.Domain.Models.Product
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(4, ErrorMessage = "Name must be at lest 4 letters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(6, ErrorMessage = "Description must be at lest 6 letters")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "File is required")]
        [FileValidation]
        public required IFormFile File { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0,1e10, ErrorMessage = "Price must be positive number.")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 1e10, ErrorMessage = "Quantity must be positive number")]
        public required int Quantity { get; set; }
        
        [Required(ErrorMessage = "CategoryId is required")]
        public required int CategoryId { get; set; }
    }
}
