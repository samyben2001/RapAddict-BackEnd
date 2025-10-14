using RapAddict.Domain.Commands;
using RapAddict.Domain.Repositories;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services
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
    }
}
