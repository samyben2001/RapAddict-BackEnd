using RapAddict.Domain.Commands.Albums;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories
{
    public interface IStreamingPlatformRepository :
        ICommandResultHandler<CreateStreamingPlatformCommand, int>
    {
    }
}
