using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
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
                object? result = _dbConnection.ExecuteScalar("CreateStreamingPlatform", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create streaming platform: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
