namespace RapAddict.API.Models.Dtos
{
    public class CreateJournalistDto : CreatePersonDto
    {
        public CreateJournalistDto(string pseudo, string? firstName, string? lastName) : base(pseudo, firstName, lastName)
        {
        }
    }
}
