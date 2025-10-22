using RapAddict.Domain.Entities.Persons;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Persons
{
    public class GetArtistQuery: IQueryDefinition<ArtistDetails>
    {
        public int Id { get; }

        public GetArtistQuery(int id)
        {
            Id = id;
        }
    }
}
