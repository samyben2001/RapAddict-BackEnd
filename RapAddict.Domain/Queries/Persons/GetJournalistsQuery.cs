using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetJournalistsQuery : PagedListQuery, IQueryDefinition<PagedList<Journalist>>
    {
        public string? Pseudo { get; }


        public GetJournalistsQuery(string? pseudo, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Pseudo = pseudo;
        }
    }
}
