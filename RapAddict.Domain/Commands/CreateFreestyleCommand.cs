using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateFreestyleCommand : ICommandDefinition
    {
        public int Id { get; }

        public CreateFreestyleCommand(int id)
        {
            Id = id;
        }
    }
}
