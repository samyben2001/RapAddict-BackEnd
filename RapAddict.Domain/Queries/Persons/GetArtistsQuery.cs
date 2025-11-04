using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistsQuery: PagedListQuery, IQueryDefinition<PagedList<Artist>>
    {
        public string? Pseudo { get; }


        public GetArtistsQuery(string? pseudo, int pageNumber, int pageSize): base(pageNumber, pageSize)
        {
            Pseudo = pseudo;
        }
    }
}
