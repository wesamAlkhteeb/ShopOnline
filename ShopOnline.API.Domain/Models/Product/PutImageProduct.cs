using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TestImagewebapi.Validation;

namespace ShopOnline.API.Domain.Models.Product
{
    public class PutImageProduct
    {
        [Required(ErrorMessage = "Id is required")]
        public required int Id { get; set; }

        [Required(ErrorMessage = "File is required")]
        [FileValidation]
        public required IFormFile File { get; set;}
    }
}
