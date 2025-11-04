using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Videos
{
    public class GetClipQuery: IQueryDefinition<ClipDetails>
    {
        public int Id { get; }

        public GetClipQuery(int id)
        {
            Id = id;
        }
    }
}
