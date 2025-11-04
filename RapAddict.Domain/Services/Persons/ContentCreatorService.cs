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
    public class ContentCreatorService : IContentCreatorRepository
    {
        private readonly DbConnection _dbConnection;

        public ContentCreatorService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateContentCreatorCommand command)
        {
            try
            {
                _dbConnection.Execute("CreateContentCreator", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddStreamingPlatformToContentCreatorCommand command)
        {
            try
            {
                _dbConnection.Execute("AddStreamingPlatformToContentCreator", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<ContentCreator>> Execute(GetContentCreatorsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetContentCreators", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<ContentCreator> result = multi.Read<ContentCreator>().ToList();

                    PagedList<ContentCreator> pagedResult = new PagedList<ContentCreator>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<ContentCreator>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<ContentCreator>>.Failure(ex.Message);
            }
        }

        public ICqsResult<ContentCreatorDetails> Execute(GetContentCreatorQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetContentCreator", param: query, commandType: CommandType.StoredProcedure))
                {
                    ContentCreatorDetails? result = multi.ReadSingleOrDefault<ContentCreatorDetails>();

                    if (result is null)
                        return CqsResult<ContentCreatorDetails>.Failure("Content Creator Not Found");

                    result.Analyses = multi.Read<Analyse>().ToList();
                    result.SocialMedias = multi.Read<EntityPlatform>().ToList();
                    result.StreamingPlatforms = multi.Read<EntityPlatform>().ToList();

                    return CqsResult<ContentCreatorDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<ContentCreatorDetails>.Failure(ex.Message);
            }
        }
    }
}
