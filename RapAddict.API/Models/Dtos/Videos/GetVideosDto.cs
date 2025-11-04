namespace RapAddict.API.Models.Dtos.Videos
{
    public class GetVideosDto: PagedListDto
    {
        public string? Title { get; set; } = null;
        public int? Year { get; set; } = null;
        public int? Month { get; set; } = null;
        public int? Day { get; set; } = null;

        public GetVideosDto(): base() { } 

        public GetVideosDto(string? title, int? year, int? month, int? day, int pageNumber, int pageSize): base(pageNumber, pageSize)
        {
            Title = title;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
