namespace RapAddict.API.Models.Dtos
{
    public class CreateContentCreatorDto : CreatePersonDto
    {
        public CreateContentCreatorDto(string pseudo, string? firstName, string? lastName) : base(pseudo, firstName, lastName)
        {
        }
    }
}
