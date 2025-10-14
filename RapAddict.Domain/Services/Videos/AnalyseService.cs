using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Videos
{
    public class AnalyseService : IAnalyseRepository
    {
        private readonly DbConnection _dbConnection;

        public AnalyseService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public ICqsResult Execute(CreateAnalyseCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateAnalyse", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
