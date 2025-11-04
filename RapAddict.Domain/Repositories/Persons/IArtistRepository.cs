using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Persons;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Persons
{
    public interface IArtistRepository: 
        ICommandHandler<CreateArtistCommand>,
        ICommandHandler<AddAlbumToArtistCommand>,
        ICommandHandler<AddTrackToArtistCommand>,
        ICommandHandler<AddStreamingPlatformToArtistCommand>,
        IQueryHandler<GetArtistsQuery, PagedList<Artist>>,
        IQueryHandler<GetArtistQuery, ArtistDetails>,
        IQueryHandler<GetArtistAlbumsQuery, PagedList<Album>>,
        IQueryHandler<GetArtistTracksQuery, PagedList<Track>>,
        IQueryHandler<GetArtistAnalysesQuery, PagedList<Analyse>>,
        IQueryHandler<GetArtistClipsQuery, PagedList<Clip>>,
        IQueryHandler<GetArtistInterviewsQuery, PagedList<Interview>>,
        IQueryHandler<GetArtistFreestylesQuery, PagedList<Freestyle>>
    {
    }
}
