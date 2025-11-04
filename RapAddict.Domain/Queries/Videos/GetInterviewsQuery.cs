using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Videos
{
    public class GetInterviewsQuery: PagedListQuery, IQueryDefinition<PagedList<Interview>>
    {
        public string? Title { get; }
        public int? Year { get; }
        public int? Month { get; }
        public int? Day { get; }


        public GetInterviewsQuery(string? title, int? year, int? month, int? day, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Title = title;
            Year = year;
            Month = month;
            Day = day;
        }
    }
}
