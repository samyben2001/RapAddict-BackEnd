namespace RapAddict.API.Models.Dtos.Albums
{
    public class GetAlbumsDto: PagedListDto
    {
        public string? Title { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;

        public GetAlbumsDto(): base() { } 

        public GetAlbumsDto(string? title, int? year, int? month, int? day, int pageNumber, int pageSize): base(pageNumber, pageSize)
        {
            Title = title;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
