using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class CreateContentCreatorCommand : ICommandDefinition
    {
        public int Id { get; }

        public CreateContentCreatorCommand(int id)
        {
            Id = id;
        }
    }
}
