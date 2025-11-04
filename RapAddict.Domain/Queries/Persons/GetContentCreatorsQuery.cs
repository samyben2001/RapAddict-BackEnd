using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetContentCreatorsQuery : PagedListQuery, IQueryDefinition<PagedList<ContentCreator>>
    {
        public string? Pseudo { get; }


        public GetContentCreatorsQuery(string? pseudo, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Pseudo = pseudo;
        }
    }
}
