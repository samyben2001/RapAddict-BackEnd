using Dapper;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

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
                _dbConnection.Execute("CreateInterview", param: command, commandType: CommandType.StoredProcedure);
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
                _dbConnection.Execute("AddArtistToInterview", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Interview>> Execute(GetInterviewsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetInterviews", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Interview> result = multi.Read<Interview>().ToList();

                    PagedList<Interview> pagedResult = new PagedList<Interview>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Interview>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Interview>>.Failure(ex.Message);
            }
        }

        public ICqsResult<InterviewDetails> Execute(GetInterviewQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetInterview", param: query, commandType: CommandType.StoredProcedure))
                {
                    InterviewDetails? result = multi.ReadSingleOrDefault<InterviewDetails>();

                    if (result is null)
                        return CqsResult<InterviewDetails>.Failure("Interview Not Found");

                    result.InterviewedArtists = multi.Read<Artist>().ToList();

                    return CqsResult<InterviewDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<InterviewDetails>.Failure(ex.Message);
            }
        }
    }
}
