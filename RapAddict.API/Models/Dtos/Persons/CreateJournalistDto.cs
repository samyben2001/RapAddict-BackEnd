namespace RapAddict.API.Models.Dtos.Persons
{
    public class CreateJournalistDto : CreatePersonDto
    {
        public CreateJournalistDto(string pseudo, string? firstName, string? lastName, string? imageUrl) : base(pseudo, firstName, lastName, imageUrl)
        {
        }
    }
}
