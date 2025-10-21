using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Persons
{
    public class SocialMediaService : ISocialMediaRepository
    {
        private readonly DbConnection _dbConnection;

        public SocialMediaService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreateSocialMediaCommand command)
        {
            try
            { 
                int result = _dbConnection.ExecuteScalar<int>("CreateSocialMedia", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
