namespace RapAddict.API.Models.Dtos.Albums
{
    public class GetAlbumsDto
    {
        public string? Title { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;

        public GetAlbumsDto() { } 

        public GetAlbumsDto(string? title, int? year, int? month, int? day, int? pageNumber, int? pageSize)
        {
            Title = title;
            Year = year;
            Month = month;
            Day = day;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
