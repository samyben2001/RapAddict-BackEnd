namespace RapAddict.API.Models.Dtos.Albums
{
    public class AddStreamingPlatformToTrackDto
    {
        public int StreamingPlatformId { get; }
        public string TrackPlatformId { get; }


        public AddStreamingPlatformToTrackDto(int streamingPlatformId, string trackPlatformId)
        {
            StreamingPlatformId = streamingPlatformId;
            TrackPlatformId = trackPlatformId;
        }
    }
}
