using RapAddict.Domain.Entities;

namespace RapAddict.API.Infrastructure.Token
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
    }
}
