using RapAddict.Domain.Commands.Auth;
using RapAddict.Domain.Entities.Users;
using RapAddict.Domain.Queries.Auth;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Auth
{
    public interface IAuthRepository: 
        ICommandResultHandler<RegisterCommand, int>,
        IQueryHandler<LoginQuery, User>
    {
    }
}
