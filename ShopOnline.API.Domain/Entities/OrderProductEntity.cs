using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.Entities
{
    public class OrderProductEntity
    {
        public int Id { get; set; }
        public required int ProductId { get; set; }
        public required int OrderId { get; set; }
        
    }
}
