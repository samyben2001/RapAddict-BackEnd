using Dapper;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Videos
{
    public class VideoService : IVideoRepository
    {
        private readonly DbConnection _dbConnection;

        public VideoService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult<int> Execute(CreateVideoCommand command)
        {
            try
            {
                int result = _dbConnection.ExecuteScalar<int>("CreateVideo", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
