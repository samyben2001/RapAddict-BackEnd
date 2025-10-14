using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Persons
{
    public class ContentCreatorService : IContentCreatorRepository
    {
        private readonly DbConnection _dbConnection;

        public ContentCreatorService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateContentCreatorCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateContentCreator", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
