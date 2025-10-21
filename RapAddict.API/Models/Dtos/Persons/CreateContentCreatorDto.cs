namespace RapAddict.API.Models.Dtos.Persons
{
    public class CreateContentCreatorDto : CreatePersonDto
    {
        public CreateContentCreatorDto(string pseudo, string? firstName, string? lastName, string? imageUrl) : base(pseudo, firstName, lastName, imageUrl)
        {
        }
    }
}
