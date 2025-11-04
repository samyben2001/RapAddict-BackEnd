using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Albums
{
    public class GetAlbumsQuery: PagedListQuery, IQueryDefinition<PagedList<Album>>
    {
        public string? Title { get; }
        public int? Year { get; }
        public int? Month { get; }
        public int? Day { get; }


        public GetAlbumsQuery(string? title, int? year, int? month, int? day, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Title = title;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
