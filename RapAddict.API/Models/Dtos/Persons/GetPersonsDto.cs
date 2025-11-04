namespace RapAddict.API.Models.Dtos.Persons
{
    public class GetPersonsDto: PagedListDto
    {
        public string? Pseudo { get; set; } = null;

        public GetPersonsDto(): base() { }

        public GetPersonsDto(string? pseudo, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Pseudo = pseudo;
        }
    }
}
