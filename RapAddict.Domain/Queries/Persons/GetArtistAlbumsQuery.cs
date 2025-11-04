using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Albums;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistAlbumsQuery : PagedListQuery, IQueryDefinition<PagedList<Album>>
    {
        public int Id { get; }

        public GetArtistAlbumsQuery(int id, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Id = id;
        }
    }
}
