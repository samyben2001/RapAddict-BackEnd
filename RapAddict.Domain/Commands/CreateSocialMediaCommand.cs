using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
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
