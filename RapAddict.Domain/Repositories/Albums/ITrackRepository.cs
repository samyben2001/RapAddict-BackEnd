using RapAddict.Domain.Commands.Albums;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories.Albums
{
    public interface ITrackRepository :
        ICommandResultHandler<CreateTrackCommand, int>
    {
    }
}
