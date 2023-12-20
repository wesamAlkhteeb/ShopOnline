using System.ComponentModel.DataAnnotations;


namespace ShopOnline.API.Domain.Models.Account
{
    public class RegisterModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Length name is more than 3")]
        public required string Name { get; set; }
        
        [Required]
        [RegularExpression(pattern: "^(\\d|\\w)+(\\d|\\w|\\.|_|-)*@\\w+\\.\\w+$", ErrorMessage = "Email is invalid")]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(pattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_])(?=.*\\d)[a-zA-Z\\d\\W_]{8,}$", ErrorMessage = "Password is invalid. You must to input at lest 8 character consists of capital and small character, digit and symbols.")]
        public required string Password { get; set; }
    }
}
