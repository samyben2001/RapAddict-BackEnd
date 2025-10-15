using RapAddict.Domain.Entities.Albums;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Albums
{
    public class GetAlbumsQuery: IQueryDefinition<IEnumerable<Album>>
    {
        public string? Title { get; }
        public int? Year { get; }
        public int? Month { get; }
        public int? Day { get; }
        public int? PageNumber { get; } =  1;
        public int? PageSize { get; } = 10;


        public GetAlbumsQuery(string? title, int? year, int? month, int? day, int? pageNumber, int? pageSize)
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
