using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Repositories.Albums;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Albums
{
    public class AlbumService : IAlbumRepository
    {
        private readonly DbConnection _dbConnection;

        public AlbumService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreateAlbumCommand command)
        {
            try
            {
                object? result = _dbConnection.ExecuteScalar("CreateAlbum", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create album: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
