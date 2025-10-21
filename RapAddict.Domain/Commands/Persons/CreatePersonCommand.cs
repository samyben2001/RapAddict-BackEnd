using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class CreatePersonCommand: ICommandResultDefinition<int>
    {
        public string Pseudo { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? ImageUrl { get; }

        public CreatePersonCommand(string pseudo, string? firstName, string? lastName, string? imageUrl)
        {
            Pseudo = pseudo;
            FirstName = firstName;
            LastName = lastName;
            ImageUrl = imageUrl;
        }
    }
}
