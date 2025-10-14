using RapAddict.Domain.Commands.Persons;
using Tools.Cqs.Commands;

namespace RapAddict.Domain.Repositories
{
    public interface IContentCreatorRepository: ICommandHandler<CreateContentCreatorCommand>
    {
    }
}
