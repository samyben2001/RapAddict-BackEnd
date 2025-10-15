using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

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
                object? result = _dbConnection.ExecuteScalar("CreatePerson", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create person: returned value was null or not an integer.");
                }
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
                _dbConnection.ExecuteNonQuery("AddSocialMediaToPerson", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
