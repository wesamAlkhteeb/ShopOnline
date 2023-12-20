
namespace ShopOnline.API.Domain.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        
    }
}
