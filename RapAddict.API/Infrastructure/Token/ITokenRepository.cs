using RapAddict.Domain.Entities.Users;

namespace RapAddict.API.Infrastructure.Token
{
    public interface ITokenRepository
    {
        string GenerateToken(User user);
    }
}
