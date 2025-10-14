namespace RapAddict.API.Models.Dtos
{
    public class CreateArtistDto : CreatePersonDto
    {
        public CreateArtistDto(string pseudo, string? firstName, string? lastName) : base(pseudo, firstName, lastName)
        {
        }
    }
}
