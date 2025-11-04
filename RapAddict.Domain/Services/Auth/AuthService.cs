using Dapper;
using RapAddict.Domain.Commands.Auth;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Users;
using RapAddict.Domain.Queries.Auth;
using RapAddict.Domain.Repositories.Auth;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Auth
{
    public class AuthService : IAuthRepository
    {
        private readonly DbConnection _dbConnection;

        public AuthService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }


        public ICqsResult<int> Execute(RegisterCommand command)
        {
            try
            {
                int result = _dbConnection.ExecuteScalar<int>("Register", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }

        public ICqsResult<User> Execute(LoginQuery query)
        {
            try
            {
                User? result = _dbConnection.QuerySingle<User>("Login", param: query, commandType: CommandType.StoredProcedure);

                if (result is null)
                    return CqsResult<User>.Failure("Error during connection! Check Username or Password!");

                return CqsResult<User>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<User>.Failure(ex.Message);
            }
        }
    }
}
