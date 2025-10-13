namespace RapAddict.API.Infrastructure.Token
{
    public class JwtOptions
    {
        public string Issuer { get; }
        public string Audience { get; }
        public string SecurityKey { get; }
        public JwtOptions(string issuer, string audience, string securityKey)
        {
            Issuer = issuer;
            Audience = audience;
            SecurityKey = securityKey;
        }
    }
}
