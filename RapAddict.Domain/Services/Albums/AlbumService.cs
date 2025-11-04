using Dapper;
using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Albums;
using RapAddict.Domain.Repositories.Albums;
using System.Data;
using System.Data.Common;
using Tools.Cqs.Results;

namespace RapAddict.Domain.Services.Albums
{
    public class AlbumService : IAlbumRepository
    {
        private readonly DbConnection _dbConnection;

        public AlbumService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public ICqsResult<int> Execute(CreateAlbumCommand command)
        {
            try
            {
                int result = _dbConnection.ExecuteScalar<int>("CreateAlbum", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult<int>.Success(result);
            }
            catch (Exception ex)
            {
                return CqsResult<int>.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddStreamingPlatformToAlbumCommand command)
        {
            try
            {
                _dbConnection.Execute("AddStreamingPlatformToAlbum", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult Execute(AddTrackToAlbumCommand command)
        {
            try
            {
                _dbConnection.Execute("AddTrackToAlbum", param: command, commandType: CommandType.StoredProcedure);
                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return CqsResult.Failure(ex.Message);
            }
        }

        public ICqsResult<PagedList<Album>> Execute(GetAlbumsQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetAlbums", param: query, commandType: CommandType.StoredProcedure))
                {
                    int count = multi.ReadFirst<int>();
                    IEnumerable<Album> albums = multi.Read<Album>().ToList();

                    // Get albums artists (maybe delete)
                    foreach (Album album in albums)
                    {
                        album.Artists = _dbConnection.Query<Artist>("GetAlbumArtists", param: new { album.Id }, commandType: CommandType.StoredProcedure).ToList();
                    }

                    PagedList<Album> pagedAlbums = new PagedList<Album>(albums, query.PageNumber, query.PageSize, count);

                    return CqsResult<PagedList<Album>>.Success(pagedAlbums);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<PagedList<Album>>.Failure(ex.Message);
            }
        }

        public ICqsResult<AlbumDetails> Execute(GetAlbumQuery query)
        {
            try
            {
                using (var multi = _dbConnection.QueryMultiple("GetAlbum", param: query, commandType: CommandType.StoredProcedure))
                {
                    AlbumDetails? album = multi.ReadSingleOrDefault<AlbumDetails>();

                    if (album is null)
                        return CqsResult<AlbumDetails>.Failure("Album Not Found");

                    album.Tracks = multi.Read<Track>().ToList();
                    album.Artists = multi.Read<Artist>().ToList();
                    album.AlbumStreamingPlatforms = multi.Read<EntityPlatform>().ToList();

                    return CqsResult<AlbumDetails>.Success(album);
                }
            }
            catch (Exception ex)
            {
                return CqsResult<AlbumDetails>.Failure(ex.Message);
            }
        }
    }
}
