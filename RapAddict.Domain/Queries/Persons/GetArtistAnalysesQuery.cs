using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistAnalysesQuery : PagedListQuery, IQueryDefinition<PagedList<Analyse>>
    {
        public int Id { get; }

        public GetArtistAnalysesQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
