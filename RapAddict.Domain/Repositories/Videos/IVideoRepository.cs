using RapAddict.Domain.Commands.Videos;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories.Videos
{
    public interface IVideoRepository :
        ICommandResultHandler<CreateVideoCommand, int>
    {
    }
}
