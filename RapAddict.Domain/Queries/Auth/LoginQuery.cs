using RapAddict.Domain.Entities.Users;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Auth
{
    public class LoginQuery: IQueryDefinition<User>
    {
        public string Login { get; }
        public string Password { get; }

        public LoginQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
