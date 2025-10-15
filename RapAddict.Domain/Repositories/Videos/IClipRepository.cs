using RapAddict.Domain.Commands.Videos;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories.Videos
{
    public interface IClipRepository : 
        ICommandHandler<CreateClipCommand>,
        ICommandHandler<AddArtistToClipCommand>
    {
    }
}
