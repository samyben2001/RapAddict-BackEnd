namespace RapAddict.Domain.Entities.Persons
{
    public class ArtistStreamingPlatform
    {
        public string Name { get; }
        public string ArtistPlatformId { get; }

        public ArtistStreamingPlatform(string name, string artistPlatformId)
        {
            Name = name;
            ArtistPlatformId = artistPlatformId;
        }
    }
}
