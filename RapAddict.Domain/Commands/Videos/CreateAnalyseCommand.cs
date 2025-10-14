using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Videos
{
    public class CreateAnalyseCommand : ICommandDefinition
    {
        public int Id { get; }
        public int ContentCreatorId { get; }

        public CreateAnalyseCommand(int id, int contentCreatorId)
        {
            Id = id;
            ContentCreatorId = contentCreatorId;
        }
    }
}
