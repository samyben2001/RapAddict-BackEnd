using RapAddict.Domain.Commands.Videos;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories
{
    public interface IInterviewRepository : ICommandHandler<CreateInterviewCommand>
    {
    }
}
