using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddStreamingPlatformToJournalistCommand: ICommandDefinition
    {
        public int JournalistId { get; }
        public int StreamingPlatformId { get; }
        public string JournalistPlatformId { get; }


        public AddStreamingPlatformToJournalistCommand(int personId, int streamingPlatformId, string journalistPlatformId)
        {
            JournalistId = personId;
            StreamingPlatformId = streamingPlatformId;
            JournalistPlatformId = journalistPlatformId;
        }
    }
}
