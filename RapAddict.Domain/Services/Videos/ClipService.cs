using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Videos
{
    public class ClipService : IClipRepository
    {
        private readonly DbConnection _dbConnection;

        public ClipService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public ICqsResult Execute(CreateClipCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateClip", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
