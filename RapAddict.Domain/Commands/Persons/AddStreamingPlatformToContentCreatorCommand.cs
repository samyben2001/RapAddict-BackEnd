using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddStreamingPlatformToContentCreatorCommand: ICommandDefinition
    {
        public int ContentCreatorId { get; }
        public int StreamingPlatformId { get; }
        public string ContentCreatorPlatformId { get; }


        public AddStreamingPlatformToContentCreatorCommand(int personId, int streamingPlatformId, string contentCreatorPlatformId)
        {
            ContentCreatorId = personId;
            StreamingPlatformId = streamingPlatformId;
            ContentCreatorPlatformId = contentCreatorPlatformId;
        }
    }
}
