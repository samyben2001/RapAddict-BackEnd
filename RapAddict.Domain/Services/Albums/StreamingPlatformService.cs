using Dapper;
using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Repositories.Albums;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Albums
{
    public class StreamingPlatformService : IStreamingPlatformRepository
    {
        private readonly DbConnection _dbConnection;

        public StreamingPlatformService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreateStreamingPlatformCommand command)
        {
            try
            {
                int result = _dbConnection.ExecuteScalar<int>("CreateStreamingPlatform", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
