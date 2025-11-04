using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetContentCreatorQuery : IQueryDefinition<ContentCreatorDetails>
    {
        public int Id { get; }

        public GetContentCreatorQuery(int id)
        {
            Id = id;
        }
    }
}
