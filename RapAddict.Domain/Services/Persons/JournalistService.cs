using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Persons
{
    public class JournalistService : IJournalistRepository
    {
        private readonly DbConnection _dbConnection;

        public JournalistService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateJournalistCommand command)
        {
            try
            {
                _dbConnection.Execute("CreateJournalist", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddStreamingPlatformToJournalistCommand command)
        {
            try
            {
                _dbConnection.Execute("AddStreamingPlatformToJournalist", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Journalist>> Execute(GetJournalistsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetJournalists", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Journalist> result = multi.Read<Journalist>().ToList();

                    PagedList<Journalist> pagedResult = new PagedList<Journalist>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Journalist>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Journalist>>.Failure(ex.Message);
            }
        }

        public ICqsResult<JournalistDetails> Execute(GetJournalistQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetJounralist", param: query, commandType: CommandType.StoredProcedure))
                {
                    JournalistDetails? result = multi.ReadSingleOrDefault<JournalistDetails>();

                    if (result is null)
                        return CqsResult<JournalistDetails>.Failure("Journalist Not Found");
                    result.Interviews = multi.Read<Interview>().ToList();
                    result.SocialMedias = multi.Read<EntityPlatform>().ToList();
                    result.StreamingPlatforms = multi.Read<EntityPlatform>().ToList();

                    return CqsResult<JournalistDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<JournalistDetails>.Failure(ex.Message);
            }
        }
    }
}
