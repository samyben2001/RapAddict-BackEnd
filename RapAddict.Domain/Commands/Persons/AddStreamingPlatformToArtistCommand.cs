using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Persons
{
    public class AddStreamingPlatformToArtistCommand: ICommandDefinition
    {
        public int ArtistId { get; }
        public int StreamingPlatformId { get; }
        public string ArtistPlatformId { get; }


        public AddStreamingPlatformToArtistCommand(int personId, int streamingPlatformId, string artistPlatformId)
        {
            ArtistId = personId;
            StreamingPlatformId = streamingPlatformId;
            ArtistPlatformId = artistPlatformId;
        }
    }
}
