using RapAddict.Domain.Commands.Users;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories.Users
{
    public interface IUserRepository: ICommandResultHandler<CreateUserCommand, int>
    {
    }
}
