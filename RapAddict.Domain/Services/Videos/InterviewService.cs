using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data.Common;
using Tools.Cqs.Results;
using Tools.Database;

namespace RapAddict.Domain.Services.Videos
{
    public class InterviewService : IInterviewRepository
    {
        private readonly DbConnection _dbConnection;

        public InterviewService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public ICqsResult Execute(CreateInterviewCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("CreateInterview", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddArtistToInterviewCommand command)
        {
            try
            {
                _dbConnection.ExecuteNonQuery("AddArtistToInterview", true, command);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }
    }
}
