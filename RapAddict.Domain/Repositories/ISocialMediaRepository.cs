using RapAddict.Domain.Commands;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories
{
    public interface ISocialMediaRepository :
        ICommandResultHandler<CreateSocialMediaCommand, int>
    {
    }
}
