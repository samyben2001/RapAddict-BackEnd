using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Repositories.Albums;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Albums
{
    public class TrackService : ITrackRepository
    {
        private readonly DbConnection _dbConnection;

        public TrackService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreateTrackCommand command)
        {
            try
            {
                object? result = _dbConnection.ExecuteScalar("CreateTrack", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create track: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
