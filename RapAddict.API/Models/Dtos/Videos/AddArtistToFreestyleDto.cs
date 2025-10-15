namespace RapAddict.API.Models.Dtos.Videos
{
    public class AddArtistToFreestyleDto
    {
        public int FreestyleId { get; }
        public int ArtistId { get; }


        public AddArtistToFreestyleDto(int freestyleId, int artistId)
        {
            FreestyleId = freestyleId;
            ArtistId = artistId;
        }
    }
}
