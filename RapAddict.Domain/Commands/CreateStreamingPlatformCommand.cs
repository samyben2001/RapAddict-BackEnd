using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands
{
    public class CreateStreamingPlatformCommand : ICommandResultDefinition<int>
    {
        public string Name { get; }

        public CreateStreamingPlatformCommand(string name)
        {
            Name = name;
        }
    }
}
