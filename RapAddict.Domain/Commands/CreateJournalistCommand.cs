using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateJournalistCommand: ICommandDefinition
    {
        public int Id { get; }

        public CreateJournalistCommand(int id)
        {
            Id = id;
        }
    }
}
