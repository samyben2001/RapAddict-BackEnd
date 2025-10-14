using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
{
    public class ArtistService : IArtistRepository
    {
        private readonly DbConnection _dbConnection;

        public ArtistService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateArtistCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateArtist", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
