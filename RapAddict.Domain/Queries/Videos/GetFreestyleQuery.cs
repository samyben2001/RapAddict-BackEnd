using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Videos
{
    public class GetFreestyleQuery: IQueryDefinition<FreestyleDetails>
    {
        public int Id { get; }

        public GetFreestyleQuery(int id)
        {
            Id = id;
        }
    }
}
