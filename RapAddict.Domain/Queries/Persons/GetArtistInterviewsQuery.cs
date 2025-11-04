using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistInterviewsQuery : PagedListQuery, IQueryDefinition<PagedList<Interview>>
    {
        public int Id { get; }

        public GetArtistInterviewsQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
