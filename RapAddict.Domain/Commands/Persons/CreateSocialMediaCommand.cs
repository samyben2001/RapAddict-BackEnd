using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class CreateSocialMediaCommand : ICommandResultDefinition<int>
    {
        public string Name { get; }

        public CreateSocialMediaCommand(string name)
        {
            Name = name;
        }
    }
}
