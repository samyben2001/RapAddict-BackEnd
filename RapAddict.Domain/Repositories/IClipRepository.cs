using RapAddict.Domain.Commands;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories
{
    public interface IClipRepository : ICommandHandler<CreateClipCommand>
    {
    }
}
