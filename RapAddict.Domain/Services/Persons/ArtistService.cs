using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Persons;
using RapAddict.Domain.Repositories.Persons;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Persons
{
    public class ArtistService : IArtistRepository
    {
        private readonly DbConnection _dbConnection;

        public ArtistService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICqsResult Execute(CreateArtistCommand command)
        {
            try
            {
                _dbConnection.Execute("CreateArtist", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddAlbumToArtistCommand command)
        {
            try
            {
                _dbConnection.Execute("AddAlbumToArtist", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddTrackToArtistCommand command)
        {
            try
            {
                _dbConnection.Execute("AddTrackToArtist", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Artist>> Execute(GetArtistsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("Getartists", param: query, commandType: CommandType.StoredProcedure))
                {
                    IEnumerable<Artist> artists = multi.Read<Artist>().ToList();
                    int count = multi.ReadFirst<int>();

                    PagedList<Artist> pagedArtists = new PagedList<Artist>(artists, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Artist>>.Success(pagedArtists);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Artist>>.Failure(ex.Message);
            }
        }

        public ICqsResult<ArtistDetails> Execute(GetArtistQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("Getartist", param: query, commandType: CommandType.StoredProcedure))
                {
                    ArtistDetails? artist = multi.ReadSingleOrDefault<ArtistDetails>();

                    if (artist is null)
                        return CqsResult<ArtistDetails>.Failure("Artist Not Found");
                    artist.ArtistStreamingPlatforms = multi.Read<ArtistStreamingPlatform>().ToList();

                    return CqsResult<ArtistDetails>.Success(artist);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<ArtistDetails>.Failure(ex.Message);
            }
        }
    }
}
