using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.Models.Category
{
    public class AddCategoryModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(4,ErrorMessage ="name must be at lest 4 letters")]
        public required string Name { get; set; }
    }
}
