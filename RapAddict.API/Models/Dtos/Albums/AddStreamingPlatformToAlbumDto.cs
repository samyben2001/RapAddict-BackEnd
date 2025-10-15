namespace RapAddict.API.Models.Dtos.Albums
{
    public class AddStreamingPlatformToAlbumDto
    {
        public int StreamingPlatformId { get; }
        public string AlbumPlatformId { get; }


        public AddStreamingPlatformToAlbumDto(int streamingPlatformId, string albumPlatformId)
        {
            StreamingPlatformId = streamingPlatformId;
            AlbumPlatformId = albumPlatformId;
        }
    }
}
