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
    public class AnalyseService : IAnalyseRepository
    {
        private readonly DbConnection _dbConnection;

        public AnalyseService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public ICqsResult Execute(CreateAnalyseCommand command)
        {
            try
            {
                _dbConnection.Execute("CreateAnalyse", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddArtistToAnalyseCommand command)
        {
            try
            {
                _dbConnection.Execute("AddArtistToAnalyse", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Analyse>> Execute(GetAnalysesQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetAnalyses", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Analyse> result = multi.Read<Analyse>().ToList();

                    PagedList<Analyse> pagedResult = new PagedList<Analyse>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Analyse>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Analyse>>.Failure(ex.Message);
            }
        }

        public ICqsResult<AnalyseDetails> Execute(GetAnalyseQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetAnalyse", param: query, commandType: CommandType.StoredProcedure))
                {
                    AnalyseDetails? result = multi.ReadSingleOrDefault<AnalyseDetails>();

                    if (result is null)
                        return CqsResult<AnalyseDetails>.Failure("Analyse Not Found");

                    result.AnalysedArtists = multi.Read<Artist>().ToList();

                    return CqsResult<AnalyseDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<AnalyseDetails>.Failure(ex.Message);
            }
        }
    }
}
