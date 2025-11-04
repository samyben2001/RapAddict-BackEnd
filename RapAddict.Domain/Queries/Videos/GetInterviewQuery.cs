using RapAddict.Domain.Entities.Videos;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Queries.Videos
{
    public class GetInterviewQuery: IQueryDefinition<InterviewDetails>
    {
        public int Id { get; }

        public GetInterviewQuery(int id)
        {
            Id = id;
        }
    }
}
