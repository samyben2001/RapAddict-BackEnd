using RapAddict.Domain.Commands.Albums;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Queries.Albums;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Albums
{
    public interface IAlbumRepository :
        ICommandResultHandler<CreateAlbumCommand, int>,
        ICommandHandler<AddStreamingPlatformToAlbumCommand>,
        ICommandHandler<AddTrackToAlbumCommand>,
        IQueryHandler<GetAlbumsQuery, PagedList<Album>>,
        IQueryHandler<GetAlbumQuery, AlbumDetails>
    {
    }
}
