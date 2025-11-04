using Dapper;
using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
using RapAddict.Domain.Repositories.Videos;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

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
                _dbConnection.Execute("CreateFreestyle", param: command, commandType: CommandType.StoredProcedure);
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
                _dbConnection.Execute("AddArtistToFreestyle", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Freestyle>> Execute(GetFreestylesQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetFreestyles", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Freestyle> result = multi.Read<Freestyle>().ToList();

                    PagedList<Freestyle> pagedResult = new PagedList<Freestyle>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Freestyle>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Freestyle>>.Failure(ex.Message);
            }
        }

        public ICqsResult<FreestyleDetails> Execute(GetFreestyleQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetFreestyle", param: query, commandType: CommandType.StoredProcedure))
                {
                    FreestyleDetails? result = multi.ReadSingleOrDefault<FreestyleDetails>();

                    if (result is null)
                        return CqsResult<FreestyleDetails>.Failure("Freestyle Not Found");

                    result.Freestylers = multi.Read<Artist>().ToList();

                    return CqsResult<FreestyleDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<FreestyleDetails>.Failure(ex.Message);
            }
        }
    }
}
