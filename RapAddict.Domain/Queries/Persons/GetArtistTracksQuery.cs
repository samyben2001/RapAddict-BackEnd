using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistTracksQuery : PagedListQuery, IQueryDefinition<PagedList<Track>>
    {
        public int Id { get; }

        public GetArtistTracksQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
