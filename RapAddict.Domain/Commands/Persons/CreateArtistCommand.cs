using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class CreateArtistCommand: ICommandDefinition
    {
        public int Id { get; }

        public CreateArtistCommand(int id)
        {
            Id = id;
        }
    }
}
