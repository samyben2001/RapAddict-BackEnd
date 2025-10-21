using Dapper;
using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Repositories.Albums;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

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
                int result = _dbConnection.ExecuteScalar<int>("CreateTrack", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddStreamingPlatformToTrackCommand command)
        {
            try
            {
                _dbConnection.Execute("AddStreamingPlatformToTrack", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
