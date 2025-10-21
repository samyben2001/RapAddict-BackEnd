using Dapper;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

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
                _dbConnection.Execute("CreateAnalyse", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddArtistToAnalyseCommand command)
        {
            try
            {
                _dbConnection.Execute("AddArtistToAnalyse", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
