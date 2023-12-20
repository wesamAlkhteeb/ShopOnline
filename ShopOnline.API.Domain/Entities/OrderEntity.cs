using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.API.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public required DateTime DateTime { get; set; }
        public required decimal totalPrice { get; set; }
        public required string StatusOrder { get;set; }
        public required int AccountId {  get; set; }
    }
}
