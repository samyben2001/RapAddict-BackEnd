using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Persons
{
    public class PersonService : IPersonRepository
    {
        private readonly DbConnection _dbConnection;

        public PersonService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreatePersonCommand command)
        {
            try
            {

                int result = _dbConnection.ExecuteScalar<int>("CreatePerson", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddSocialMediaToPersonCommand command)
        {
            try
            {
                _dbConnection.Execute("AddSocialMediaToPerson", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
