using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

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
                _dbConnection.Execute("CreateContentCreator", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
