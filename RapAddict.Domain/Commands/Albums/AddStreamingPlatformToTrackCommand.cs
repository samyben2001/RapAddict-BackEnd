using Tools.Cqs.Commands;

namespace RapAddict.Domain.Commands.Albums
{
    public class AddStreamingPlatformToTrackCommand: ICommandDefinition
    {
        public int TrackId { get; }
        public int StreamingPlatformId { get; }
        public string TrackPlatformId { get; }


        public AddStreamingPlatformToTrackCommand(int trackId, int streamingPlatformId, string trackPlatformId)
        {
            TrackId = trackId;
            StreamingPlatformId = streamingPlatformId;
            TrackPlatformId = trackPlatformId;
        }
    }
}
