using Dapper;
using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
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

        public ICqsResult Execute(AddStreamingPlatformToArtistCommand command)
        {
            try
            {
                _dbConnection.Execute("AddStreamingPlatformToArtist", param: command, commandType: CommandType.StoredProcedure);
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
                using (var multi = _dbConnection.QueryMultiple("GetArtists", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Artist> artists = multi.Read<Artist>().ToList();

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
                using (var multi = _dbConnection.QueryMultiple("GetArtist", param: query, commandType: CommandType.StoredProcedure))
                {
                    ArtistDetails? artist = multi.ReadSingleOrDefault<ArtistDetails>();

                    if (artist is null)
                        return CqsResult<ArtistDetails>.Failure("Artist Not Found");
                    artist.SocialMedias = multi.Read<EntityPlatform>().ToList();
                    artist.StreamingPlatforms = multi.Read<EntityPlatform>().ToList();

                    return CqsResult<ArtistDetails>.Success(artist);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<ArtistDetails>.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Album>> Execute(GetArtistAlbumsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistAlbums", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Album> result = multi.Read<Album>().ToList();

                    PagedList<Album> pagedResult = new PagedList<Album>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Album>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Album>>.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Track>> Execute(GetArtistTracksQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistTracks", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Track> result = multi.Read<Track>().ToList();

                    PagedList<Track> pagedResult = new PagedList<Track>(result, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Track>>.Success(pagedResult);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Track>>.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Analyse>> Execute(GetArtistAnalysesQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistAnalyses", param: query, commandType: CommandType.StoredProcedure))
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

        public ICqsResult<PagedList<Clip>> Execute(GetArtistClipsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistClips", param: query, commandType: CommandType.StoredProcedure))
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

        public ICqsResult<PagedList<Interview>> Execute(GetArtistInterviewsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistInterviews", param: query, commandType: CommandType.StoredProcedure))
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

        public ICqsResult<PagedList<Freestyle>> Execute(GetArtistFreestylesQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetArtistFreestyles", param: query, commandType: CommandType.StoredProcedure))
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
    }
}
