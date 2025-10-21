namespace RapAddict.API.Models.Dtos.Persons
{
    public class GetArtistsDto
    {
        public string? Pseudo { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetArtistsDto() { }

        public GetArtistsDto(string? pseudo, int pageNumber, int pageSize)
        {
            Pseudo = pseudo;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
