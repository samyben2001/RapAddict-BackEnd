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
                _dbConnection.Execute("CreateClip", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddArtistToClipCommand command)
        {
            try
            {
                _dbConnection.Execute("AddArtistToClip", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Clip>> Execute(GetClipsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetClips", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Clip> result = multi.Read<Clip>().ToList();

                    PagedList<Clip> pagedResult = new PagedList<Clip>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Clip>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Clip>>.Failure(ex.Message);
            }
        }

        public ICqsResult<ClipDetails> Execute(GetClipQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetClip", param: query, commandType: CommandType.StoredProcedure))
                {
                    ClipDetails? result = multi.ReadSingleOrDefault<ClipDetails>();

                    if (result is null)
                        return CqsResult<ClipDetails>.Failure("Clip Not Found");

                    result.ClippedArtists = multi.Read<Artist>().ToList();

                    return CqsResult<ClipDetails>.Success(result);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<ClipDetails>.Failure(ex.Message);
            }
        }
    }
}
