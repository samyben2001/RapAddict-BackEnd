using RapAddict.Domain.Commands.Users;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
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
                object? result = _dbConnection.ExecuteScalar("CreateUser", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create user: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
