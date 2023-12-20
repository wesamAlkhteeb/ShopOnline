
namespace ShopOnline.API.Domain.Helper.Security
{
    public class JwtOption
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public double DurationExpiredInDay { get; set; }
    }
}
