using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Persons
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

        public ICqsResult Execute(AddAlbumToArtistCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("AddAlbumToArtist", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
