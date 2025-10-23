namespace RapAddict.API.Models.Dtos.Persons
{
    public class GetArtistsDto: PagedListDto
    {
        public string? Pseudo { get; set; } = null;

        public GetArtistsDto(): base() { }

        public GetArtistsDto(string? pseudo, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Pseudo = pseudo;
        }
    }
}
