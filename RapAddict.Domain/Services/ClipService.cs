using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
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
