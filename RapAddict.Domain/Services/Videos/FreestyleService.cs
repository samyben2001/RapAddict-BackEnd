using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Videos
{
    public class FreestyleService : IFreestyleRepository
    {
        private readonly DbConnection _dbConnection;

        public FreestyleService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public ICqsResult Execute(CreateFreestyleCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateFreestyle", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddArtistToFreestyleCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("AddArtistToFreestyle", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
