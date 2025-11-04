using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetJournalistQuery : IQueryDefinition<JournalistDetails>
    {
        public int Id { get; }

        public GetJournalistQuery(int id)
        {
            Id = id;
        }
    }
}
