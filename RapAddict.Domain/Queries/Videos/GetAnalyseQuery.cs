using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Videos
{
    public class GetAnalyseQuery: IQueryDefinition<AnalyseDetails>
    {
        public int Id { get; }

        public GetAnalyseQuery(int id)
        {
            Id = id;
        }
    }
}
