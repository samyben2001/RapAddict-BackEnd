using Dapper;
using RapAddict.Domain.Commands.Users;
using RapAddict.Domain.Repositories.Users;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Users
{
    public class UserService : IUserRepository
    {
        private readonly DbConnection _dbConnection;

        public UserService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }
        public ICqsResult<int> Execute(CreateUserCommand command)
        {
            try
            {
                int result = _dbConnection.ExecuteScalar<int>("CreateUser", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
