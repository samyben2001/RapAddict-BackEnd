using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

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
                object? result = _dbConnection.ExecuteScalar("CreateSocialMedia", true, command);
                if (result is int id)
                {
                    return CqsResult<int>.Success(id);
                }
                else
                {
                    throw new Exception("Failed to create social media: returned value was null or not an integer.");
                }
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }
    }
}
