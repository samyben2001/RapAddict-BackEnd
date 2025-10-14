using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
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
                object? result = _dbConnection.ExecuteScalar("CreateVideo", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create video: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
