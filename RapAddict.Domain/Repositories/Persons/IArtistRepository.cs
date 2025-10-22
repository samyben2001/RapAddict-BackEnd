using RapAddict.Domain.Commands.Persons;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using RapAddict.Domain.Queries.Persons;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Persons
{
    public interface IArtistRepository: 
        ICommandHandler<CreateArtistCommand>,
        ICommandHandler<AddAlbumToArtistCommand>,
        ICommandHandler<AddTrackToArtistCommand>,
        IQueryHandler<GetArtistsQuery, PagedList<Artist>>,
        IQueryHandler<GetArtistQuery, ArtistDetails>
    {
    }
}
