using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get;set; }
        public required string Description { get; set; }
        public required string imageUrl { get; set; }
        public required decimal price { get; set; }
        public required int quantity { get; set; }
        
        
        public required int CategoryId { get; set; }
        
    }
}
