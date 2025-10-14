using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class CreatePersonCommand: ICommandResultDefinition<int>
    {
        public string Pseudo { get; }
        public string? FirstName { get; }
        public string? LastName { get; }

        public CreatePersonCommand(string pseudo, string? firstName, string? lastName)
        {
            Pseudo = pseudo;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
