namespace RapAddict.Domain.Entities.Albums
{
    public class AlbumStreamingPlatform
    {
        public string Name { get; }
        public string AlbumPlatformId { get; }

        public AlbumStreamingPlatform(string name, string albumPlatformId)
        {
            Name = name;
            AlbumPlatformId = albumPlatformId;
        }
    }
}
