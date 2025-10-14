namespace RapAddict.API.Models.Dtos.Persons
{
    public class CreateArtistDto : CreatePersonDto
    {
        public int[]? AlbumsId { get; }


        public CreateArtistDto(string pseudo, string? firstName, string? lastName, int[]? albumsId) : base(pseudo, firstName, lastName)
        {
            AlbumsId = albumsId;
        }
    }
}
