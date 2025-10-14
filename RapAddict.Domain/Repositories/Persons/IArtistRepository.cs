using RapAddict.Domain.Commands.Persons;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories.Persons
{
    public interface IArtistRepository: 
        ICommandHandler<CreateArtistCommand>,
        ICommandHandler<AddAlbumToArtistCommand>
    {
    }
}
