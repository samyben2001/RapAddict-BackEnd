using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistsQuery: IQueryDefinition<PagedList<Artist>>
    {
        public string? Pseudo { get; }
        public int PageNumber { get; } = 1;
        public int PageSize { get; } = 10;
        public GetArtistsQuery(string? pseudo, int pageNumber, int pageSize)
        {
            Pseudo = pseudo;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
