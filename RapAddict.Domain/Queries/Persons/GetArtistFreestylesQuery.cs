using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistFreestylesQuery : PagedListQuery, IQueryDefinition<PagedList<Freestyle>>
    {
        public int Id { get; }

        public GetArtistFreestylesQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
