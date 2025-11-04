using RapAddict.Domain.Commands.Videos;
using RapAddict.Domain.Entities;
using RapAddict.Domain.Entities.Videos;
using RapAddict.Domain.Queries.Videos;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace RapAddict.Domain.Repositories.Videos
{
    public interface IInterviewRepository : 
        ICommandHandler<CreateInterviewCommand>,
        ICommandHandler<AddArtistToInterviewCommand>,
        IQueryHandler<GetInterviewsQuery, PagedList<Interview>>,
        IQueryHandler<GetInterviewQuery, InterviewDetails>
    {
    }
}
