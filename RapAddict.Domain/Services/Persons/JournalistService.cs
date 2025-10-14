using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Persons
{
    public class JournalistService : IJournalistRepository
    {
        private readonly DbConnection _dbConnection;

        public JournalistService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateJournalistCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateJournalist", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
